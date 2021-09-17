using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LCMDB.IISExtractor.Modelos.v1_0
{
    public class Aplicacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAplicacion { get; set; }
        [ForeignKey("SitioWeb")]
        public int IdSitioWeb { get; set; }
        public virtual SitioWeb SitioWeb { get; set; }
        [ForeignKey("AplicacionPool")]
        public int IdAppPool { get; set; }
        public virtual AplicacionPool AplicacionPool { get; set; }
        public virtual string NombrePool { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string IP { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string RutaFisica { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
    }
}
