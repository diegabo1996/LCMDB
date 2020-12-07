using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LCMDB.BD.Contextos.LCMDB.Modelos.v1_0
{
    public class RegistroEnLineaServidores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegistroEnLinea { get; set; }
        public bool EnLinea { get; set; }
        public DateTime FechaRegistro { get; set; }
        [ForeignKey("Servidor")]
        public int IdServidor { get; set; }
        public virtual Servidor Servidor { get; set; }
    }
}
