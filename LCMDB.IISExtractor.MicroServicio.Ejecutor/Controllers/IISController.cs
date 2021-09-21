using LCMDB.IISExtractor.Modelos.v1_0;
using LCMDB.SolucionesAuxiliares.IISExtractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LCMDB.IISExtractor.MicroServicio.Ejecutor.Controllers
{
    public class IISController : ApiController
    {
        public ServidorIIS Post([FromBody] string IP)
        {
            RegistrarIIS registrarIIS = new RegistrarIIS(IP);
            ServidorIIS servidorIIS= new ServidorIIS();
            servidorIIS.AplicacionesPools=registrarIIS.ObtenerAplicacionPools();
            servidorIIS.SitiosWeb = registrarIIS.ObtenerSitiosWeb();
            return servidorIIS;
        }
    }
}
