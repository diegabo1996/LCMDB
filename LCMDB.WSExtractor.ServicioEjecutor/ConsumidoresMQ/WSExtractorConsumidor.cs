using LCMDB.WSExtractor.BD.Contextos.v1_0;
using LCMDB.WSExtractor.Modelos.v1_0;
using LCMDB.WSExtractor.SolucionAuxiliar;
using LCode.NETCore.Base._5._0.Logs;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMDB.WSExtractor.ServicioEjecutor.ConsumidoresMQ
{
    public class WSExtractorConsumidor : IConsumer<Servidor>
    {
        private readonly Contexto _context = new Contexto();
        private Servidor _NombreHost;
        public async Task Consume(ConsumeContext<Servidor> context)
        {
            try
            {
                _NombreHost = context.Message;
                WindowsService ws = new WindowsService(_NombreHost.IP);
                var ListaWs = ws.ExtraerServiciosWMI();
                RegistroEjecucion RegEJec = new RegistroEjecucion() { IP = _NombreHost.IP, FechaHoraInicio = DateTime.Now, ServicioID = "WSSRV", Detalle = "Extraccion de Servicios Windows." };
                _context.RegistrosEjecucion.Add(RegEJec);
                await _context.SaveChangesAsync();

                foreach (var item in ListaWs)
                {
                    item.IP = _NombreHost.IP;
                    item.IdRegistro = RegEJec.IdRegistro;
                    _context.ServiciosWindows.Add(item);
                    await _context.SaveChangesAsync();
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
