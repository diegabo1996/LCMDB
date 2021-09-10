using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LCMDB.BD.Contextos.LCMDB.Modelos.v1_0
{
    public class Servidor
    {
        [Key]
        [Column(TypeName = "varchar(15)")]
        public string IP { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string NombreServidor { get; set; }
        public int IdRegistro {  get; set; }
        public DateTime FechaRegistro { get; set; }
        public ICollection<RegistroCambiosServidores> RegistroCambiosServidores { get; set; }
        public ICollection<RegistroEnLineaServidores> RegistroEnLineaServidores { get; set; }
        public ICollection<SO> RegistroSOServidores { get; set; }

    }
}
