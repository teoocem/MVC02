using DAL.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class IzinTalepRepository : GenericOperations<IzinTalep>
    {
        public IzinTalepRepository(Context context) : base(context)
        {
        }
        public IzinTalep GetFirstByCalisanId(int calisanId)
        {
            var izinTalepList = GetAll();
            return izinTalepList.FirstOrDefault(it => it.CalisanId == calisanId);
        }
    }
}
