using System;
using System.Collections.Generic;
using System.Text;
using BCP.NETCore.Base;
using LCMDB.BD.Contextos.LCMDB.Modelos.v1_0;
using Microsoft.EntityFrameworkCore;

namespace LCMDB.BD.Contextos.LCMDB
{
    public class CMDBContexto : ConexionBD
    {
        string Contexto = "CMDB";
        public CMDBContexto()
        {
            Iniciar(Contexto);
        }

        public DbSet<Servidor> Inv_Servidores { get; set; }
        public DbSet<PuertosServidores> Inv_PuertosServidores { get; set; }
        public DbSet<SegmentoRed> Cnf_SegmentoRed { get; set; }
        public DbSet<RegistroEjecucion> Reg_RegistroEjecucion { get; set; }
        public DbSet<Usuarios> Cnf_UsuariosEjecucion { get; set; }
        public DbSet<RegistroCambiosServidores> Reg_RegistroCambiosServidores { get; set; }
        public DbSet<RegistroEnLineaServidores> Reg_RegistroEnLineaServidores { get; set; }
        public DbSet<SO> Inv_SO_Servidores { get; set; }
        public DbSet<ServidoresHistorico> Hist_Inv_Servidores { get; set; }
        public DbSet<PuertoServidoresHistorico> Hist_Inv_PuertosServidores { get; set; }
        public DbSet<SOHistorico> Hist_Inv_SO_Servidores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("lcmdb");
            modelBuilder.Entity<ServidoresHistorico>()
            .Property(b => b.FechaRegistroVolcado)
            .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<PuertoServidoresHistorico>()
            .Property(b => b.FechaRegistroVolcado)
            .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<SOHistorico>()
            .Property(b => b.FechaRegistroVolcado)
            .HasDefaultValueSql("getdate()");

        }
    }
}
