using LCMDB.WSExtractor.SolucionAuxiliar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LCMDB.WSExtractor.PruebasUnitarias
{
    [TestClass]
    public class WSExtractor
    {
        [TestMethod]
        public void ExtraerServicios()
        {
            WindowsService service= new WindowsService("172.31.4.26");
            var Servicios = service.ExtraerServiciosWMI();
        }
    }
}
