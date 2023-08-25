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
    public class CalisanGorevConfiguration : IEntityTypeConfiguration<CalisanGorevAtamasi>
    {
        public void Configure(EntityTypeBuilder<CalisanGorevAtamasi> builder)
        {
            builder.HasKey(cg => new { cg.GorevId, cg.CalisanId });

            builder.HasOne(cg => cg.Calisan).WithMany(c => c.CalisanGorevAtamasi);
            builder.HasOne(cg => cg.Gorev).WithMany(g => g.GorevCalisanlar);

            builder.ToTable("CalisanGorev");
        }
    }
}
