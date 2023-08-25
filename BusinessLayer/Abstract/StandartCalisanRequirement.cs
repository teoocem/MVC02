using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer.Abstract
{
    public static class CustomClaimTypes
    {
        public static string CalisanTip = "CalisanTip";
    }
   
    public class StandartCalisanRequirement : IAuthorizationRequirement
    {
        public string CalisanTip { get; set; }
        public StandartCalisanRequirement(string calisanTip)
        {
            CalisanTip = calisanTip;
        }
    }
    public class StandartCalisanAuthorization : AuthorizationHandler<StandartCalisanRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, StandartCalisanRequirement requirement)
        {
            if(context.User.HasClaim(claim => claim.Type == CustomClaimTypes.CalisanTip && claim.Value == requirement.CalisanTip))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
