using LCMDB.SolucionesAuxiliares.IISExtractor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LCMDB.PruebasUnitarias.IISExtractor
{
    [TestClass]
    public class PruebaAuxiliar
    {
        [TestMethod]
        public void ExtractorIIs()
        {
            ObtenerSitios.Remoto("BTBNMW00");
        }
    }
}
