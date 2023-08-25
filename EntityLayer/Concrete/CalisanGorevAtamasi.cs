using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class CalisanGorevAtamasi
    {
        public int CalisanId { get; set; }
        public Calisan Calisan { get; set; }

        public int GorevId { get; set; }
        public Gorev Gorev { get; set; }
    }
}
