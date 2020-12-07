using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LCMDB.WorkerServices.ServidoresExtractor.ModelosInternos;
using LCMDB.BD.Contextos.LCMDB;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using LCMDB.BD.Contextos.LCMDB.Modelos.v1_0;
using System.Net;
using System.Net.NetworkInformation;
using LCMDB.Utilidades.Monitoreo.Red;
using SaltwaterTaffy.Container;
using SaltwaterTaffy;
using LCMDB.RegistroEventos.Servidores;
using LCMDB.WorkerServices.ServidoresExtractor.Helpers;
using Microsoft.Extensions.Configuration;
using NETCore.Base._3._0;
using Newtonsoft.Json;

namespace LCMDB.WorkerServices.ServidoresExtractor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Configuracion configuracion;
        private readonly CMDBContexto contexto = new CMDBContexto();
        private DateTime ProximaEjecucion;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            //IConfiguration configuration = hostContext.Configuration;
            BaseConfiguracion Bconf = new BaseConfiguracion();
            this.configuracion = new Configuracion();
            this.configuracion.ServicioID = Bconf.ObtenerValor("Configuracion:ServicioID");
            this.configuracion.HoraEjecucion = DateTime.Parse( Bconf.ObtenerValor("Configuracion:HoraEjecucion"));
            EstablecerEjecucion();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                { 
                if (DateTime.Now.Ticks>ProximaEjecucion.Ticks)
                {
                    var RegistroNuevo = new BD.Contextos.LCMDB.Modelos.v1_0.RegistroEjecucion() { FechaHoraInicio = DateTime.Now, FechaHoraFin = DateTime.Now, Finalizado = false, ServicioID = configuracion.ServicioID };
                    contexto.Reg_RegistroEjecucion.Add(RegistroNuevo);
                    await contexto.SaveChangesAsync();

                    var Vnets = contexto.Cnf_SegmentoRed.Where(x => x.Habilitada == true).ToList();

                    foreach (SegmentoRed Segmento in Vnets)
                    {
                        string RedStr = Segmento.IpRed;
                        if (Segmento.MascaraSegmento != "0")
                            RedStr += "/" + Segmento.MascaraSegmento;
                        var Red = new Target(RedStr);
                        var result = new Scanner(Red, System.Diagnostics.ProcessWindowStyle.Hidden).PortScan();
                        foreach(var _servidores in result.Hosts.ToList())
                        {
                            #region Servidor
                            string NombreServidor = string.Empty;
                            if (_servidores.Hostnames.ToList().Count > 0)
                            {
                                NombreServidor = _servidores.Hostnames.ToList().FirstOrDefault();
                            }
                            if (string.IsNullOrEmpty(NombreServidor)) NombreServidor = _servidores.Address.ToString();
                            var _servidor = contexto.Inv_Servidores.FirstOrDefault(x=>x.IP==_servidores.Address.ToString());
                            if (_servidor==null)
                            {
                                //foreach(string Nombre in _servidores.Hostnames)
                                //{

                                //}
                                _servidor = new Servidor() { IP = _servidores.Address.ToString(), NombreServidor = NombreServidor, FechaRegistro = DateTime.Now, FechaModificacion=DateTime.Now };
                                contexto.Inv_Servidores.Add(_servidor);
                                await contexto.SaveChangesAsync();
                                await RegistroServidores.NuevoServidorAsync(_servidor);

                            }
                            else
                            {
                                if (_servidor.NombreServidor != NombreServidor)
                                {
                                    string AntiguoNombre = _servidor.NombreServidor;
                                    _servidor.NombreServidor = NombreServidor;
                                    contexto.Entry(_servidor).State = EntityState.Modified;
                                    await contexto.SaveChangesAsync();
                                    await RegistroServidores.CambioNombreAsync(_servidor, AntiguoNombre);
                                }
                            }
                            #endregion Servidor
                            #region Puertos
                            foreach (Port Puerto in _servidores.Ports.ToList())
                            {
                                PuertosServidores NPuerto = new PuertosServidores() { Habilitado = true, Puerto = short.Parse(Puerto.PortNumber.ToString()), Nombre = Puerto.Service.Name, Producto = Puerto.Service.Product, SistemOperativo = Puerto.Service.Os, TipoProtocolo = Puerto.Protocol, Version = Puerto.Service.Version, IdServidor = _servidor.IdServidor, FechaRegistro = DateTime.Now, FechaModificacion = DateTime.Now };
                                var PuertoActual = contexto.Inv_PuertosServidores.FirstOrDefault(x => x.Puerto == short.Parse(Puerto.PortNumber.ToString()));
                                if (PuertoActual!=null)
                                {
                                    NPuerto.IdPuerto = PuertoActual.IdPuerto;
                                    NPuerto.FechaRegistro = PuertoActual.FechaRegistro;
                                    NPuerto.FechaModificacion = PuertoActual.FechaModificacion;
                                    NPuerto.Servidor = PuertoActual.Servidor;
                                    if (!ComparadorObjetos.AreObjectsEqual(NPuerto, PuertoActual, new string[] {"Servidor", "FechaModificacion", "FechaRegistro"}))
                                    {
                                            NPuerto.FechaModificacion = DateTime.Now;
                                            contexto.Entry(PuertoActual).CurrentValues.SetValues(NPuerto);
                                            await contexto.SaveChangesAsync();
                                    }
                                }
                                else
                                    {
                                        contexto.Inv_PuertosServidores.Add(NPuerto);
                                        await contexto.SaveChangesAsync();
                                    }
                            }
                            #endregion Puertos
                        }
                    }

                    await Task.Delay(5000, stoppingToken);

                    RegistroNuevo.Finalizado = true;
                    RegistroNuevo.FechaHoraFin = DateTime.Now;
                    contexto.Entry(RegistroNuevo).State = EntityState.Modified;
                    //contexto.Reg_RegistroEjecucion.Add(RegistroNuevo);
                    await contexto.SaveChangesAsync();
                    EstablecerEjecucion();
                }
                }
                catch (Exception Ex)
                {
                    string Error = "";
                }
            }
        }
        private void EstablecerEjecucion()
        {
            bool EjecutadoHoy=contexto.Reg_RegistroEjecucion.Any(x =>x.ServicioID==configuracion.ServicioID&&x.FechaHoraInicio.Date==DateTime.Now.Date&&x.Finalizado==true);
            TimeSpan HoraEjecucion = configuracion.HoraEjecucion.TimeOfDay;
            if (!EjecutadoHoy)
            {
                if (DateTime.Now.TimeOfDay>HoraEjecucion)
                {
                    ProximaEjecucion = DateTime.Now.AddSeconds(30);
                }
                else
                {
                    ProximaEjecucion = DateTime.Now.Date + HoraEjecucion;
#if DEBUG
                    ProximaEjecucion = DateTime.Now.AddSeconds(30);
#endif

                }
            }
            else
            {
                ProximaEjecucion = DateTime.Now.Date.AddDays(1) + HoraEjecucion;
            }
        }
    }
}
