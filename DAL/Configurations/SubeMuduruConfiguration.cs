using DAL.Configurations.Base;
using EntityLayer.Abstract;
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
    public class SubeMuduruConfiguration : IEntityTypeConfiguration<SubeMuduru>
    {
        public void Configure(EntityTypeBuilder<SubeMuduru> builder)
        {
            

            builder.Property(db => db.CalisanAd).HasColumnName("SubeMuduruAd");
            builder.Property(db => db.CalisanSoyad).HasColumnName("SubeMuduruSoyad");
            builder.Property(db => db.CalisanTcNo).HasColumnName("SubeMuduruTCNo");
            builder.Property(db => db.CalisanAktif).HasColumnName("SubeMuduruAktif");
            builder.Property(db => db.CalisanYas).HasColumnName("SubeMuduruYas");
            builder.Property(db => db.Maas).HasColumnName("Maas");

            builder.Property(sb => sb.AtanmaTarihi).HasColumnName("AtanmaTarihi");
            builder.Property(sb => sb.SubeAdi).HasColumnName("SubeAdi");

          
        }
    }
}
