using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Web.Administration;
using System;

namespace LCMDB.PruebasUnitarias.IISExtractor.NET
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (ServerManager sm = ServerManager.OpenRemote("BTBLPD00"))
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
