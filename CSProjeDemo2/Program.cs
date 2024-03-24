using CSProjeDemo2;
using System;
using System.Collections.Generic;

namespace CSProjeDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Personel> personelListesi = DosyaOku.PersonelListesiOku(@"C:\Users\Cemre\Desktop\Personel\personel.JSON");


            // Maaş bordrosunu oluştur
            MaasBordro.BordroOlustur(personelListesi);
        }
    }
}

