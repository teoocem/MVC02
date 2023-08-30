using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVC02.Controllers
{
    public class LoginInfoController : Controller
    {
        private readonly LoginManager _manager;
        public LoginInfoController(LoginManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateLoginInfo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLoginInfo(Login login)
        {
            _manager.CreateLoginInfo(login);
            return View();
        }
        public IActionResult LoginList()
        {
            var loginList = _manager.LoginList();
            return View(loginList);
        }
    }
}
