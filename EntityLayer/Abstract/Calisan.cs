using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace EntityLayer.Abstract
{
    public abstract class Calisan
    {
        public int CalisanId { get; set; }
        public string CalisanAd { get; set; }
        public string CalisanSoyad { get; set; }
        public int CalisanYas { get; set; }
        public string CalisanTcNo { get; set; }
        public bool CalisanAktif { get; set; }
        public decimal Maas { get; set; }

        public Login LoginInfo { get; set; }

        public int RoleId { get; set; }
        public Roles Role { get; set; }
        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }

        public virtual IzinTalep IzinTalebi { get; set; }
        public Izin Izin { get; set; }

        public virtual ICollection<CalisanGorevAtamasi> CalisanGorevAtamasi { get; set; }


    }
}
