using CSProjeDemo2.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.Concrete
{
    public class MaasBordro
    {
        private readonly List<Personel> _personeller;
        private readonly string _ay;
        private readonly int _yil;

        public MaasBordro(List<Personel> personeller)
        {
            _personeller = personeller;
            _ay = DateTime.Now.ToString("MMMM");
            _yil = DateTime.Now.Year;
        }

        public void MaasBordrolariniOlustur()
        {
            foreach (Personel personel in _personeller)
            {
                Console.Write($"{personel.Isim} için çalışma saatini giriniz: ");
                decimal calismaSaati = decimal.Parse(Console.ReadLine());
                decimal maas = personel.MaasHesapla(calismaSaati);
                _MaasBordrosunuKaydet(personel, calismaSaati, maas);
            }

            _YetersizCalismaSaatiRaporu();
        }

        private void _MaasBordrosunuKaydet(Personel personel, decimal calismaSaati, decimal maas)
        {
            string klasorAdi = $@"{_yil}\{_ay}\{personel.Unvan}";
            Directory.CreateDirectory(klasorAdi);
            string dosyaAdi = $@"{klasorAdi}\{personel.Isim}_{_yil}_{_ay}.json";

            using (StreamWriter writer = new StreamWriter(dosyaAdi))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    PersonelIsmi = personel.Isim,
                    CalismaSaati = calismaSaati,
                    AnaOdeme = maas
                }, Formatting.Indented);
                writer.Write(json);
            }

            Console.WriteLine($"{personel.Isim} için maaş bordrosu oluşturuldu: {dosyaAdi}");
        }

        private void _YetersizCalismaSaatiRaporu()
        {
            const int minimumCalismaSaati = 150;
            List<Personel> yetersizCalismaSaatiListesi = new List<Personel>();

            foreach (Personel personel in _personeller)
            {
                if (personel.MaasHesapla(personel.CalismaSaati) < minimumCalismaSaati)
                {
                    yetersizCalismaSaatiListesi.Add(personel);
                }
            }

            if (yetersizCalismaSaatiListesi.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"{minimumCalismaSaati} saatten az çalışan personeller:");
                foreach (Personel personel in yetersizCalismaSaatiListesi)
                {
                    Console.WriteLine($"- {personel.Isim} ({personel.Unvan}) - {personel.CalismaSaati} saat");
                }
            }
        }
    }

}