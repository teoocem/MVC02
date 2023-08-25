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
    public class IzinTalepConfiguration : IEntityTypeConfiguration<IzinTalep>
    {
        public void Configure(EntityTypeBuilder<IzinTalep> builder)
        {
            builder.HasKey(it => it.IzinTalepId);
            builder.Property(it => it.IzinAciklama).HasColumnName("IzinAciklama");
            builder.Property(it => it.IzinBaslangicTarihi);
            builder.Property(it => it.IzinBitisTarihi);
            builder.Property(it => it.TalepAsama).HasConversion<int>();

            

           
            builder.ToTable("İzinTalepleri");
        }
    }
}
