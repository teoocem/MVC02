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
    public class IzinConfiguration : IEntityTypeConfiguration<Izin>
    {
        public void Configure(EntityTypeBuilder<Izin> builder)
        {
            builder.HasKey(i => i.IzinId);
            builder.Property(i => i.IzinBaslangicTarihi).HasColumnName("Başlangıç Tarihi");
            builder.Property(i => i.IzinBitisTarihi).HasColumnName("Bitiş Tarihi");

            builder.Property(i => i.IzinAktif).HasColumnName("İzin Aktif");
            builder.Property(i => i.IzinTipi).HasColumnName("İzin Tipi").HasConversion<int>();
            builder.HasOne(i => i.Calisan).WithOne(c => c.Izin).HasForeignKey<Izin>(i => i.CalisanId);
            builder.ToTable("Izinler");
        }
    }
}
