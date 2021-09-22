using LCMDB.BD.Contextos.LCMDB;
using LCMDB.BD.Contextos.LCMDB.Modelos.v1_0;
using LCMDB.IISExtractor.BD.Contextos;
using LCMDB.IISExtractor.BD.Contextos.v1_0;
using LCMDB.SolucionesAuxiliares.IISExtractor;
using LCode.NETCore.Base._5._0.Logs;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using RegistroEjecucion = LCMDB.IISExtractor.Modelos.v1_0.RegistroEjecucion;

namespace LCMDB.IISExtractor.ServicioEjecutor.ConsumidoresMQ
{
    public class IISExtractorConsumidor : IConsumer<Servidor>
    {
        private readonly Contexto _context = new Contexto();
        public async Task Consume(ConsumeContext<Servidor> context)
        {
            try
            {
                Servidor servidor = context.Message;
                RegistrarIIS registrarIIS = new RegistrarIIS(servidor.IP);
                var Pools = registrarIIS.ObtenerAplicacionPools();
                RegistroEjecucion RegEJec = new RegistroEjecucion() { IP=servidor.IP, FechaHoraInicio=DateTime.Now, ServicioID="IISSR", Detalle="Extraccion de información IIS."};
                _context.RegistrosEjecucion.Add(RegEJec);
                await _context.SaveChangesAsync();
                foreach (var pool in Pools)
                {
                    pool.IdRegistro = RegEJec.IdRegistro;
                    pool.IP = servidor.IP;
                    _context.GrupoAplicaciones.Add(pool);
                    await _context.SaveChangesAsync();
                }
                //Evento.Depuracion(Pools);
                var SitiosWeb = registrarIIS.ObtenerSitiosWeb();
                foreach (var Sitio in SitiosWeb)
                {
                    try
                    {
                        Sitio.IdRegistro = RegEJec.IdRegistro;
                        Sitio.IdAppPool = Pools.Find(x => x.Nombre == Sitio.NombrePool).IdAppPool;
                        Sitio.IP = servidor.IP;
                        foreach (var app in Sitio.Aplicaciones)
                        {
                            app.IP = servidor.IP;
                            app.IdAppPool = Pools.Find(x => x.Nombre == app.NombrePool).IdAppPool;
                        }
                        //Evento.Depuracion(Sitio);
                        _context.SitiosWeb.Add(Sitio);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Evento.Error(ex);
                    }
                }
                RegEJec.Finalizado = true;
                RegEJec.FechaHoraFin = DateTime.Now;
                _context.Entry(RegEJec).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Evento.Error(ex);
            }
        }
    }
}
