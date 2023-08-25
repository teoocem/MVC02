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
   /* public class MaasConfiguration : IEntityTypeConfiguration<Maas>
    {
        public void Configure(EntityTypeBuilder<Maas> builder)
        {
            builder.HasKey(m => m.MaasId);
            builder.Property(m => m.MaasMiktari).HasColumnType("float");
            builder.Property(m => m.VergiOrani).HasColumnType("integer");
            builder.Property(m => m.OdemeTarihi);
           
            // HasForeignKey();
            builder.ToTable("Maaş");
        }
    }
   */
}
