using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class StandartCalisan : Calisan
    {
      


        public ICollection<CalisanGorevAtamasi> Gorevler { get; set; }

        public virtual IzinTalep IzinTalebi { get; set; }

        
    }
}
