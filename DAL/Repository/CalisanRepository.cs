using DAL.Concrete;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CalisanRepository : GenericOperations<Calisan>
    {
        public CalisanRepository(Context context) : base(context)
        {
        }
        public List<Calisan> GetByDepartmanId(int departmanId)
        {
            return GetAll().Where(c => c.DepartmanId == departmanId).ToList();
        }
    }
}
