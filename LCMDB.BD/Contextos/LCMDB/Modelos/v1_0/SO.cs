﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LCMDB.BD.Contextos.LCMDB.Modelos.v1_0
{
    public class SO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSORegistro { get; set; }
        [ForeignKey("Servidor")]
        public string IP { get; set; }
        public virtual Servidor Servidor { get; set; }
        public int IdRegistro { get; set; }
        public int Certeza { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string? Nombre { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string? Familia { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string? Generacion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
