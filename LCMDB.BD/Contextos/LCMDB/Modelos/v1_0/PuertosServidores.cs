using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using System.Text;

namespace LCMDB.BD.Contextos.LCMDB.Modelos.v1_0
{
    public class PuertosServidores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPuerto { get; set; }
        [ForeignKey("Servidor")]
        public int IdServidor { get; set; }
        public virtual Servidor Servidor { get; set; }
        public short Puerto { get; set; }
        public bool Habilitado { get; set; }
        public ProtocolType TipoProtocolo { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string SistemOperativo { get; set; }
        [Column(TypeName = "varchar(75)")]
        public string Producto { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Version { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }

    }
}
