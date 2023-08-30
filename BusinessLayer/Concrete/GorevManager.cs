using BusinessLayer.ViewModel;
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
    public class GorevManager
    {
        public readonly GorevRepository _repo;
        private readonly CalisanGorevAtamasiManager _calisanGorevManager;

        public GorevManager(GorevRepository repo, CalisanGorevAtamasiManager calisanGorevManager)
        {
            _repo = repo;
            _calisanGorevManager = calisanGorevManager;
         }

        public void CreateGorev(GorevDepartmanVM gorev) {
            var yeniGorev = new Gorev()
            {
                GorevAciklama = gorev.GorevAciklama,
                GorevBaslik = gorev.GorevBaslik,
                GorevAktif = true,
                GorevOlusturulmaTarihi = gorev.GorevOlusturulmaTarihi,
                TahminiBitisTarihi = gorev.TahminiBitisTarihi,
            };
            _repo.Insert(yeniGorev);
            
                foreach (string id in gorev.CalisanIDs)
                {
                    var calisanAtama = new CalisanGorevAtamasi
                    {
                        CalisanId = Convert.ToInt32(id),
                        GorevId = yeniGorev.GorevId,
                    };
                _calisanGorevManager.AtamaYap(calisanAtama);
                }
                
            }
        public List<Gorev> GorevList()
        {
            return _repo.GetAll();
        }
    }
}
