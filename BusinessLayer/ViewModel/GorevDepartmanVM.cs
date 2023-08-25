using EntityLayer.Concrete;

namespace BusinessLayer.ViewModel
{
    public class GorevDepartmanVM
    {
        public int GorevId { get; set; }
        public string GorevBaslik { get; set; }
        public string GorevAciklama { get; set; }
        public DateTime GorevOlusturulmaTarihi { get; set; }
        public DateTime TahminiBitisTarihi { get; set; }
        public bool GorevAktif { get; set; }

        public int DepartmanId { get; set; }
        public string[] CalisanIDs { get; set; }
    }
}
