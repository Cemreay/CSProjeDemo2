using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public static class MaasBordro
    {
        public static List<Personel> yuzelli = new List<Personel>();
        public static void BordroOlustur(List<Personel> personelListesi)
        {
            decimal calismaSaati = 0;
            foreach (var personel in personelListesi)
            {
                Console.WriteLine($"Maaş Bordrosu, {DateTime.Now:MMMM yyyy}");
                Console.WriteLine($"Personel Adı: {personel.Ad}");

                bool gecerliGiris = false;

                while (!gecerliGiris)
                {
                    Console.Write("Çalışma Saati: ");
                    string giris = Console.ReadLine();

                    if (decimal.TryParse(giris, out calismaSaati)) // Değişiklik: girilen değer decimal olarak ayrıştırılıyor
                    {
                        gecerliGiris = true;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz giriş! Lütfen bir sayı girin.");
                    }
                }

                decimal maas = personel.MaasHesapla((int)calismaSaati); // Değişiklik: calismaSaati değeri decimal olarak kullanılıyor

                decimal ekOdeme = 0;
                if (calismaSaati > 180)
                {
                    ekOdeme = (calismaSaati - 180) * personel.SaatlikUcret * 0.5m;
                    //Console.WriteLine($"Mesai: {ekOdeme:C}");
                }

                decimal toplamOdeme = maas + ekOdeme;

                // Maaş bilgileri ekrana yazdırılır
                Console.WriteLine($"Ana Ödeme: {maas:C}");
                Console.WriteLine($"Mesai: {ekOdeme:C}");
                Console.WriteLine($"Toplam Ödeme: {toplamOdeme:C}");

                // JSON dosyasına kaydedilir
                string dosyaAdi = $"{personel.Ad}_{DateTime.Now:yyyy-MM-dd}.json";
                Kaydet(personel.Ad, calismaSaati, maas, ekOdeme, toplamOdeme, dosyaAdi);

                Console.WriteLine("Maaş Bilgileri Kaydedildi.");
            }

            // 150 saatten az çalışan personellerin bilgileri
            foreach (var personel in personelListesi)
            {
                if (personel.CalismaSaati < 150)
                {
                    yuzelli.Add(personel);

                }

            }
            Console.WriteLine("\n150 saatten az çalışan personeller:");

            foreach (var item in yuzelli)
            {
                Console.WriteLine(item.Ad);

            }
        }

        private static void Kaydet(string ad, decimal calismaSaati, decimal anaOdeme, decimal ekOdeme, decimal toplamOdeme, string dosyaAdi)
        {
            var maaşBilgisi = new
            {
                PersonelIsmi = ad,
                CalismaSaati = calismaSaati,
                AnaOdeme = anaOdeme,
                Mesai = ekOdeme, // Ek ödeme (mesai) ayrı bir alan olarak JSON dosyasına kaydedilir
                ToplamOdeme = toplamOdeme
            };

            string json = JsonConvert.SerializeObject(maaşBilgisi, Formatting.Indented);
            string dosyaYolu = Path.Combine(Environment.CurrentDirectory, ad, dosyaAdi);
            Directory.CreateDirectory(Path.GetDirectoryName(dosyaYolu));
            File.WriteAllText(dosyaYolu, json);
        }

    }
}
