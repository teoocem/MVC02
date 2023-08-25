using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Departman
    {
        public int DepartmanId { get; set; }
        public string DepartmanAd { get; set; }
        public string DepartmanAciklama { get; set; }
        public bool DepartmanAktif { get; set; }
        public virtual ICollection<Calisan> Calisanlar { get; set; }
        public ICollection<RolesDepartman> RoleDepartmanlar { get; set; }
    }
}
