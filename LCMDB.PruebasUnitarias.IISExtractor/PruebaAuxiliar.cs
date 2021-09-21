using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection.PortableExecutable;
using System;
using LCMDB.SolucionesAuxiliares.IISExtractor;
using Microsoft.Web.Administration;

namespace LCMDB.PruebasUnitarias.IISExtractor
{
    [TestClass]
    public class PruebaAuxiliar
    {
        [TestMethod]
        public void ExtractorIIs()
        {

            //IISDE.EnumerateProperties("IIS://172.31.4.119/W3SVC/1/Root");
            //EnumerateProperties("IIS://172.31.4.119/W3SVC/1/Root");

            //System.DirectoryServices.DirectoryEntry VDir = new System.DirectoryServices.DirectoryEntry("IIS://172.31.4.119/W3SVC/AppPools");
            //string VariableX = "";
            //foreach (System.DirectoryServices.DirectoryEntry AppPool in VDir.Children)
            //{
            //    string Nombre = AppPool.Name;
            //}

            //DirectoryEntry root = DirectoryEntry("IIS://172.31.4.166/W3SVC/AppPools");



            ////ServerManager ResultadoServidorA = ServerManager.OpenRemote("172.31.4.166");
            ////SiteCollection sitesX = ResultadoServidorA.Sites;
            using (ServerManager ResultadoServidor = new ServerManager(@"\\btbnmw00\IISSharedConfig\applicationHost.config"))
            {
                SiteCollection sites = ResultadoServidor.Sites;
                if (sites != null)
                {

                }
            }
        }
        //void EnumerateProperties(string metabasePath)
        //{
        //    //  metabasePath is of the form "IIS://<servername>/<path>"
        //    //    for example "IIS://localhost/W3SVC/1/Root/MyVDir" 
        //    //    or "IIS://localhost/W3SVC/AppPools/MyAppPool"
        //    Console.WriteLine("\nEnumerating properties for {0}:", metabasePath);

        //    try
        //    {
        //        System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry(metabasePath);
        //        PropertyCollection props = entry.Properties;

        //        Console.WriteLine(" Total properties = {0}", props.Count);

        //        foreach (string propName in props.PropertyNames)
        //        {
        //            Console.Write(" {0} =", propName);
        //            foreach (object value in entry.Properties[propName])
        //            {
        //                Console.WriteLine("\t{0} \t({1})", value.ToString(), value.GetType());
        //            }
        //        }
        //        Console.WriteLine(" Done.");

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Failed in EnumeratePath with the following exception: \n{0}", ex.Message);
        //    }
        //}
    }
}
