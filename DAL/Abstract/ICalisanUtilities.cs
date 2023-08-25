using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ICalisanUtilities : IGenericOperations<Calisan>
    {
        List<Calisan> GetCalisanByDepartment();
    }
}
