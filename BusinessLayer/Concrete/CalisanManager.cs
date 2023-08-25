using DAL.Concrete;
using DAL.Repository;
using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CalisanManager
    {
        private readonly CalisanRepository _calisanRepository;
        public CalisanManager(CalisanRepository calisanRepository)
        {
            _calisanRepository = calisanRepository;
        }
        public void CreateCalisan(Calisan calisan)
        {
            if(calisan != null && calisan.CalisanTcNo.Length <= 11)
            {
                _calisanRepository.Insert(calisan);
            }
        }
        public List<Calisan> ListCalisan()
        {
            return _calisanRepository.GetAll();
        }
    }
}
