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
    [Migration("20201201180436_UsuariosEjec")]
    partial class UsuariosEjec
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("inv")
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

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
#pragma warning restore 612, 618
        }
    }
}
