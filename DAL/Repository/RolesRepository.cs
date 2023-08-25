using DAL.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RolesRepository : GenericOperations<Roles>
    {
        public RolesRepository(DbContext context) : base(context)
        {
        }
        public List<Roles> GetByRoleId(int id)
        {
            return GetAll().Where(r => r.RoleId == id).ToList();
        }
        public List<Roles> GetRolesByDepartmanIds(List<int> roleIds)
        {
            return GetAll().Where(r => roleIds.Contains(r.RoleId)).ToList();
        }
      
      

    }
}
