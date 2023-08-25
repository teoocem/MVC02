using DAL.Concrete;
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
        private readonly GenericOperations<CalisanGorevAtamasi> _repo;

        public CalisanGorevAtamasiManager(GenericOperations<CalisanGorevAtamasi> repo)
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
