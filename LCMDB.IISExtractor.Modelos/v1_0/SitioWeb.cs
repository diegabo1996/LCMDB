using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LCMDB.IISExtractor.Modelos.v1_0
{
    public class SitioWeb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSitioWeb { get; set; }
        [ForeignKey("AplicacionPool")]
        public int IdAppPool { get; set; }
        public virtual AplicacionPool AplicacionPool { get; set; }
        public virtual string NombrePool { get;set;  }
        [Column(TypeName = "varchar(15)")]
        public string IP { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Nombre { get; set; } 
        public long IdOnIIS { get; set; }    
        public Estado Estado{ get; set; }
        [Column(TypeName = "varchar(500)")]
        public string RutaFisica { get; set; }
        [ForeignKey("RegistroEjecucion")]
        public int IdRegistro { get; set; }
        public virtual RegistroEjecucion RegistroEjecucion { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
        public ICollection<Vinculante> Vinculantes { get; set; }
        public ICollection<Aplicacion> Aplicaciones { get; set; }

    }
}
