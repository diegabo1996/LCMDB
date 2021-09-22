using LCMDB.WSExtractor.Modelos.v1_0;
using LCode.NETCore.Base._5._0.BaseDatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMDB.WSExtractor.BD.Contextos.v1_0
{
    public class Contexto: ConexionContextoBD
    {
        string NombreConexionContexto = "LCMDB.WSExtractor";
        public Contexto()
        {
            Iniciar(NombreConexionContexto);
        }
        public DbSet<ServicioWindows> ServiciosWindows { get; set; }
        public DbSet<RegistroEjecucion> RegistrosEjecucion { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("lcmdb");
            modelBuilder.Entity<ServicioWindows>()
        .HasIndex(p => new { p.IP, p.IdRegistro});
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
