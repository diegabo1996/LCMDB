using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LCMDB.WSExtractor.Modelos.v1_0
{
    public class ServicioWindows
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdServicioWindows {  get; set; }
        [Column(TypeName = "varchar(15)")]
        public string IP { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string NombreCompleto { get; set; }
        [Column(TypeName = "text")]
        public string Descripcion { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string RutaFisica { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string ModoInicio { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Usuario {  get; set; }
        [Column(TypeName = "varchar(25)")]
        public string Estado { get; set; }
        public int IdProceso { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string TipoProceso { get; set; }
        [ForeignKey("RegistroEjecucion")]
        public int IdRegistro { get; set; }
        public virtual RegistroEjecucion RegistroEjecucion {  get; set; }
        public DateTime FechaHoraRegistro { get; set; }
    }
    public class Servidor
    {
        public string IP { get; set; }
    }
}
