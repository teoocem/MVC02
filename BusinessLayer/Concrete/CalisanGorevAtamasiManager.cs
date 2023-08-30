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
    public class CalisanGorevAtamasiManager 
    {
        private readonly CalisanGorevRepository _repo;

        public CalisanGorevAtamasiManager(CalisanGorevRepository repo)
        {
            _repo = repo;
        }
        public void AtamaYap(CalisanGorevAtamasi gorevAtamasi)
        {
            _repo.Insert(gorevAtamasi);
        }
        public List<CalisanGorevAtamasi> ListGorevAtama()
        {
            return _repo.GetAll();
        }
    }
}
