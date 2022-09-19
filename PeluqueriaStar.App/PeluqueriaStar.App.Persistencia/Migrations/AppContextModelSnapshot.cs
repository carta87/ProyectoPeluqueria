﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeluqueriaStar.App.Persistencia;

namespace PeluqueriaStar.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PeluqueriaStar.App.Dominio.HorarioEstelista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool>("Disponibilidad")
                        .HasColumnType("bit");

                    b.Property<int?>("EstelistaId")
                        .HasColumnType("int");

                    b.Property<string>("Fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Horario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstelistaId");

                    b.ToTable("HorarioEstelista");
                });

            modelBuilder.Entity("PeluqueriaStar.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstadoSalud")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persona");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("PeluqueriaStar.App.Dominio.ServiciosOfrecer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstelistaId")
                        .HasColumnType("int");

                    b.Property<int>("ValorServicio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstelistaId");

                    b.ToTable("ServiciosOfrecer");
                });

            modelBuilder.Entity("PeluqueriaStar.App.Dominio.Administrador", b =>
                {
                    b.HasBaseType("PeluqueriaStar.App.Dominio.Persona");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("EstelistaId")
                        .HasColumnType("int")
                        .HasColumnName("Administrador_EstelistaId");

                    b.Property<int?>("HorarioEstelistaId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiciosOfrecerId")
                        .HasColumnType("int");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstelistaId");

                    b.HasIndex("HorarioEstelistaId");

                    b.HasIndex("ServiciosOfrecerId");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("PeluqueriaStar.App.Dominio.Cliente", b =>
                {
                    b.HasBaseType("PeluqueriaStar.App.Dominio.Persona");

                    b.Property<int>("CantidadCitas")
                        .HasColumnType("int");

                    b.Property<string>("Dirrecion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int?>("EstelistaId")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<bool>("Membresia")
                        .HasColumnType("bit");

                    b.HasIndex("EstelistaId");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("PeluqueriaStar.App.Dominio.Estelista", b =>
                {
                    b.HasBaseType("PeluqueriaStar.App.Dominio.Persona");

                    b.Property<string>("TarjetaProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Estelista");
                });

            modelBuilder.Entity("PeluqueriaStar.App.Dominio.HorarioEstelista", b =>
                {
                    b.HasOne("PeluqueriaStar.App.Dominio.Cliente", null)
                        .WithMany("HorarioEstelista")
                        .HasForeignKey("ClienteId");

                    b.HasOne("PeluqueriaStar.App.Dominio.Estelista", null)
                        .WithMany("HorarioEstelista")
                        .HasForeignKey("EstelistaId");
                });

            modelBuilder.Entity("PeluqueriaStar.App.Dominio.ServiciosOfrecer", b =>
                {
                    b.HasOne("PeluqueriaStar.App.Dominio.Cliente", null)
                        .WithMany("ServiciosOfrecer")
                        .HasForeignKey("ClienteId");

                    b.HasOne("PeluqueriaStar.App.Dominio.Estelista", null)
                        .WithMany("ServiciosOfrecer")
                        .HasForeignKey("EstelistaId");
                });

            modelBuilder.Entity("PeluqueriaStar.App.Dominio.Administrador", b =>
                {
                    b.HasOne("PeluqueriaStar.App.Dominio.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("PeluqueriaStar.App.Dominio.Estelista", "Estelista")
                        .WithMany()
                        .HasForeignKey("EstelistaId");

                    b.HasOne("PeluqueriaStar.App.Dominio.HorarioEstelista", "HorarioEstelista")
                        .WithMany()
                        .HasForeignKey("HorarioEstelistaId");

                    b.HasOne("PeluqueriaStar.App.Dominio.ServiciosOfrecer", "ServiciosOfrecer")
                        .WithMany()
                        .HasForeignKey("ServiciosOfrecerId");

                    b.Navigation("Cliente");

                    b.Navigation("Estelista");

                    b.Navigation("HorarioEstelista");

                    b.Navigation("ServiciosOfrecer");
                });

            modelBuilder.Entity("PeluqueriaStar.App.Dominio.Cliente", b =>
                {
                    b.HasOne("PeluqueriaStar.App.Dominio.Estelista", "Estelista")
                        .WithMany()
                        .HasForeignKey("EstelistaId");

                    b.Navigation("Estelista");
                });

            modelBuilder.Entity("PeluqueriaStar.App.Dominio.Cliente", b =>
                {
                    b.Navigation("HorarioEstelista");

                    b.Navigation("ServiciosOfrecer");
                });

            modelBuilder.Entity("PeluqueriaStar.App.Dominio.Estelista", b =>
                {
                    b.Navigation("HorarioEstelista");

                    b.Navigation("ServiciosOfrecer");
                });
#pragma warning restore 612, 618
        }
    }
}
