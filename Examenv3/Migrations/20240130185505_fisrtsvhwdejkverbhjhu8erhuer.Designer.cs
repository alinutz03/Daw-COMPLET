﻿// <auto-generated />
using Examenv3.ContextModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examenv3.Migrations
{
    [DbContext(typeof(EmisiuneContext))]
    [Migration("20240130185505_fisrtsvhwdejkverbhjhu8erhuer")]
    partial class fisrtsvhwdejkverbhjhu8erhuer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Examenv3.Models.CANAL_TV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdresaSediu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CanaleTV");
                });

            modelBuilder.Entity("Examenv3.Models.EMISIUNE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnulLansarii")
                        .HasColumnType("int");

                    b.Property<int>("CanalTVId")
                        .HasColumnType("int");

                    b.Property<string>("Gen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titlu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CanalTVId");

                    b.ToTable("Emisiuni");
                });

            modelBuilder.Entity("Examenv3.Models.EMISIUNE", b =>
                {
                    b.HasOne("Examenv3.Models.CANAL_TV", "CanalTV")
                        .WithMany()
                        .HasForeignKey("CanalTVId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CanalTV");
                });
#pragma warning restore 612, 618
        }
    }
}
