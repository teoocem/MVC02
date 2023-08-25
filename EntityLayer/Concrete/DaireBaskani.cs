using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class DaireBaskani : Calisan
    {
        public string DaireAdı { get; set; }
        public DateTime AtanmaTarihi { get; set; }

        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }
    }
}
