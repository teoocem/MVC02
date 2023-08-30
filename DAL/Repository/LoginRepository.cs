using DAL.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class LoginRepository : GenericOperations<Login>
    {
        public LoginRepository(Context context) : base(context)
        {
            
        }
    }
}
