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
    public class DepartmanManager
    {
        private readonly DepartmanRepository _repo;
        public DepartmanManager(DepartmanRepository repo)
        {
            _repo = repo;
        }
        public List<Departman> DepartmanList()
        {
            return _repo.GetAll();
        }
        public void CreateDepartman(Departman departman)
        {
            _repo.Insert(departman);
        }
        public List<string> DepartmanAd()
        {
            return _repo.DepartmanAdList();
        }
        public Departman DepartmanGetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}
