using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LCMDB.BD.Contextos.LCMDB.Modelos.v1_0
{
    public class SegmentoRed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSegmento { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string IpRed { get; set; }
        [Required]
        [Column(TypeName = "varchar(2)")]
        public string MascaraSegmento { get; set; }
        public bool Habilitada { get; set; }
    }
}
