using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LCMDB.BD.Contextos.LCMDB.Modelos.v1_0
{
    public class RegistroEjecucion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegistro { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string ServicioID { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Detalle { get; set; }
        public int IdSegmento { get; set; }
        public bool Finalizado { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }

    }
}
