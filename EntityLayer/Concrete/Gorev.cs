using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Gorev
    {
        public int GorevId { get; set; }
        public string GorevBaslik { get; set; }
        public string GorevAciklama { get; set; }
        public DateTime GorevOlusturulmaTarihi { get; set; }
        public DateTime TahminiBitisTarihi { get; set; }
        public bool GorevAktif { get; set; }
        public ICollection<CalisanGorevAtamasi> GorevCalisanlar { get; set; }
    }
}
