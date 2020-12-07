using LCMDB.BD.Contextos.LCMDB;
using LCMDB.BD.Contextos.LCMDB.Modelos.v1_0;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LCMDB.RegistroEventos.Servidores
{
    public static class RegistroServidores
    {
        private static CMDBContexto contexto = new CMDBContexto();

        public static async Task NuevoServidorAsync(Servidor servidor)
        {
            //contexto.Entry(servidor).State = EntityState.Detached;
            RegistroCambiosServidores Registro = new RegistroCambiosServidores() { IdServidor=servidor.IdServidor, Detalles="Nuevo servidor detectado "+servidor.NombreServidor+" / "+servidor.IP+"!",  FechaRegistro=DateTime.Now, TipoCambio=TipoCambioServidor.ServidorAgregado};
            contexto.Reg_RegistroCambiosServidores.Add(Registro);
            await contexto.SaveChangesAsync();
        }
        public static async Task CambioNombreAsync(Servidor servidor, string AntiguoNombre)
        {
            RegistroCambiosServidores Registro = new RegistroCambiosServidores() { Detalles = "Cambio de nombre de Host de servidor!", IdServidor=servidor.IdServidor, FechaRegistro = DateTime.Now, TipoCambio = TipoCambioServidor.CambioNombreServidor, AntiguoValor=AntiguoNombre, NuevoValor=servidor.NombreServidor };
            contexto.Reg_RegistroCambiosServidores.Add(Registro);
            await contexto.SaveChangesAsync();
        }
    }
}
