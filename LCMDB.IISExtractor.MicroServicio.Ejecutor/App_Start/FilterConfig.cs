using System.Web;
using System.Web.Mvc;

namespace LCMDB.IISExtractor.MicroServicio.Ejecutor
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
