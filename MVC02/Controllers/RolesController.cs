using BusinessLayer.Concrete;
using DAL.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MVC02.Controllers
{
    public class RolesController : Controller
    {
        private readonly RolesManager _manager;
        public RolesController(RolesManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RoleEkle()
        {
            return View();
        }
        public List<Roles> RoleList()
        {
            return _manager.ListRoles();
        }
        public Roles GetByIdRoles(int id)
        {
            return _manager.GetByIdRole(id);
        }
        public List<Roles> GetRolesByDepartman(int departmanId)
        {
            var departmanRolesList = _manager.GetRolesDepartmanByDepartmanId(departmanId);
            var roleIdsList = departmanRolesList.Select(r => r.RoleId).ToList();
            var departmanRoleIds = _manager.GetListByDepartmanIds(roleIdsList);
            return departmanRoleIds.Select(role => new Roles
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                // Diğer özellikleri burada doldurun, eğer varsa
            }).ToList();
        }
    }
}
