// <auto-generated />
using System;
using MenuRestAPI_Marcoratti.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MenuRestAPI_Marcoratti.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210723133057_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("MenuRestAPI_Marcoratti.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("MenuRestAPI_Marcoratti.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Categoryid")
                        .HasColumnType("int");

                    b.Property<float>("amount")
                        .HasColumnType("float");

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("id");

                    b.HasIndex("Categoryid");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("MenuRestAPI_Marcoratti.Models.Product", b =>
                {
                    b.HasOne("MenuRestAPI_Marcoratti.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("Categoryid");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MenuRestAPI_Marcoratti.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
