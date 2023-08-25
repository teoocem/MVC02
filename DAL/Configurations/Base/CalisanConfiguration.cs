using EntityLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations.Base
{
    public class CalisanConfiguration : IEntityTypeConfiguration<Calisan>
    {
       

        public void Configure(EntityTypeBuilder<Calisan> builder)
        {
            builder.ToTable("Calisanlar");
            builder.HasDiscriminator<string>("CalisanTipi").HasValue<StandartCalisan>("Standart")
                .HasValue<SubeMuduru>("SubeMuduru").HasValue<DaireBaskani>("DaireBaskani");
            builder.HasOne(c => c.Departman).WithMany(d => d.Calisanlar).HasForeignKey(c => c.DepartmanId);
            builder.HasOne(c => c.Role).WithMany(r => r.Calisanlar).HasForeignKey(c => c.RoleId);

            builder.HasOne(c => c.IzinTalebi).WithOne(it => it.Calisan).HasForeignKey<IzinTalep>(it => it.CalisanId);

            builder.HasMany(c => c.CalisanGorevAtamasi).WithOne(cg => cg.Calisan).HasForeignKey(cg => cg.CalisanId);
        }
    }
}
