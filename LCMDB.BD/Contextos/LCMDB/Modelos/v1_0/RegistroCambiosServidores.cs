using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LCMDB.BD.Contextos.LCMDB.Modelos.v1_0
{
    public enum TipoCambioServidor
    {
        ServidorAgregado,
        CambioNombreServidor
    }
    public class RegistroCambiosServidores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCambio { get; set; }
        [Required]
        public TipoCambioServidor TipoCambio { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? AntiguoValor { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? NuevoValor { get; set; }
        [Column(TypeName = "text")]
        public string? Detalles { get; set; }
        public DateTime FechaRegistro { get; set; }
        [ForeignKey("Servidor")]
        public int IdServidor { get; set; }
        public virtual Servidor Servidor { get; set; }
    }
}
