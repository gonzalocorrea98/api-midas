﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MidasAPI.Models.Data;

#nullable disable

namespace MidasAPI.Migrations
{
    [DbContext(typeof(AlmacenContext))]
    [Migration("20230103225643_cf1")]
    partial class cf1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MidasAPI.Models.Data.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("TipoProductoID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoProductoID");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("MidasAPI.Models.Data.TipoProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoProductos");
                });

            modelBuilder.Entity("MidasAPI.Models.Data.Producto", b =>
                {
                    b.HasOne("MidasAPI.Models.Data.TipoProducto", "TipoProducto")
                        .WithMany()
                        .HasForeignKey("TipoProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoProducto");
                });
#pragma warning restore 612, 618
        }
    }
}
