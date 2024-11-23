﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropiedadesWEB.Data;

#nullable disable

namespace _PropertyManager.Migrations
{
    [DbContext(typeof(PropiedadesContext))]
    partial class PropiedadesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PropiedadWEB.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PropiedadesWEB.Models.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Deposito")
                        .HasColumnType("int");

                    b.Property<string>("FechaFin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaInicio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InquilinoId")
                        .HasColumnType("int");

                    b.Property<int>("PropiedadId")
                        .HasColumnType("int");

                    b.Property<string>("Terminos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InquilinoId");

                    b.HasIndex("PropiedadId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("PropiedadesWEB.Models.Inquilino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropiedadId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PropiedadId");

                    b.ToTable("Inquilinos");
                });

            modelBuilder.Entity("PropiedadesWEB.Models.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContratoId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContratoId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("PropiedadesWEB.Models.Propiedad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Disponible")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroHabitaciones")
                        .HasColumnType("int");

                    b.Property<int>("PrecioAlquiler")
                        .HasColumnType("int");

                    b.Property<string>("TipoPropiedad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Propiedades");
                });

            modelBuilder.Entity("PropiedadesWEB.Models.Contrato", b =>
                {
                    b.HasOne("PropiedadesWEB.Models.Inquilino", "Inquilino")
                        .WithMany("Contratos")
                        .HasForeignKey("InquilinoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PropiedadesWEB.Models.Propiedad", "Propiedad")
                        .WithMany("Contratos")
                        .HasForeignKey("PropiedadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Inquilino");

                    b.Navigation("Propiedad");
                });

            modelBuilder.Entity("PropiedadesWEB.Models.Inquilino", b =>
                {
                    b.HasOne("PropiedadesWEB.Models.Propiedad", "Propiedad")
                        .WithMany("Inquilinos")
                        .HasForeignKey("PropiedadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Propiedad");
                });

            modelBuilder.Entity("PropiedadesWEB.Models.Pago", b =>
                {
                    b.HasOne("PropiedadesWEB.Models.Contrato", "Contrato")
                        .WithMany("Pagos")
                        .HasForeignKey("ContratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrato");
                });

            modelBuilder.Entity("PropiedadesWEB.Models.Contrato", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("PropiedadesWEB.Models.Inquilino", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("PropiedadesWEB.Models.Propiedad", b =>
                {
                    b.Navigation("Contratos");

                    b.Navigation("Inquilinos");
                });
#pragma warning restore 612, 618
        }
    }
}
