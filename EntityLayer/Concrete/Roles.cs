using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;

        public virtual ICollection<Calisan> Calisanlar { get; set; }
        public virtual ICollection<RolesDepartman> RoleDepartmanlar { get; set; }
    }
}
