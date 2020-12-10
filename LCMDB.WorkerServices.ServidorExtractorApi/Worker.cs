using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LCMDB.BD.Contextos.LCMDB;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using LCMDB.BD.Contextos.LCMDB.Modelos.v1_0;
using SaltwaterTaffy.Container;
using SaltwaterTaffy;
using LCMDB.RegistroEventos.Servidores;
using LCMDB.WorkerServices.ServidoresExtractor.Helpers;
using Microsoft.Extensions.Configuration;
using NETCore.Base._3._0;
using LCMDB.WorkerServices.ServidoresExtractorApi.ModelosInternos;
using Microsoft.EntityFrameworkCore;
using BCP.NETCore.Base;


namespace LCMDB.WorkerServices.ServidoresExtractorApi
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Configuracion configuracion;
        private readonly CMDBContexto contexto = new CMDBContexto();
        private DateTime ProximaEjecucion;
        private bool Ocupado;
        RegistroLogs Logs = new RegistroLogs();

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
                if (DateTime.Now.Ticks>ProximaEjecucion.Ticks && !Ocupado)
                {
                        Logs.RegistrarEvento(TipoEvento.Informativo, "Iniciando el proceso...");
                        Ocupado = true;
                    var RegistroNuevo = new BD.Contextos.LCMDB.Modelos.v1_0.RegistroEjecucion() { FechaHoraInicio = DateTime.Now, FechaHoraFin = DateTime.Now, Finalizado = false, ServicioID = configuracion.ServicioID };
                    contexto.Reg_RegistroEjecucion.Add(RegistroNuevo);
                    await contexto.SaveChangesAsync();

                    var Vnets = contexto.Cnf_SegmentoRed.Where(x => x.Habilitada == true).ToList();
                        Logs.RegistrarEvento(TipoEvento.Informativo, "VNets para el proceso...", Vnets);
                        foreach (SegmentoRed Segmento in Vnets)
                    {
                            string RedStr = Segmento.IpRed;
                        if (Segmento.MascaraSegmento != "0")
                            RedStr += "/" + Segmento.MascaraSegmento;
                            Logs.RegistrarEvento(TipoEvento.Informativo, "Iniciando proceso de obtención de red "+ RedStr + "...");
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
                                try
                                    { 
                                    contexto.Inv_Servidores.Add(_servidor);
                                await contexto.SaveChangesAsync();
                                await RegistroServidores.NuevoServidorAsync(_servidor);
                                    }
                                    catch (Exception Ex)
                                    {
                                        Logs.RegistrarEvento(TipoEvento.Error, Ex,_servidor);
                                    }
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
                                SO NSo = new SO();
                                try { 
                                BaseDatos.ObtenerValor(contexto, "TRUNCATE TABLE lcmdb.Inv_SO_Servidores");
                                foreach (Os _so in _servidores.OsMatches.ToList())
                                {
                                    NSo = new SO() { IdServidor = _servidor.IdServidor, Certeza = _so.Certainty, Familia = _so.Family, Generacion = _so.Generation, Nombre = _so.Name, FechaRegistro = DateTime.Now, FechaModificacion= DateTime.Now };
                                    contexto.Add(NSo);
                                    await contexto.SaveChangesAsync();
                                }
                                }
                                catch (Exception Ex)
                                {
                                    Logs.RegistrarEvento(TipoEvento.Error, Ex, NSo);
                                }
                                #endregion Servidor
                                #region Puertos
                                foreach (Port Puerto in _servidores.Ports.ToList())
                            {
                                PuertosServidores NPuerto = new PuertosServidores() { Habilitado = true, Puerto = Puerto.PortNumber, Nombre = Puerto.Service.Name, Producto = Puerto.Service.Product, SistemOperativo = Puerto.Service.Os, TipoProtocolo = Puerto.Protocol, Version = Puerto.Service.Version, IdServidor = _servidor.IdServidor, FechaRegistro = DateTime.Now, FechaModificacion = DateTime.Now };
                                try
                                    { 
                                    var PuertoActual = contexto.Inv_PuertosServidores.FirstOrDefault(x =>x.IdServidor==_servidor.IdServidor &&  x.Puerto == Puerto.PortNumber);
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
                                    catch (Exception Ex)
                                    {
                                        Logs.RegistrarEvento(TipoEvento.Error, Ex, NPuerto);
                                    }
                                }
                                #endregion Puertos
                            }
                        }

                        //await Task.Delay(5000, stoppingToken);
                        Logs.RegistrarEvento(TipoEvento.Informativo, "Fin proceso de registro...");

                        RegistroNuevo.Finalizado = true;
                    RegistroNuevo.FechaHoraFin = DateTime.Now;
                    contexto.Entry(RegistroNuevo).State = EntityState.Modified;
                    //contexto.Reg_RegistroEjecucion.Add(RegistroNuevo);
                    await contexto.SaveChangesAsync();
                    EstablecerEjecucion();
                    }
                    await Task.Delay(10000, stoppingToken);
                }
                catch (Exception Ex)
                {
                    Logs.RegistrarEvento(TipoEvento.Error, Ex);
                    Logs.RegistrarEventoSimple(TipoEvento.Error, DateTime.Now,Ex.ToString());
                }
                finally
                {
                    Ocupado = false;
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
