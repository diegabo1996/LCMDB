using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyCollection = System.DirectoryServices.PropertyCollection;

namespace LCMDB.SolucionesAuxiliares.IISExtractor
{
    public static class IISDE
    {
        public static void Server()
        {
            using (ServerManager serverManager = new ServerManager(@"\\btbnmw00\c$\Windows\System32\inetsrv\Config\applicationhost.config"))
            {
                string a = "";
            }
        }
        public static void EnumerateProperties(string metabasePath)
        {
            //  metabasePath is of the form "IIS://<servername>/<path>"
            //    for example "IIS://localhost/W3SVC/1/Root/MyVDir" 
            //    or "IIS://localhost/W3SVC/AppPools/MyAppPool"
            Console.WriteLine("\nEnumerating properties for {0}:", metabasePath);

            try
            {
                DirectoryEntry entry = new DirectoryEntry(metabasePath);
                PropertyCollection props = entry.Properties;

                Console.WriteLine(" Total properties = {0}", props.Count);

                foreach (string propName in props.PropertyNames)
                {
                    Console.Write(" {0} =", propName);
                    foreach (object value in entry.Properties[propName])
                    {
                        Console.WriteLine("\t{0} \t({1})", value.ToString(), value.GetType());
                    }
                }
                Console.WriteLine(" Done.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed in EnumeratePath with the following exception: \n{0}", ex.Message);
            }
        }
    }
}
