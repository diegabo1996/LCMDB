using LCMDB.BD.Contextos.LCMDB;
using LCMDB.BD.Contextos.LCMDB.Modelos.v1_0;
using LCMDB.IISExtractor.BD.Contextos;
using LCMDB.SolucionesAuxiliares.IISExtractor;
using LCode.NETCore.Base._5._0.Logs;
using MassTransit;
using System;
using System.Threading.Tasks;

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
                foreach (var pool in Pools)
                {
                    pool.IP = servidor.IP;
                    _context.GrupoAplicaciones.Add(pool);
                    await _context.SaveChangesAsync();
                }
                var SitiosWeb = registrarIIS.ObtenerSitiosWeb();
                foreach (var Sitio in SitiosWeb)
                {
                    Sitio.IdAppPool = Pools.Find(x => x.Nombre == Sitio.NombrePool).IdAppPool;
                    Sitio.IP = servidor.IP;
                    foreach (var app in Sitio.Aplicaciones)
                    {
                        app.IP = servidor.IP;
                        app.IdAppPool = Pools.Find(x => x.Nombre == app.NombrePool).IdAppPool;
                    }
                    _context.SitiosWeb.Add(Sitio);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Evento.Error(ex);
            }
        }
    }
}
