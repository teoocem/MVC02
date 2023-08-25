using EntityLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.ViewModel
{
    public class CalisanVM
    {
        public string CalisanAd { get; set; }
        public string CalisanSoyad { get; set; }
        public string CalisanTcNo { get; set; }
        public int CalisanYas { get; set; }
        public int DepartmanID { get; set; }

        public string RoleAd { get; set; }
        public List<Departman> Departmanlar { get; set; }

    }
}
