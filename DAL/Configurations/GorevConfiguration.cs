using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class GorevConfiguration : IEntityTypeConfiguration<Gorev>
    {
        public void Configure(EntityTypeBuilder<Gorev> builder)
        {
            builder.HasKey(g => g.GorevId);

            builder.Property(g => g.GorevBaslik).HasColumnName("Görev Başlığı");
            builder.Property(g => g.GorevAciklama).HasColumnName("Görev Açıklaması");
            builder.Property(g => g.GorevOlusturulmaTarihi).HasColumnName("Oluşturulma Tarihi");
            builder.Property(g => g.TahminiBitisTarihi).HasColumnName("Tahmini Bitiş Tarihi");
            builder.Property(g => g.GorevAktif).HasColumnName("Görev Durumu");

            builder.HasMany(g => g.GorevCalisanlar).WithOne(cg => cg.Gorev).HasForeignKey(g => g.GorevId);

          
            builder.ToTable("Gorevler");
        }
    }
}
