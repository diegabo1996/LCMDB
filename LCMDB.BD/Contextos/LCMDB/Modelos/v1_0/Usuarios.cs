using BCP.NETCore.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LCMDB.BD.Contextos.LCMDB.Modelos.v1_0
{
    public enum TipoUsuario
    {
        ControladorDominio,
        DominioNormal,
        Usuario,
        UsuarioDMZ
    }
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Dominio { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string NombreUsuario { get; set; }
        private string Contrasenia { get; set; }
        [Encrypted(nameof(Contrasenia))]
        public string ContraseniaUsuario {
            get => Seguridad.T3DES.DecryptKeyTripleDes(Contrasenia);
            set => Contrasenia=Seguridad.T3DES.EncryptKeyTripleDes(value);
        }
        public TipoUsuario TipoUsuario { get; set; }
        public DateTime FechaRegistro {get; set; }
        public DateTime FechaModificacion { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    sealed class EncryptedAttribute : Attribute
    {
        readonly string _fieldName;

        public EncryptedAttribute(string fieldName)
        {
            _fieldName = fieldName;
        }

        public string FieldName => _fieldName;
    }
}
