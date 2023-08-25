using BusinessLayer.Concrete;
using DAL.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC02.Controllers
{
    [Authorize(Policy = "RequiredSubeMuduru ,RequiredDaireBaskani")]
    public class IzinController : Controller
    {
        private readonly IzinManager _izinManager;
        public IzinController(IzinManager izinManager)
        {
            _izinManager = izinManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IzinList()
        {
            var izinler = _izinManager.ListIzin();
            return View(izinler);
           
        }
       

        
    }
}
