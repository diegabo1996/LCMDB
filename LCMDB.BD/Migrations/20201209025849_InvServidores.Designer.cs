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
    [Migration("20201209025849_InvServidores")]
    partial class InvServidores
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("lcmdb")
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.PuertosServidores", b =>
                {
                    b.Property<int>("IdPuerto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<int>("IdServidor")
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

                    b.HasIndex("IdServidor");

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

                    b.Property<int>("IdServidor")
                        .HasColumnType("int");

                    b.Property<string>("NuevoValor")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TipoCambio")
                        .HasColumnType("int");

                    b.HasKey("IdCambio");

                    b.HasIndex("IdServidor");

                    b.ToTable("Reg_RegistroCambiosServidores");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.RegistroEjecucion", b =>
                {
                    b.Property<int>("IdRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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

                    b.Property<int>("IdServidor")
                        .HasColumnType("int");

                    b.HasKey("IdRegistroEnLinea");

                    b.HasIndex("IdServidor");

                    b.ToTable("Reg_RegistroEnLineaServidores");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.SO", b =>
                {
                    b.Property<int>("IdRegSO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Certeza")
                        .HasColumnType("int");

                    b.Property<string>("Familia")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Generacion")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("IdServidor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(250)");

                    b.HasKey("IdRegSO");

                    b.HasIndex("IdServidor");

                    b.ToTable("Inv_SO_Servidores");
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
                    b.Property<int>("IdServidor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("NombreServidor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdServidor");

                    b.ToTable("Inv_Servidores");
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
                        .HasForeignKey("IdServidor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servidor");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.RegistroCambiosServidores", b =>
                {
                    b.HasOne("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.Servidor", "Servidor")
                        .WithMany("RegistroCambiosServidores")
                        .HasForeignKey("IdServidor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servidor");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.RegistroEnLineaServidores", b =>
                {
                    b.HasOne("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.Servidor", "Servidor")
                        .WithMany("RegistroEnLineaServidores")
                        .HasForeignKey("IdServidor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servidor");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.SO", b =>
                {
                    b.HasOne("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.Servidor", "Servidor")
                        .WithMany()
                        .HasForeignKey("IdServidor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servidor");
                });

            modelBuilder.Entity("LCMDB.BD.Contextos.LCMDB.Modelos.v1_0.Servidor", b =>
                {
                    b.Navigation("RegistroCambiosServidores");

                    b.Navigation("RegistroEnLineaServidores");
                });
#pragma warning restore 612, 618
        }
    }
}
