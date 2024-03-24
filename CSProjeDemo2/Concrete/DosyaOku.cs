using CSProjeDemo2.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSProjeDemo2.Concrete
{
    public class DosyaOku
    {
        private readonly string _dosyaAdi;

        public DosyaOku(string dosyaAdi)
        {
            _dosyaAdi = dosyaAdi;
        }

        public static List<Personel> PersonelleriOku(string _dosyaAdi)
        {
            List<Personel> personeller = new List<Personel>();
            using (StreamReader reader = new StreamReader(_dosyaAdi))
            {
                string json = reader.ReadToEnd();
                dynamic data = JsonConvert.DeserializeObject(json);
                foreach (dynamic personelBilgisi in data)
                {
                    string isim = personelBilgisi.name;
                    string unvan = personelBilgisi.title;
                    if (unvan == "Yonetici")
                        personeller.Add(new Yonetici(isim));
                    else if (unvan == "Memur")
                        personeller.Add(new Memur(isim, personelBilgisi.derece));
                }
            }
            return personeller;
        }
    }

}
