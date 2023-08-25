using BusinessLayer.Concrete;
using BusinessLayer.ViewModel;
using DAL.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MVC02.Controllers
{
    [Authorize(Policy = "RequireDaireBaskani , RequireSubeMuduru")]
    public class GorevController : Controller
    {
        public readonly GorevManager _gorevManager;
        public readonly DepartmanManager _departmanManager;
        public GorevController(GorevManager gorevManager,DepartmanManager departmanManager)
        {
            _gorevManager = gorevManager;
            _departmanManager = departmanManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GorevOlustur()
        {
            using(var context = new Context())
            {
                var departmanlar = _departmanManager.DepartmanList();
                ViewBag.Departmanlar = new SelectList(departmanlar, "DepartmanId", "DepartmanAd");
            }
            return View();
        }
        [HttpPost]
        public IActionResult GorevOlustur(GorevDepartmanVM gorev)
        {
            _gorevManager.CreateGorev(gorev);
            return View();
        }
        public IActionResult GorevList()
        {
            var gorevler = _gorevManager.GorevList();
            return View(gorevler);
        }
       
    }
}
