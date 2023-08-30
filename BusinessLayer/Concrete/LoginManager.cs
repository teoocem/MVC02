using DAL.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager
    {
        private readonly LoginRepository _repo;
        public LoginManager(LoginRepository repo)
        {
            _repo = repo;
        }
        public List<Login> LoginList()
        {
            return _repo.GetAll();
        }
        public void CreateLoginInfo(Login l)
        {
            var entity = _repo.GetAll().FirstOrDefault(login => login.Username == l.Username);
            if (entity ==  null)
            {
                _repo.Insert(l);
            }
        }
    }
}
