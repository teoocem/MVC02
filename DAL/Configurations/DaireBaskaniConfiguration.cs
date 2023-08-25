using DAL.Configurations.Base;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class DaireBaskaniConfiguration : IEntityTypeConfiguration<DaireBaskani>
    {
        public void Configure(EntityTypeBuilder<DaireBaskani> builder)
        {
            builder.Property(db => db.CalisanAd).HasColumnName("DaireBaskaniAd");
            builder.Property(db => db.CalisanSoyad).HasColumnName("DaireBaskaniSoyad");
            builder.Property(db => db.CalisanTcNo).HasColumnName("DaireBaskaniTCNo");
            builder.Property(db => db.CalisanAktif).HasColumnName("DaireBaskaniAktif");
            builder.Property(db => db.CalisanYas).HasColumnName("DaireBaskaniYas");
            builder.Property(db => db.Maas).HasColumnName("Maas");


            builder.Property(db => db.DaireAdı).HasColumnName("DaireAdi");
            builder.Property(db => db.AtanmaTarihi).HasColumnType("datetime");

            

            builder.ToTable("DaireBaskani");
        }
    }
}
