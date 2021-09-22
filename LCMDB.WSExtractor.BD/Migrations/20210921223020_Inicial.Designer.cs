﻿// <auto-generated />
using System;
using LCMDB.WSExtractor.BD.Contextos.v1_0;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LCMDB.WSExtractor.BD.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210921223020_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("lcmdb")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LCMDB.WSExtractor.Modelos.v1_0.ServicioWindows", b =>
                {
                    b.Property<int>("IdServicioWindows")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(25)");

                    b.Property<DateTime>("FechaHoraRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("IP")
                        .HasColumnType("varchar(15)");

                    b.Property<int>("IdProceso")
                        .HasColumnType("int");

                    b.Property<string>("ModoInicio")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("NombreCompleto")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("RutaFisica")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("TipoProceso")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Usuario")
                        .HasColumnType("varchar(250)");

                    b.HasKey("IdServicioWindows");

                    b.ToTable("ServiciosWindows");
                });
#pragma warning restore 612, 618
        }
    }
}
