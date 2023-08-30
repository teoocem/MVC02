using DAL.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CalisanGorevRepository : GenericOperations<CalisanGorevAtamasi>
    {
        public CalisanGorevRepository(DbContext context) : base(context)
        {
        }
    }
}
