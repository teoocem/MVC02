using BusinessLayer.Concrete;
using DAL.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVC02.Controllers
{
    [Authorize(Policy = "RequireDaireBaskani")]
    public class IzinTalepController : Controller
    {
        private readonly TalepManager _talepManager;

        public IzinTalepController(TalepManager talepManager)
        {
            _talepManager = talepManager;
        }
        public IActionResult TalepOlustur()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TalepOlustur(IzinTalep talep)
        {
            
            using (var context = new Context())
            {
                if (talep != null)
                {
                    talep.TalepAsama = ETalepAsama.BEKLIYOR;
                    var nameClaim = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name);

                    var loginInfo = context.LoginInfos.FirstOrDefault(login => nameClaim.Value == login.Username);
                    talep.CalisanId = loginInfo.CalisanId;
                    context.IzinTalepleri.Add(talep);

                    context.SaveChanges();
                }

            }

            return Ok("Talep eklendi kafaya takma");

        }
        public IActionResult TalepListele()
        {
            using(var dbContext = new Context())
            {
                var entity = dbContext.IzinTalepleri.Where(it => it.TalepAsama == ETalepAsama.BEKLIYOR).ToList();
                if(entity != null)
                return View(entity);
                else
                {
                    return View();
                }
            }
            
        }
        
        public void TalepYanitla(int calisanId, int talepAsama)
        {
            _talepManager.TalepOlustur(calisanId, talepAsama);
            
        }
        }
    }

