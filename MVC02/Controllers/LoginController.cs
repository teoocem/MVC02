using Azure.Identity;
using BusinessLayer.Abstract;
using BusinessLayer.ViewModel;
using DAL.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;

namespace MVC02.Controllers
{
    
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginVM login)
        {
            using(var context = new Context())
            {
                var loginInfo = context.LoginInfos.FirstOrDefault(l => l.Username == login.KullaniciAdi && l.Password == login.Sifre);
                if(loginInfo != null)
                {
                    var userInfo = context.Calisanlar.FirstOrDefault(c => c.CalisanId == loginInfo.CalisanId);
                    if (userInfo != null)
                    {
                        var role = context.Roles.FirstOrDefault(r => userInfo.RoleId == r.RoleId);
                        if(role != null)
                        {
                            var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name,loginInfo.Username),
                            new Claim(CustomClaimTypes.CalisanTip,role.RoleName),
                        };
                            var claimIdentity = new ClaimsIdentity(claims, "cookie");
                            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
                            await HttpContext.SignInAsync(claimPrincipal);
                            return RedirectToAction("Index", "Home");
                        }

                    }
                }
               
            }
            return View();
            
        }
    }
}
