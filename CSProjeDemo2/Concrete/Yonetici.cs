using CSProjeDemo2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.Concrete
{
    public class Yonetici : Personel
    {
        private const decimal _saatlikUcret = 500;
        private const decimal _bonus = 1000;
        
        public Yonetici(string isim):base(isim,"Yonetici")
        {
           
        }
        public override decimal MaasHesapla(decimal calismaSaati)
        {
            if (_saatlikUcret < 0) 
            {
                throw new Exception("Yöneticinin saatlik ücreti 500'den az olamaz.");
            }
            return (_saatlikUcret*calismaSaati)+_bonus;
        }
    }
}
