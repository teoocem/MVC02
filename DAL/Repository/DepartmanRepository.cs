using DAL.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DepartmanRepository : GenericOperations<Departman>
    {
        public DepartmanRepository(Context context) : base(context)
        {

        }
        public List<string> DepartmanAdList()
        {
            return GetAll().Select(d => d.DepartmanAd).ToList();
        }
    }
}
