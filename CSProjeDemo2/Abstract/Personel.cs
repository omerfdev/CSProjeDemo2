using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.Abstract
{
    public abstract class Personel
    {
        public string Isim { get; set; }
        public string Unvan { get; set; }
        public decimal CalismaSaati { get; set; }

        public abstract decimal MaasHesapla(decimal calismaSaati);
        public Personel(string isim,string unvan)
        {
            Isim = isim;
            Unvan = unvan;
        }
    }
}
