using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RolesDepartman
    {
        public int RoleDepartmanId { get; set; }
        public int DepartmanId { get; set; }
        public int RoleId { get; set; }

        public virtual Departman Departman { get; set; }
        public  virtual Roles Role { get; set; }
    }
}
