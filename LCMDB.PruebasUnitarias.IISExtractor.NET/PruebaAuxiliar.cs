using LCMDB.SolucionesAuxiliares.IISExtractor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Web.Administration;
using System;

namespace LCMDB.PruebasUnitarias.IISExtractor.NET
{
    [TestClass]
    public class PruebaAuxiliar
    {
        [TestMethod]
        public void ObtenerSitios()
        {
            RegistrarIIS registrarIIS= new RegistrarIIS("172.31.4.166");
            var Pools = registrarIIS.ObtenerAplicacionPools();
            var SitiosWeb = registrarIIS.ObtenerSitiosWeb();
        }
    }
}
