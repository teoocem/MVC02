using BusinessLayer.Abstract.CustomClaims;
using BusinessLayer.Abstract.Requirements;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.Authorizations
{
    public class CalisanAuthorization : AuthorizationHandler<CalisanRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CalisanRequirement requirement)
        {
            if (context.User.HasClaim(claim => claim.Type == CustomClaimTypes.CalisanTip && claim.Value == requirement.CalisanTip))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
