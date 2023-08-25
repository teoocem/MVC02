using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public enum EIzinTipi       
    {
        RAPORLU,
        UCRETSIZIZIN,
        YILLIKIZIN
    }
    public class Izin
    {
        public int IzinId { get; set; }
        public DateTime IzinBaslangicTarihi { get; set; }
        public DateTime IzinBitisTarihi { get; set; }
        public bool IzinAktif { get; set; }
        public EIzinTipi IzinTipi { get; set; }

        public int CalisanId { get; set; }
        public Calisan Calisan { get; set; }
    }
}
