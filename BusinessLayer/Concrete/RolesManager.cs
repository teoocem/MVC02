using DAL.Concrete;
using DAL.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RolesManager
    {
        private readonly RolesRepository _repo;
        private readonly RolesDepartmanRepository _repo2;

        public RolesManager(RolesRepository repo,RolesDepartmanRepository repo2)
        {
            _repo = repo;
            _repo2 = repo2;
        }
        public void CreateRoles(Roles r)
        {
            _repo.Insert(r);
        }
        public List<RolesDepartman> GetRolesDepartmanByDepartmanId(int departmanId)
        {
            return _repo2.GetListByDepartmanId(departmanId);
        }
        
        public List<Roles> ListRoles()
        {
            return _repo.GetAll();
        }
        public Roles GetByIdRole(int id)
        {
            return _repo.GetById(id);
        }
        public List<Roles> GetListByRoleId(int id)
        {
            return _repo.GetByRoleId(id);
        }
        public List<Roles> GetListByDepartmanIds(List<int> roleIds)
        {
            return _repo.GetRolesByDepartmanIds(roleIds);
        }
        
    }
}
