using DAL.Configurations.Base;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class StandartCalisanConfiguration : IEntityTypeConfiguration<StandartCalisan>
    {
        public void Configure(EntityTypeBuilder<StandartCalisan> builder)
        {
            builder.ToTable("StandartCalisanlar");
            

            builder.Property(db => db.CalisanAd).HasColumnName("StandartCalisanAd");
            builder.Property(db => db.CalisanSoyad).HasColumnName("StandartCalisanSoyad");
            builder.Property(db => db.CalisanTcNo).HasColumnName("StandartCalisanTCNo");
            builder.Property(db => db.CalisanAktif).HasColumnName("StandartCalisanAktif");
            builder.Property(db => db.CalisanYas).HasColumnName("StandartCalisanYas");
            builder.Property(db => db.Maas).HasColumnName("Maas");

            
            

        }
    }
}
