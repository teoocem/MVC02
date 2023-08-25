using DAL.Concrete;
using DAL.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TalepManager
    {
        private readonly IzinTalepRepository _repo;
        private readonly IzinManager _izinManager;

        public TalepManager(IzinTalepRepository repo,IzinManager izinManager)
        {
            _repo = repo;
            _izinManager = izinManager;
        }
        public void TalepOlustur(int calisanId, int talepAsama)
        {
            var entity = _repo.GetFirstByCalisanId(calisanId);
            if (entity != null)
            {

                entity.TalepAsama = (ETalepAsama)Enum.ToObject(typeof(ETalepAsama), talepAsama);
                if (entity.TalepAsama == ETalepAsama.ONAYLANDI)
                {
                    var izinEntity = new Izin()
                    {
                        IzinAktif = true,
                        IzinBaslangicTarihi = entity.IzinBaslangicTarihi,
                        IzinBitisTarihi = entity.IzinBitisTarihi,
                        CalisanId = entity.CalisanId,

                    };
                    var izinDB = _izinManager.GetByCalisanId(calisanId);
                    _izinManager.CreateIzin(izinDB);



                }
                _repo.Update(entity);
            }
        }
        public List<IzinTalep> ListTalep()
        {
            return _repo.GetAll();
        }
    }
}
