using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace LCMDB.IISExtractor.Modelos.v1_0
{
    public class AplicacionPool
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAppPool { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string IP { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string CLR { get; set; }
        public Estado Estado { get; set; }
        public bool THTWOBits {get;set;}
        [Column(TypeName = "varchar(50)")]
        public string ManagedPipeline { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Usuario { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Contrasenia { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaRegistro { get; set; } 
        public DateTime FechaHoraRegistro { get; set; } 
    }
    public enum Estado
    {
        Iniciando=0,
        Iniciado=1,
        Deteneniendo=2,
        Detenido=3,
        Desconocido=4
    }

}
