using BusinessLayer.Concrete;
using BusinessLayer.ViewModel;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace MVC02.Controllers
{

    public class CalisanController : Controller
    {
        private readonly CalisanManager _calisanManager;
        private readonly DepartmanManager _departmanManager;
        private readonly RolesManager _roleManager;
        public CalisanController(CalisanManager calisanManager,DepartmanManager departmanManager,RolesManager roleManager)
        {
            _calisanManager = calisanManager;
            _departmanManager = departmanManager;
            _roleManager = roleManager;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CalisanEkle()
        {
            var depEntity = _departmanManager.DepartmanList();
            var defaultOption = new SelectListItem
            {
                Value = "",
                Text = "Departman Seçiniz"
            };

            // Departman listesine "Departman Seçiniz" seçeneğini ekleyin
            var selectListDefault = new List<SelectListItem>
            {
               defaultOption
            };
            selectListDefault.AddRange(depEntity.Select(d => new SelectListItem { Value = d.DepartmanId.ToString(), Text = d.DepartmanAd }));
            ViewBag.Departmanlar = selectListDefault;
            
            return View();
        }
        
        public IActionResult StandartEkle(StandartCalisan calisan)
        {
            _calisanManager.CreateCalisan(calisan);
            return View();
        }
        public IActionResult SubeMuduruEkle(SubeMuduru mudur)
        {
            _calisanManager.CreateCalisan(mudur);
            return View();
        }
        public IActionResult DaireBaskaniEkle(DaireBaskani baskan)
        {
            _calisanManager.CreateCalisan(baskan);
            return View();
        }



        public IActionResult GetPartialStandart() => PartialView("~/Views/Shared/Calisan/StandartCalisanPartial.cshtml");
      

        public IActionResult GetPartialSubeMuduru() => PartialView("~/Views/Shared/Calisan/SubeMuduruPartial.cshtml");
        
        public IActionResult GetPartialDaireBaskani() => PartialView("~/Views/Shared/Calisan/DaireBaskaniPartial.cshtml");
        
        
    }
}
