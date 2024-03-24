using CSProjeDemo2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.Concrete
{
    public class Memur : Personel
    {
        private const decimal _saatlikUcret = 500;
        public int Derece { get; set; }
        public Memur(string isim,int derece):base(isim,"Memur")
        {
            Derece = derece;
        
        }
        public override decimal MaasHesapla(decimal calismaSaati)
        {
            if (calismaSaati < 0)
                throw new ArgumentOutOfRangeException(nameof(calismaSaati), "Çalışma saati negatif olamaz!");
            if (calismaSaati <= 180)
                return calismaSaati * _saatlikUcret;
            else
            {
                decimal mesaiSaati = calismaSaati - 180;
                return (180 * _saatlikUcret) + (mesaiSaati * _saatlikUcret * 1.5m);
            }
        }
    }
}
