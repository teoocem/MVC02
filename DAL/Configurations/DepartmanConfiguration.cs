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
    public class DepartmanConfiguration : IEntityTypeConfiguration<Departman>
    {
        public void Configure(EntityTypeBuilder<Departman> builder)
        {
            builder.ToTable("Departmanlar");
            builder.HasKey(d => d.DepartmanId);

            builder.Property(d => d.DepartmanAd).HasMaxLength(100);
            builder.Property(d => d.DepartmanAciklama).HasMaxLength(100);


            builder.HasMany(d => d.RoleDepartmanlar).WithOne(rd => rd.Departman).HasForeignKey(rd => rd.DepartmanId);
        }
    }
}
