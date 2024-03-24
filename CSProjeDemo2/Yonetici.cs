using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class Yonetici : Personel
    {
        public override string Unvan => "Yonetici";
        public override decimal SaatlikUcret => 500; // Sabit bir saatlik ücret

        public decimal Bonus { get; set; } // Yöneticiye özel bonus

        public Yonetici(string ad)
        {
            Ad = ad;
            Bonus = 0; // Başlangıçta bonus sıfır olarak atanır
        }

        public override decimal MaasHesapla(int calismaSaati)
        {
            // Kullanıcıdan bonus miktarını girmesini isteyelim
            Console.Write($"Lütfen {Ad}'nin bonus miktarını girin: ");
            string bonusGirisi = Console.ReadLine();

            // Bonus miktarını decimal'e çevirirken hata oluşabilir, bu yüzden try-catch kullanıyoruz
            try
            {
                Bonus = Convert.ToDecimal(bonusGirisi);
            }
            catch (FormatException)
            {
                Console.WriteLine("Geçersiz bonus miktarı girişi!");
            }

            // Yönetici için maaş hesaplama
            decimal anaMaas = base.MaasHesapla(calismaSaati);
            return anaMaas + Bonus; // Maaşa bonus ekleniyor
        }
    }
}
