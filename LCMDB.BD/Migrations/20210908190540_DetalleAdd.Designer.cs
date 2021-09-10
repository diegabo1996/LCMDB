﻿// <auto-generated />
using System;
using LCMDB.BD.Contextos.LCMDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LCMDB.BD.Migrations
{
    [DbContext(typeof(CMDBContexto))]
    [Migration("20210908190540_DetalleAdd")]
    partial class DetalleAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("lcmdb")
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.PuertoServidoresHistorico", b =>
                {
                    b.Property<int>("IdRegistroPuerto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistroVolcado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPuerto")
                        .HasColumnType("int");

                    b.Property<int>("IdRegistro")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Producto")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Puerto")
                        .HasColumnType("int");

                    b.Property<string>("SistemOperativo")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("TipoProtocolo")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .HasColumnType("varchar(250)");

                    b.HasKey("IdRegistroPuerto");

                    b.ToTable("Hist_Inv_PuertosServidores");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.PuertosServidores", b =>
                {
                    b.Property<int>("IdPuerto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("IP")
                        .HasColumnType("varchar(15)");

                    b.Property<int>("IdRegistro")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Producto")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Puerto")
                        .HasColumnType("int");

                    b.Property<string>("SistemOperativo")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("TipoProtocolo")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .HasColumnType("varchar(250)");

                    b.HasKey("IdPuerto");

                    b.HasIndex("IP");

                    b.ToTable("Inv_PuertosServidores");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.RegistroCambiosServidores", b =>
                {
                    b.Property<int>("IdCambio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AntiguoValor")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Detalles")
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NuevoValor")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ServidorIP")
                        .HasColumnType("varchar(15)");

                    b.Property<int>("TipoCambio")
                        .HasColumnType("int");

                    b.HasKey("IdCambio");

                    b.HasIndex("ServidorIP");

                    b.ToTable("Reg_RegistroCambiosServidores");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.RegistroEjecucion", b =>
                {
                    b.Property<int>("IdRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Detalle")
                        .HasColumnType("varchar(5)");

                    b.Property<DateTime>("FechaHoraFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaHoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Finalizado")
                        .HasColumnType("bit");

                    b.Property<string>("ServicioID")
                        .HasColumnType("varchar(5)");

                    b.HasKey("IdRegistro");

                    b.ToTable("Reg_RegistroEjecucion");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.RegistroEnLineaServidores", b =>
                {
                    b.Property<int>("IdRegistroEnLinea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("EnLinea")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("IP")
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdRegistroEnLinea");

                    b.HasIndex("IP");

                    b.ToTable("Reg_RegistroEnLineaServidores");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.SO", b =>
                {
                    b.Property<int>("IdSORegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Certeza")
                        .HasColumnType("int");

                    b.Property<string>("Familia")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Generacion")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("IP")
                        .HasColumnType("varchar(15)");

                    b.Property<int>("IdRegistro")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(250)");

                    b.HasKey("IdSORegistro");

                    b.HasIndex("IP");

                    b.ToTable("Inv_SO_Servidores");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.SOHistorico", b =>
                {
                    b.Property<int>("IdRegistroSO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Certeza")
                        .HasColumnType("int");

                    b.Property<string>("Familia")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistroVolcado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Generacion")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdRegistro")
                        .HasColumnType("int");

                    b.Property<int>("IdSORegistro")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(250)");

                    b.HasKey("IdRegistroSO");

                    b.ToTable("Hist_Inv_SO_Servidores");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.SegmentoRed", b =>
                {
                    b.Property<int>("IdSegmento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Habilitada")
                        .HasColumnType("bit");

                    b.Property<string>("IpRed")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MascaraSegmento")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.HasKey("IdSegmento");

                    b.ToTable("Cnf_SegmentoRed");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.Servidor", b =>
                {
                    b.Property<string>("IP")
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdRegistro")
                        .HasColumnType("int");

                    b.Property<string>("NombreServidor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("IP");

                    b.ToTable("Inv_Servidores");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.ServidoresHistorico", b =>
                {
                    b.Property<int>("IdRegistroServidores")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistroVolcado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("IP")
                        .HasColumnType("varchar(15)");

                    b.Property<int>("IdRegistro")
                        .HasColumnType("int");

                    b.Property<string>("NombreServidor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdRegistroServidores");

                    b.ToTable("Hist_Inv_Servidores");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ContraseniaUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dominio")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.ToTable("Cnf_UsuariosEjecucion");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.PuertosServidores", b =>
                {
                    b.HasOne("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.Servidor", "Servidor")
                        .WithMany()
                        .HasForeignKey("IP");

                    b.Navigation("Servidor");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.RegistroCambiosServidores", b =>
                {
                    b.HasOne("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.Servidor", null)
                        .WithMany("RegistroCambiosServidores")
                        .HasForeignKey("ServidorIP");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.RegistroEnLineaServidores", b =>
                {
                    b.HasOne("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.Servidor", "Servidor")
                        .WithMany("RegistroEnLineaServidores")
                        .HasForeignKey("IP");

                    b.Navigation("Servidor");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.SO", b =>
                {
                    b.HasOne("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.Servidor", "Servidor")
                        .WithMany("RegistroSOServidores")
                        .HasForeignKey("IP");

                    b.Navigation("Servidor");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.Servidor", b =>
                {
                    b.Navigation("RegistroCambiosServidores");

                    b.Navigation("RegistroEnLineaServidores");

                    b.Navigation("RegistroSOServidores");
                });
#pragma warning restore 612, 618
        }
    }
}
