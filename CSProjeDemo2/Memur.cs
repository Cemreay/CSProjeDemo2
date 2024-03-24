using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class Memur : Personel
    {
        public override string Unvan => "Memur";
        public override decimal SaatlikUcret => 500; // Sabit bir saatlik ücret

        public Memur(string ad)
        {
            Ad = ad;

        }




        public override decimal MaasHesapla(int calismaSaati)
        {
            decimal anaMaas;
            if (calismaSaati > 180)
            {
                anaMaas = base.MaasHesapla(calismaSaati);

                decimal ekMesaiUcreti = (calismaSaati - 180) * SaatlikUcret * 0.5m;
                return anaMaas + ekMesaiUcreti;
            }
            else
            {
                anaMaas = base.MaasHesapla(calismaSaati);
                return anaMaas;
            }



        }
    }
}
