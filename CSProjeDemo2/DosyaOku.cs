using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public static class DosyaOku
    {
        public static List<Personel> PersonelListesiOku(string dosyaYolu)
        {
            List<Personel> personelListesi = new List<Personel>();

            string json = File.ReadAllText(dosyaYolu);
            var personelBilgileri = JsonConvert.DeserializeObject<List<PersonelBilgisi>>(json);

            foreach (var bilgi in personelBilgileri)
            {
                if (bilgi.Unvan == "Yonetici")
                {
                    personelListesi.Add(new Yonetici(bilgi.Ad));
                }
                else if (bilgi.Unvan == "Memur")
                {
                    personelListesi.Add(new Memur(bilgi.Ad)); // Memurun saatlik ücreti bilgide yok, o yüzden 0 olarak geçiyoruz
                }
            }

            return personelListesi;
        }

        private class PersonelBilgisi
        {
            public string Ad { get; set; }
            public string Unvan { get; set; }
        }
    }
}
