using BusinessLayer.Concrete;
using DAL.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC02.Controllers
{
    [Authorize(Policy = "RequireDaireBaskani")]
    public class DepartmanController : Controller
    {
        private readonly DepartmanManager _departmanManager;
        public DepartmanController(DepartmanManager departmanManager)
        {
            _departmanManager = departmanManager;
        }
        public IActionResult Index()
        {
            var departmanList = _departmanManager.DepartmanList();
            return View(departmanList);
        }
        [HttpGet]
        public IActionResult DepartmanlarıListele()
        {
            var departmanlar = _departmanManager.DepartmanList();
            return View(departmanlar);
        }
        [HttpGet]
        public IActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DepartmanEkle(Departman departman)
        {
            var entity = new Departman(){
                DepartmanAd = departman.DepartmanAd,
                DepartmanAciklama = departman.DepartmanAciklama,
                DepartmanAktif = true,
            };
            _departmanManager.CreateDepartman(entity);

            return RedirectToAction("DepartmanlarıListele");
        }
    }
}
