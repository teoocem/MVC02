using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public enum ETalepAsama
    {
        BEKLIYOR = 0,
        ONAYLANDI = 1,
        REDDEDILDI = 2,
    }
    public class IzinTalep
    {
        public int IzinTalepId { get; set; }
        public DateTime IzinBaslangicTarihi { get; set; }
        public DateTime IzinBitisTarihi { get; set; }
        public ETalepAsama TalepAsama { get; set; }
        public string IzinAciklama { get; set; }

        public int CalisanId { get; set; }
        public virtual Calisan Calisan { get; set; }
      
        
    }
}
