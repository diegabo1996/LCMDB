using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCMDB.Servicios.IISExtractor.Modelos.v1_0
{
    public class Servidor
    {
        public int Id { get; set; }
        public string NombreServidor { get; set; }
        public string Ip { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
