using CSProjeDemo2.Abstract;
using CSProjeDemo2.Concrete;

namespace ConsoleProjeDemo2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, This is Demo Project!");
            // JSON dosyasından personelleri oku
            List<Personel> personeller = DosyaOku.PersonelleriOku("file.json");

            // Maas bordrosunu oluştur
            MaasBordro maasBordro = new MaasBordro(personeller);
            maasBordro.MaasBordrolariniOlustur();

            // Tüm personellerin raporunu yazdır
            Console.WriteLine();
            Console.WriteLine("Tüm Personellerin Raporu:");
            foreach (Personel personel in personeller)
            {
                Console.WriteLine($"- {personel.Isim} ({personel.Unvan}) - {personel.CalismaSaati} saat - {personel.MaasHesapla(personel.CalismaSaati)} TL");
            }
        }
    }
}