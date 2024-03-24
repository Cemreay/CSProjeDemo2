using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public abstract class Personel
    {
        public string Ad { get; set; }
        public abstract string Unvan { get; }
        public abstract decimal SaatlikUcret { get; }
        public decimal CalismaSaati { get; set; }

        //Ana maaş hesaplama
        public virtual decimal MaasHesapla(int calismaSaati)
        {
            return SaatlikUcret * calismaSaati;
        }
    }
}
