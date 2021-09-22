﻿// <auto-generated />
using System;
using LCMDB.IISExtractor.BD.Contextos;
using LCMDB.IISExtractor.BD.Contextos.v1_0;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LCMDB.IISExtractor.BD.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210916232730_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("lcmdb")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LCMDB.IISExtractor.Modelos.v1_0.Aplicacion", b =>
                {
                    b.Property<int>("IdAplicacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaHoraRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("Date");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<int>("IdAppPool")
                        .HasColumnType("int");

                    b.Property<int?>("IdSitioWeb")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("RutaFisica")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("IdAplicacion");

                    b.HasIndex("IdAppPool");

                    b.HasIndex("IdSitioWeb");

                    b.ToTable("Aplicaciones");
                });

            modelBuilder.Entity("LCMDB.IISExtractor.Modelos.v1_0.AplicacionPool", b =>
                {
                    b.Property<int>("IdAppPool")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CLR")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHoraRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("Date");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("ManagedPipeline")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("THTWOBits")
                        .HasColumnType("bit");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("IdAppPool");

                    b.ToTable("GrupoAplicaciones");
                });

            modelBuilder.Entity("LCMDB.IISExtractor.Modelos.v1_0.SitioWeb", b =>
                {
                    b.Property<int>("IdSitioWeb")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHoraRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("Date");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<int>("IdAppPool")
                        .HasColumnType("int");

                    b.Property<int>("IdOnIIS")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("RutaFisica")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("IdSitioWeb");

                    b.HasIndex("IdAppPool");

                    b.ToTable("SitiosWeb");
                });

            modelBuilder.Entity("LCMDB.IISExtractor.Modelos.v1_0.Vinculante", b =>
                {
                    b.Property<int>("IdVinculante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaHoraRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("Date");

                    b.Property<string>("FirmaCertificado")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Host")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("IdSitioWeb")
                        .HasColumnType("int");

                    b.Property<string>("IpVinculante")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Puerto")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TipoEsquema")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("IdVinculante");

                    b.HasIndex("IdSitioWeb");

                    b.ToTable("Vinculantes");
                });

            modelBuilder.Entity("LCMDB.IISExtractor.Modelos.v1_0.Aplicacion", b =>
                {
                    b.HasOne("LCMDB.IISExtractor.Modelos.v1_0.AplicacionPool", "AplicacionPool")
                        .WithMany()
                        .HasForeignKey("IdAppPool")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LCMDB.IISExtractor.Modelos.v1_0.SitioWeb", "SitioWeb")
                        .WithMany()
                        .HasForeignKey("IdSitioWeb")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AplicacionPool");

                    b.Navigation("SitioWeb");
                });

            modelBuilder.Entity("LCMDB.IISExtractor.Modelos.v1_0.SitioWeb", b =>
                {
                    b.HasOne("LCMDB.IISExtractor.Modelos.v1_0.AplicacionPool", "AplicacionPool")
                        .WithMany()
                        .HasForeignKey("IdAppPool")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AplicacionPool");
                });

            modelBuilder.Entity("LCMDB.IISExtractor.Modelos.v1_0.Vinculante", b =>
                {
                    b.HasOne("LCMDB.IISExtractor.Modelos.v1_0.SitioWeb", "SitioWeb")
                        .WithMany()
                        .HasForeignKey("IdSitioWeb")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SitioWeb");
                });
#pragma warning restore 612, 618
        }
    }
}
