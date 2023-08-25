﻿// <auto-generated />
using System;
using DAL.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230821054444_tph-mig")]
    partial class tphmig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Abstract.Calisan", b =>
                {
                    b.Property<int>("CalisanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalisanId"));

                    b.Property<string>("CalisanAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CalisanAktif")
                        .HasColumnType("bit");

                    b.Property<string>("CalisanSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CalisanTcNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CalisanTipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CalisanYas")
                        .HasColumnType("int");

                    b.Property<int>("DepartmanId")
                        .HasColumnType("int");

                    b.Property<decimal>("Maas")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CalisanId");

                    b.HasIndex("DepartmanId");

                    b.ToTable("Calisanlar", (string)null);

                    b.HasDiscriminator<string>("CalisanTipi").HasValue("Calisan");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EntityLayer.Concrete.CalisanGorevAtamasi", b =>
                {
                    b.Property<int>("GorevId")
                        .HasColumnType("int");

                    b.Property<int>("StandartCalisanId")
                        .HasColumnType("int");

                    b.HasKey("GorevId", "StandartCalisanId");

                    b.HasIndex("StandartCalisanId");

                    b.ToTable("CalisanGorev", (string)null);
                });

            modelBuilder.Entity("EntityLayer.Concrete.Departman", b =>
                {
                    b.Property<int>("DepartmanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmanId"));

                    b.Property<string>("DepartmanAciklama")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DepartmanAd")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("DepartmanAktif")
                        .HasColumnType("bit");

                    b.HasKey("DepartmanId");

                    b.ToTable("Departmanlar", (string)null);
                });

            modelBuilder.Entity("EntityLayer.Concrete.Gorev", b =>
                {
                    b.Property<int>("GorevId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GorevId"));

                    b.Property<string>("GorevAciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Görev Açıklaması");

                    b.Property<bool>("GorevAktif")
                        .HasColumnType("bit")
                        .HasColumnName("Görev Durumu");

                    b.Property<string>("GorevBaslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Görev Başlığı");

                    b.Property<DateTime>("GorevOlusturulmaTarihi")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<DateTime>("TahminiBitisTarihi")
                        .HasColumnType("datetime2")
                        .HasColumnName("Tahmini Bitiş Tarihi");

                    b.HasKey("GorevId");

                    b.ToTable("Gorevler", (string)null);
                });

            modelBuilder.Entity("EntityLayer.Concrete.Izin", b =>
                {
                    b.Property<int>("IzinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IzinId"));

                    b.Property<bool>("IzinAktif")
                        .HasColumnType("bit")
                        .HasColumnName("İzin Aktif");

                    b.Property<DateTime>("IzinBaslangicTarihi")
                        .HasColumnType("datetime2")
                        .HasColumnName("Başlangıç Tarihi");

                    b.Property<DateTime>("IzinBitisTarihi")
                        .HasColumnType("datetime2")
                        .HasColumnName("Bitiş Tarihi");

                    b.Property<int>("IzinTipi")
                        .HasColumnType("int")
                        .HasColumnName("İzin Tipi");

                    b.HasKey("IzinId");

                    b.ToTable("Izinler", (string)null);
                });

            modelBuilder.Entity("EntityLayer.Concrete.IzinTalep", b =>
                {
                    b.Property<int>("IzinTalepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IzinTalepId"));

                    b.Property<string>("IzinAciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IzinAciklama");

                    b.Property<DateTime>("IzinBaslangicTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IzinBitisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("StandartCalisanId")
                        .HasColumnType("int");

                    b.Property<int>("TalepAsama")
                        .HasColumnType("int");

                    b.HasKey("IzinTalepId");

                    b.HasIndex("StandartCalisanId")
                        .IsUnique();

                    b.ToTable("İzinTalepleri", (string)null);
                });

            modelBuilder.Entity("EntityLayer.Concrete.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoginId"));

                    b.Property<int>("CalisanId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginId");

                    b.HasIndex("CalisanId")
                        .IsUnique();

                    b.ToTable("LoginInfo", (string)null);
                });

            modelBuilder.Entity("EntityLayer.Concrete.DaireBaskani", b =>
                {
                    b.HasBaseType("EntityLayer.Abstract.Calisan");

                    b.Property<DateTime>("AtanmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DaireAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DaireBaskanId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("dairebaskani");
                });

            modelBuilder.Entity("EntityLayer.Concrete.StandartCalisan", b =>
                {
                    b.HasBaseType("EntityLayer.Abstract.Calisan");

                    b.HasDiscriminator().HasValue("standart");
                });

            modelBuilder.Entity("EntityLayer.Concrete.SubeMuduru", b =>
                {
                    b.HasBaseType("EntityLayer.Abstract.Calisan");

                    b.Property<DateTime>("AtanmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubeAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Calisanlar", t =>
                        {
                            t.Property("AtanmaTarihi")
                                .HasColumnName("SubeMuduru_AtanmaTarihi");
                        });

                    b.HasDiscriminator().HasValue("subemuduru");
                });

            modelBuilder.Entity("EntityLayer.Abstract.Calisan", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Departman", "Departman")
                        .WithMany("Calisanlar")
                        .HasForeignKey("DepartmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departman");
                });

            modelBuilder.Entity("EntityLayer.Concrete.CalisanGorevAtamasi", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Gorev", "Gorev")
                        .WithMany("GorevCalisanlar")
                        .HasForeignKey("GorevId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.StandartCalisan", "Calisan")
                        .WithMany("Gorevler")
                        .HasForeignKey("StandartCalisanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisan");

                    b.Navigation("Gorev");
                });

            modelBuilder.Entity("EntityLayer.Concrete.IzinTalep", b =>
                {
                    b.HasOne("EntityLayer.Concrete.StandartCalisan", "StandartCalisan")
                        .WithOne("IzinTalebi")
                        .HasForeignKey("EntityLayer.Concrete.IzinTalep", "StandartCalisanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StandartCalisan");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Login", b =>
                {
                    b.HasOne("EntityLayer.Abstract.Calisan", "Calisan")
                        .WithOne("LoginInfo")
                        .HasForeignKey("EntityLayer.Concrete.Login", "CalisanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Calisan");
                });

            modelBuilder.Entity("EntityLayer.Abstract.Calisan", b =>
                {
                    b.Navigation("LoginInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Concrete.Departman", b =>
                {
                    b.Navigation("Calisanlar");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Gorev", b =>
                {
                    b.Navigation("GorevCalisanlar");
                });

            modelBuilder.Entity("EntityLayer.Concrete.StandartCalisan", b =>
                {
                    b.Navigation("Gorevler");

                    b.Navigation("IzinTalebi")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}