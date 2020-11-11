﻿// <auto-generated />
using DanfossTestApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DanfossTestApplication.Migrations
{
    [DbContext(typeof(TestApplicationDataContext))]
    partial class TestApplicationDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DanfossTestApplication.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("OnWarehouse")
                        .HasColumnType("bit");

                    b.Property<string>("VendorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("DanfossTestApplication.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("DanfossTestApplication.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("DanfossTestApplication.Models.Link", b =>
                {
                    b.HasOne("DanfossTestApplication.Models.Equipment", "Equipment")
                        .WithMany("Links")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("DanfossTestApplication.Models.Note", b =>
                {
                    b.HasOne("DanfossTestApplication.Models.Equipment", "Equipment")
                        .WithMany("Notes")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("DanfossTestApplication.Models.Equipment", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
