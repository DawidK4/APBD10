﻿// <auto-generated />
using Cwiczenia10.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cwiczenia10.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240605195240_AddedCategoryEntity")]
    partial class AddedCategoryEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AccountProduct", b =>
                {
                    b.Property<int>("AccountsPkAccount")
                        .HasColumnType("int");

                    b.Property<int>("ProductsPkProduct")
                        .HasColumnType("int");

                    b.HasKey("AccountsPkAccount", "ProductsPkProduct");

                    b.HasIndex("ProductsPkProduct");

                    b.ToTable("AccountProduct");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Account", b =>
                {
                    b.Property<int>("PkAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_account");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkAccount"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("FkRole")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("phone");

                    b.HasKey("PkAccount");

                    b.HasIndex("FkRole");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Category", b =>
                {
                    b.Property<int>("PkCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_category");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkCategory"));

                    b.Property<int?>("CategoryPkCategory")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<int?>("ProductPkProduct")
                        .HasColumnType("int");

                    b.HasKey("PkCategory");

                    b.HasIndex("CategoryPkCategory");

                    b.HasIndex("ProductPkProduct");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Product", b =>
                {
                    b.Property<int>("PkProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_product");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkProduct"));

                    b.Property<decimal>("Depth")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("depth");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("height");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("weight");

                    b.Property<decimal>("Width")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("width");

                    b.HasKey("PkProduct");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Role", b =>
                {
                    b.Property<int>("PkRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_role");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkRole"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("PkRole");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("AccountProduct", b =>
                {
                    b.HasOne("Cwiczenia10.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountsPkAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cwiczenia10.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsPkProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cwiczenia10.Models.Account", b =>
                {
                    b.HasOne("Cwiczenia10.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("FkRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Category", b =>
                {
                    b.HasOne("Cwiczenia10.Models.Category", null)
                        .WithMany("Categories")
                        .HasForeignKey("CategoryPkCategory");

                    b.HasOne("Cwiczenia10.Models.Product", null)
                        .WithMany("Categories")
                        .HasForeignKey("ProductPkProduct");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Category", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Product", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
