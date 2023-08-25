using DAL.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class IzinRepository : GenericOperations<Izin>
    {
        
        public IzinRepository(Context context) : base(context)
        {
        }
        public List<Izin> GetByCalisanId(int calisanId)
        {
            return GetAll().Where(i => i.CalisanId == calisanId).ToList();
        }
       
    }
}
