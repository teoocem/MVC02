using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SubeMuduru : Calisan
    {
        public string SubeAdi { get; set; }
        public DateTime AtanmaTarihi { get; set; }

        public int DepartmanId { get; set; }
        public Departman Departman { get; set; }
    }
}
