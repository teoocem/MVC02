using DAL.Concrete;
using DAL.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class IzinManager 
    {
        private readonly IzinRepository _izinRepository;

        public IzinManager(IzinRepository izinRepository)
        {
            _izinRepository = izinRepository; 
        }
        public void CreateIzin(Izin izin)
        {
            if(izin != null)
            {
                _izinRepository.Insert(izin);
            }
        }
        public List<Izin> ListIzin()
        {
            return _izinRepository.GetAll();
        }
        public Izin GetByCalisanId(int calisanId)
        {
            var izinList = _izinRepository.GetByCalisanId(calisanId);
            return izinList.FirstOrDefault(i => i.CalisanId == calisanId);
        }
    }
}
