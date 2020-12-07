using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace BCP.NETCore.Base
{
    public class DirectorioActivo
    {
        public bool ValidarUsrContrasena(string Usuario, string Contrasena)
        {
            if (string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Contrasena))
            {
                return false;
            }
            else
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "bancred.com.bo"))
                {
                    return pc.ValidateCredentials(Usuario, Contrasena);
                }
            }
        }
    }
}
