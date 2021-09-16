using Microsoft.Web.Administration;
using System;
using System.Globalization;

namespace LCMDB.SolucionesAuxiliares.IISExtractor
{
    public class ObtenerSitios
    {
        public static void Remoto(string IP)
        {

            using (ServerManager sm = ServerManager.OpenRemote(IP))
            {
                int counter = 1;
                foreach (var site in sm.Sites)
                {
                    //Console.Write(String.Format(CultureInfo.InvariantCulture, "Site number {0} : {1}{2}", counter.ToString(), site.Name, Environment.NewLine));
                    //counter++;
                }
            }
        }
    }
}
