using LCMDB.BD.Contextos.LCMDB.Modelos.v1_0;
using LCode.NETCore.Base._5._0.Configuracion;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCMDB.IISExtractor.MicroServicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudExtraccionIISController : ControllerBase
    {
        private readonly IBus _bus;
        public SolicitudExtraccionIISController(IBus bus)
        {
            _bus = bus;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Servidor Solicitud)
        {
            if (Solicitud != null)
            {
                Api Api = new Api();
                //string ServicioVivo = Api.GetRaw(BaseConfiguracion.ObtenerValor("ConfigMQ:ServicioEjecutor"));
                string ServidorMQ = BaseConfiguracion.ObtenerValor("ConfigMQ:RabbitMQ:Servidor");
                string MQ = BaseConfiguracion.ObtenerValor("ConfigMQ:RabbitMQ:Cola");
                Uri uri = new Uri("rabbitmq://" + ServidorMQ + "/" + MQ + "");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send<Servidor>(Solicitud);
                return Ok();
            }
            return BadRequest();
        }
    }
}
