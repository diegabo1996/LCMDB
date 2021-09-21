using System;
using System.Collections.Generic;
using System.Text;

namespace LCMDB.IISExtractor.Modelos.v1_0
{
    public class ServidorIIS
    {
        public List<AplicacionPool> AplicacionesPools {  get; set; }
        public List<SitioWeb> SitiosWeb { get; set; }
    }
}
