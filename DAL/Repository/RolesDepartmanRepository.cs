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
    public class RolesDepartmanRepository : GenericOperations<RolesDepartman>
    {
        public RolesDepartmanRepository(DbContext context) : base(context)
        {
        }
        public List<RolesDepartman> GetListByDepartmanId(int id)
        {
            var roleList = GetAll();
            var roleByDepartman = roleList.Where(rd => rd.DepartmanId == id).ToList();
            return roleByDepartman;
        }
        
    }
}
