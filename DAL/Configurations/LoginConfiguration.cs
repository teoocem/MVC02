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
    public class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasKey(l => l.LoginId);
            builder.Property(l => l.Username);
            builder.Property(l => l.Password);

            builder.HasOne(l => l.Calisan).WithOne(c => c.LoginInfo).HasForeignKey<Login>(l => l.CalisanId).OnDelete(DeleteBehavior.Restrict); ;
            builder.ToTable("LoginInfo");
        }
    }
}
