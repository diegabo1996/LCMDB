using LCMDB.BD.Contextos.LCMDB;
using LCMDB.BD.Contextos.LCMDB.Modelos.v1_0;
using MassTransit;
using System.Threading.Tasks;

namespace LCMDB.IISExtractor.ServicioEjecutor.ConsumidoresMQ
{
    public class IISExtractorConsumidor : IConsumer<Servidor>
    {
        private readonly CMDBContexto _context = new CMDBContexto();
        public async Task Consume(ConsumeContext<Servidor> context)
        {
            
        }
    }
}
