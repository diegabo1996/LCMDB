using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using System.Text;

namespace LCMDB.BD.Contextos.LCMDB.Modelos.v1_0
{
    public class PuertoServidoresHistorico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegistroPuerto { get; set; }
        public int IdPuerto { get; set; }
        public string IP { get; set; }
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
        public DateTime FechaRegistroVolcado { get; set; }
    }
    public class ServidoresHistorico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegistroServidores { get; set;  }
        [Column(TypeName = "varchar(15)")]
        public string IP { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string NombreServidor { get; set; }
        public int IdRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaRegistroVolcado { get; set; }
    }
    public class SOHistorico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegistroSO { get; set; }
        public int IdSORegistro { get; set; }
        public string IP { get; set; }
        public int IdRegistro { get; set; }
        public int Certeza { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string? Nombre { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string? Familia { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string? Generacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaRegistroVolcado { get; set; }
    }
}
