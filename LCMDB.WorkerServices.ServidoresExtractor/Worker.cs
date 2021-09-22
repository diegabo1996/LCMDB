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
using SaltwaterTaffy.Container;
using SaltwaterTaffy;
using LCMDB.RegistroEventos.Servidores;
using NETCore.Base._3._0;
using BCP.NETCore.Base;
using AutoMapper;
using Newtonsoft.Json;

namespace LCMDB.WorkerServices.ServidoresExtractor
{
    public class Worker : BackgroundService
    {
        private readonly IMapper mapper;
        private readonly ILogger<Worker> _logger;
        private readonly Configuracion configuracion;
        private readonly CMDBContexto contexto = new CMDBContexto();
        private DateTime ProximaEjecucion;
        private bool Ocupado;
        RegistroLogs Logs = new RegistroLogs();

        public Worker(ILogger<Worker> logger, IMapper mapper)
        {
            _logger = logger;
            this.mapper = mapper;
            //IConfiguration configuration = hostContext.Configuration;
            BaseConfiguracion Bconf = new BaseConfiguracion();
            this.configuracion = new Configuracion();
            this.configuracion.ServicioID = Bconf.ObtenerValor("Configuracion:ServicioID");
            this.configuracion.HoraEjecucion = DateTime.Parse(Bconf.ObtenerValor("Configuracion:HoraEjecucion"));
            EstablecerEjecucion();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    if (DateTime.Now.Ticks > ProximaEjecucion.Ticks && !Ocupado)
                    {
                        Logs.RegistrarEvento(TipoEvento.Informativo, "Iniciando el procesoX...");
                        Ocupado = true;
                        var Vnets = EstablecerEjecucion();
                        if (Vnets != null)
                        {
                            Logs.RegistrarEvento(TipoEvento.Informativo, "VNets para el proceso...", Vnets);
                            foreach (SegmentoRed Segmento in Vnets)
                            {
                                var RegistroPendiente = contexto.Reg_RegistroEjecucion.Where(x => x.IdSegmento == Segmento.IdSegmento && x.Finalizado == false).FirstOrDefault();
                                string RedStr = Segmento.IpRed;
                                if (Segmento.MascaraSegmento != "0")
                                    RedStr += "/" + Segmento.MascaraSegmento;
                                Logs.RegistrarEvento(TipoEvento.Informativo, "Iniciando proceso de obtención de red " + RedStr + "...");
                                ScanResult result = null;
                                var Red = new Target(RedStr);
                                BD.Contextos.LCMDB.Modelos.v1_0.RegistroEjecucion RegistroNuevo = null;
                                if (RegistroPendiente != null)
                                {
                                    RegistroNuevo = RegistroPendiente;
                                    result = new Scanner(Red, System.Diagnostics.ProcessWindowStyle.Hidden).PortScan(RegistroPendiente.Detalle);
                                }
                                else
                                {
                                    result = new Scanner(Red, System.Diagnostics.ProcessWindowStyle.Hidden).PortScan();
                                    RegistroNuevo = new BD.Contextos.LCMDB.Modelos.v1_0.RegistroEjecucion() { FechaHoraInicio = DateTime.Now, FechaHoraFin = DateTime.Now, Finalizado = false, ServicioID = configuracion.ServicioID, Detalle = result.Archivo, IdSegmento = Segmento.IdSegmento };
                                    contexto.Reg_RegistroEjecucion.Add(RegistroNuevo);
                                    await contexto.SaveChangesAsync();
                                }
                                VolcarHistorico(Segmento.IdSegmento);
                                foreach (var _servidores in result.Hosts.ToList())
                                {
                                    #region Servidor
                                    string NombreServidor = string.Empty;
                                    Api api = new Api();
                                    if (_servidores.Hostnames.ToList().Count > 0)
                                    {
                                        NombreServidor = _servidores.Hostnames.ToList().FirstOrDefault().ToUpper();
                                    }
                                    if (string.IsNullOrEmpty(NombreServidor)) NombreServidor = _servidores.Address.ToString();
                                    ServidoresHistorico Hist = contexto.Hist_Inv_Servidores.Where(x => x.IP == _servidores.Address.ToString()).OrderByDescending(x => x.FechaRegistroVolcado).FirstOrDefault();
                                    Servidor _servidorAnt = null;
                                    Servidor _servidor = null;

                                    if (Hist != null)
                                    {
                                        _servidorAnt = mapper.Map<Servidor>(Hist);
                                    }
                                    _servidor = new Servidor() { IP = _servidores.Address.ToString(), NombreServidor = NombreServidor, IdRegistro = RegistroNuevo.IdRegistro, FechaRegistro = DateTime.Now };
                                    contexto.Inv_Servidores.Add(_servidor);
                                    await contexto.SaveChangesAsync();
                                    if (Hist == null)
                                    {
                                        try
                                        {
                                            await RegistroServidores.NuevoServidorAsync(_servidor);
                                        }
                                        catch (Exception Ex)
                                        {
                                            Logs.RegistrarEvento(TipoEvento.Error, Ex, _servidor);
                                        }
                                    }
                                    else
                                    {
                                        if (_servidorAnt.NombreServidor != NombreServidor)
                                        {
                                            string AntiguoNombre = _servidorAnt.NombreServidor;
                                            await RegistroServidores.CambioNombreAsync(_servidor, AntiguoNombre);
                                        }
                                    }
                                    SO NSo = new SO();
                                    try
                                    {
                                        //BaseDatos.ObtenerValor(contexto, "TRUNCATE TABLE lcmdb.Inv_SO_Servidores");
                                        foreach (Os _so in _servidores.OsMatches.ToList())
                                        {
                                            NSo = new SO() { IP = _servidor.IP, Certeza = _so.Certainty, Familia = _so.Family, Generacion = _so.Generation, Nombre = _so.Name, FechaRegistro = DateTime.Now, IdRegistro = RegistroNuevo.IdRegistro };
                                            contexto.Add(NSo);
                                            await contexto.SaveChangesAsync();
                                        }
                                        if (_servidores.OsMatches.Any(x => x.Family == "Windows"))
                                        {
                                            Servidor SRVRQWS = new Servidor() { IP = _servidor.IP, FechaRegistro = DateTime.Now, NombreServidor = _servidor.NombreServidor };
                                            api.Post("https://servicios.infracode.bancred.com.bo/LCMDB.WSExtractor.MicroServicio/api/SolicitudExtraccionWS", JsonConvert.SerializeObject(SRVRQWS));
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
                                        PuertosServidores NPuerto = new PuertosServidores() { Habilitado = true, Puerto = Puerto.PortNumber, Nombre = Puerto.Service.Name, Producto = Puerto.Service.Product, SistemOperativo = Puerto.Service.Os, TipoProtocolo = Puerto.Protocol, Version = Puerto.Service.Version, IP = _servidor.IP, FechaRegistro = DateTime.Now, IdRegistro = RegistroNuevo.IdRegistro };
                                        try
                                        {
                                            var PuertoActual = contexto.Inv_PuertosServidores.FirstOrDefault(x => x.IP == _servidor.IP && x.Puerto == Puerto.PortNumber);
                                            contexto.Inv_PuertosServidores.Add(NPuerto);
                                            await contexto.SaveChangesAsync();
                                        }
                                        catch (Exception Ex)
                                        {
                                            Logs.RegistrarEvento(TipoEvento.Error, Ex, NPuerto);
                                        }
                                    }
                                    #endregion Puertos
                                    if (contexto.Inv_PuertosServidores.Any(x => x.IP == _servidor.IP && x.Habilitado && x.Producto.Contains("IIS") && x.Version != null && x.Version != "6.0" && x.SistemOperativo == "Windows"))
                                    {
                                        Servidor SRVRQ = new Servidor() { IP = _servidor.IP, FechaRegistro = DateTime.Now, NombreServidor = _servidor.NombreServidor };
                                        api.Post("https://servicios.infracode.bancred.com.bo/LCMDB.IISExtractor.MicroServicio/api/SolicitudExtraccionIIS", JsonConvert.SerializeObject(SRVRQ));
                                    }
                                }
                                RegistroNuevo.Finalizado = true;
                                RegistroNuevo.FechaHoraFin = DateTime.Now;
                                contexto.Entry(RegistroNuevo).State = EntityState.Modified;
                                //contexto.Reg_RegistroEjecucion.Add(RegistroNuevo);
                                await contexto.SaveChangesAsync();
                            }
                        }
                        //await Task.Delay(5000, stoppingToken);
                        Logs.RegistrarEvento(TipoEvento.Informativo, "Fin proceso de registro...");
                        EstablecerEjecucion();
                    }
                    await Task.Delay(10000, stoppingToken);
                }
                catch (Exception Ex)
                {
                    Logs.RegistrarEvento(TipoEvento.Error, Ex);
                    Logs.RegistrarEventoSimple(TipoEvento.Error, DateTime.Now, Ex.ToString());
                }
                finally
                {
                    Ocupado = false;
                }
            }
        }
        private void VolcarHistorico(int IdSegmento)
        {
            //IList<PuertosServidores> dataP = contexto.Inv_PuertosServidores.ToList();
            IList<PuertosServidores> dataP = (from P in contexto.Inv_PuertosServidores
                                              join S in contexto.Inv_Servidores on P.IP equals S.IP
                                              join R in contexto.Reg_RegistroEjecucion on S.IdRegistro equals R.IdRegistro
                                              where R.IdSegmento == IdSegmento
                                              select P).ToList();
            foreach (var result in dataP)
            {
                PuertoServidoresHistorico ServidorResult = mapper.Map<PuertoServidoresHistorico>(result);
                if (ServidorResult != null)
                {
                    contexto.Hist_Inv_PuertosServidores.Add(ServidorResult);
                    contexto.SaveChanges();
                    contexto.Remove(result);
                    contexto.SaveChanges();
                }
            }
            IList<SO> dataSO = (from P in contexto.Inv_SO_Servidores
                                join S in contexto.Inv_Servidores on P.IP equals S.IP
                                join R in contexto.Reg_RegistroEjecucion on S.IdRegistro equals R.IdRegistro
                                where R.IdSegmento == IdSegmento
                                select P).ToList();
            foreach (var result in dataSO)
            {
                SOHistorico ServidorResult = mapper.Map<SOHistorico>(result);
                if (ServidorResult != null)
                {
                    contexto.Hist_Inv_SO_Servidores.Add(ServidorResult);
                    contexto.SaveChanges();
                    contexto.Remove(result);
                    contexto.SaveChanges();
                }
            }
            IList<Servidor> dataS = (from S in contexto.Inv_Servidores
                                     join R in contexto.Reg_RegistroEjecucion on S.IdRegistro equals R.IdRegistro
                                     where R.IdSegmento == IdSegmento
                                     select S).ToList();
            foreach (var result in dataS)
            {
                ServidoresHistorico ServidorResult = mapper.Map<ServidoresHistorico>(result);
                if (ServidorResult != null)
                {
                    contexto.Hist_Inv_Servidores.Add(ServidorResult);
                    contexto.SaveChanges();
                    contexto.Remove(result);
                    contexto.SaveChanges();
                }
            }
        }
        private List<SegmentoRed> EstablecerEjecucion()
        {
            List<SegmentoRed> ListaFin = null;
            var Vnets = contexto.Cnf_SegmentoRed.Where(x => x.Habilitada == true).ToList();
            foreach (var Vnet in Vnets)
            {
                bool EjecutadoHoySeg = contexto.Reg_RegistroEjecucion.Any(x => x.ServicioID == configuracion.ServicioID && x.FechaHoraInicio.Date == DateTime.Now.Date && x.Finalizado == true && x.IdSegmento == Vnet.IdSegmento);
                if (EjecutadoHoySeg == false)
                {
                    if (ListaFin == null)
                    {
                        ListaFin = new List<SegmentoRed>();
                    }
                    ListaFin.Add(Vnet);
                }
            }
            TimeSpan HoraEjecucion = configuracion.HoraEjecucion.TimeOfDay;
            if (ListaFin != null && ListaFin.Count > 0)
            {
                if (DateTime.Now.TimeOfDay > HoraEjecucion)
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
            return ListaFin;
            //            bool EjecutadoHoy = contexto.Reg_RegistroEjecucion.Any(x => x.ServicioID == configuracion.ServicioID && x.FechaHoraInicio.Date == DateTime.Now.Date && x.Finalizado == true);

        }
    }
}
