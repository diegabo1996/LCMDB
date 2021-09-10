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
        public string IP { get; set; }
        public virtual Servidor Servidor { get; set; }
        public int IdRegistro { get; set; }
        public int Puerto { get; set; }
        public bool Habilitado { get; set; }
        public ProtocolType TipoProtocolo { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string SistemOperativo { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Producto { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Version { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
