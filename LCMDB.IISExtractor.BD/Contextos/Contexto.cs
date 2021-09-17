using LCMDB.IISExtractor.Modelos.v1_0;
using LCode.NETCore.Base._5._0.BaseDatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMDB.IISExtractor.BD.Contextos
{
    public class Contexto: ConexionContextoBD
    {
        string NombreConexionContexto = "LCMDB.IISExtractor";
        public Contexto()
        {
            Iniciar(NombreConexionContexto);
        }
        public DbSet<AplicacionPool> GrupoAplicaciones { get; set; }
        public DbSet<SitioWeb> SitiosWeb { get; set; }
        public DbSet<Vinculante> Vinculantes { get; set; }
        public DbSet<Aplicacion> Aplicaciones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
            modelBuilder.Entity<AplicacionPool>().Property(m => m.Usuario).IsRequired(false);
            modelBuilder.Entity<AplicacionPool>().Property(m => m.Contrasenia).IsRequired(false);
            modelBuilder.Entity<Vinculante>().Property(m => m.FirmaCertificado).IsRequired(false);
            modelBuilder.Entity<Vinculante>().Property(m => m.Host).IsRequired(false);
            modelBuilder.Entity<Vinculante>().Property(m => m.Puerto).IsRequired(false);
            modelBuilder.HasDefaultSchema("lcmdb");
            //modelBuilder.Entity<ServidoresHistorico>()
            //.Property(b => b.FechaRegistroVolcado)
            //.HasDefaultValueSql("getdate()");
            //modelBuilder.Entity<PuertoServidoresHistorico>()
            //.Property(b => b.FechaRegistroVolcado)
            //.HasDefaultValueSql("getdate()");
            //modelBuilder.Entity<SOHistorico>()
            //.Property(b => b.FechaRegistroVolcado)
            //.HasDefaultValueSql("getdate()");

        }
    }
}
