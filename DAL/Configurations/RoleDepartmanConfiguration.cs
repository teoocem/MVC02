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
    public class RoleDepartmanConfiguration : IEntityTypeConfiguration<RolesDepartman>
    {
        public void Configure(EntityTypeBuilder<RolesDepartman> builder)
        {
            builder.HasKey(rd => rd.RoleDepartmanId);

            builder.ToTable("RoleByDepartmanlar");
        }
    }
}
