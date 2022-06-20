﻿// <auto-generated />
using System;
using Bilge.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bilge.Domain.Migrations
{
    [DbContext(typeof(BilgeDbContext))]
    [Migration("20220620095313_initDb")]
    partial class initDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bilge.Domain.Ders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DersAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kod")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int?>("SiniflarId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SiniflarId");

                    b.ToTable("Ders");
                });

            modelBuilder.Entity("Bilge.Domain.DersProgram", b =>
                {
                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DersId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Saat")
                        .HasColumnType("datetime2");

                    b.Property<int>("SiniflarId")
                        .HasColumnType("int");

                    b.Property<int?>("VeliId")
                        .HasColumnType("int");

                    b.HasKey("Tarih");

                    b.HasIndex("DersId");

                    b.HasIndex("SiniflarId");

                    b.HasIndex("VeliId");

                    b.ToTable("DersProgram");
                });

            modelBuilder.Entity("Bilge.Domain.Donem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DonemBaslangıcTarihi")
                        .HasColumnType("int");

                    b.Property<int>("DonemBitisTarihi")
                        .HasColumnType("int");

                    b.Property<int>("DonemTip")
                        .HasColumnType("int");

                    b.Property<int>("Yil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Donem");
                });

            modelBuilder.Entity("Bilge.Domain.Ogrenci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CikisTarih")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DogumTarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("EPosta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GirisTarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gsm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SinifId")
                        .HasColumnType("int");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("SinifId");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("Bilge.Domain.Ogretmen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CikisTarih")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DersId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DogumTarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("EPosta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GirisTarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gsm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("DersId");

                    b.ToTable("Ogretmenler");
                });

            modelBuilder.Entity("Bilge.Domain.Siniflar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kapasite")
                        .HasColumnType("int");

                    b.Property<string>("Kod")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("SinifAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Siniflar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Kapasite = 25,
                            Kod = "100",
                            SinifAdi = "9A"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Kapasite = 25,
                            Kod = "101",
                            SinifAdi = "10A"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Kapasite = 25,
                            Kod = "102",
                            SinifAdi = "11A"
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Kapasite = 25,
                            Kod = "103",
                            SinifAdi = "12A"
                        });
                });

            modelBuilder.Entity("Bilge.Domain.Veli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EPosta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gsm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.ToTable("Veliler");
                });

            modelBuilder.Entity("Bilge.Domain.Yoklama", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DersPogramId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DersProgramTarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Saat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VeliId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DersProgramTarih");

                    b.HasIndex("OgrenciId");

                    b.HasIndex("VeliId");

                    b.ToTable("Yoklamalar");
                });

            modelBuilder.Entity("Okul.Domain.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("Bilge.Domain.Ders", b =>
                {
                    b.HasOne("Bilge.Domain.Siniflar", null)
                        .WithMany("Dersler")
                        .HasForeignKey("SiniflarId");
                });

            modelBuilder.Entity("Bilge.Domain.DersProgram", b =>
                {
                    b.HasOne("Bilge.Domain.Ders", "Ders")
                        .WithMany("DersProgram")
                        .HasForeignKey("DersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bilge.Domain.Siniflar", "Sinif")
                        .WithMany()
                        .HasForeignKey("SiniflarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bilge.Domain.Veli", null)
                        .WithMany("DersProgram")
                        .HasForeignKey("VeliId");

                    b.Navigation("Ders");

                    b.Navigation("Sinif");
                });

            modelBuilder.Entity("Bilge.Domain.Ogrenci", b =>
                {
                    b.HasOne("Bilge.Domain.Siniflar", "Sinif")
                        .WithMany("Ogrenci")
                        .HasForeignKey("SinifId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sinif");
                });

            modelBuilder.Entity("Bilge.Domain.Ogretmen", b =>
                {
                    b.HasOne("Bilge.Domain.Ders", "Ders")
                        .WithMany("Ogretmen")
                        .HasForeignKey("DersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ders");
                });

            modelBuilder.Entity("Bilge.Domain.Yoklama", b =>
                {
                    b.HasOne("Bilge.Domain.DersProgram", "DersProgram")
                        .WithMany("Yoklamalar")
                        .HasForeignKey("DersProgramTarih");

                    b.HasOne("Bilge.Domain.Ogrenci", "Ogrenciler")
                        .WithMany("Yoklamalar")
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bilge.Domain.Veli", null)
                        .WithMany("Yoklama")
                        .HasForeignKey("VeliId");

                    b.Navigation("DersProgram");

                    b.Navigation("Ogrenciler");
                });

            modelBuilder.Entity("Bilge.Domain.Ders", b =>
                {
                    b.Navigation("DersProgram");

                    b.Navigation("Ogretmen");
                });

            modelBuilder.Entity("Bilge.Domain.DersProgram", b =>
                {
                    b.Navigation("Yoklamalar");
                });

            modelBuilder.Entity("Bilge.Domain.Ogrenci", b =>
                {
                    b.Navigation("Yoklamalar");
                });

            modelBuilder.Entity("Bilge.Domain.Siniflar", b =>
                {
                    b.Navigation("Dersler");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("Bilge.Domain.Veli", b =>
                {
                    b.Navigation("DersProgram");

                    b.Navigation("Yoklama");
                });
#pragma warning restore 612, 618
        }
    }
}
