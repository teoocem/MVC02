using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.Requirements
{
    public class CalisanRequirement : IAuthorizationRequirement
    {
        public string CalisanTip { get; set; }
        public CalisanRequirement(string calisanTip)
        {
            CalisanTip = calisanTip;
        }
    }
}
