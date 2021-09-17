using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LCMDB.IISExtractor.Modelos.v1_0
{
    public class Vinculante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVinculante { get; set; }
        [ForeignKey("SitioWeb")]
        public int IdSitioWeb { get; set; }
        public virtual SitioWeb SitioWeb { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string TipoEsquema { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string IpVinculante { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Puerto { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Host { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string FirmaCertificado { get; set;  }
        [Column(TypeName = "Date")]
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
    }
}
