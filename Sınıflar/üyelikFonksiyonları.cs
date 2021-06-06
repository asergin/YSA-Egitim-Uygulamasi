using System;
using System.Linq;

namespace AI
{
    class üyelikFonksiyonları
    {
        //public enum fonksiyonTürü { Üçgen, Yamuk }
        public enum fonksiyonAdı { NB, NM, NL, Z, PL, PM, PB }

        public string FonksiyonAdı { get; set; }
        //public fonksiyonTürü FonksiyonTürü { get; set; }

        public float a { get; set; }
        public float b { get; set; }
        public float c { get; set; }
        //public float d { get; set; }

        public üyelikFonksiyonları()
        {
            //GrafikTürü.Add("Doğru");
            //GrafikTürü.Add("Gauss");
        }

        //*************************************************************************************************
        public float ÜçgenÜyelikFonksiyonu(float x, float a, float b, float c, string FA)
        {

            if (x < a)
            {
                return 0;
            }
            else if (a <= x && x < b)
            {
                if (FA == "NB")
                {
                    return 1;
                }
                return (x - a) / (b - a);
            }
            else if (b <= x && x < c)
            {
                if (FA == "PB")
                {
                    return 1;
                }
                return (c - x) / (c - b);
            }
            else
            {
                return 0;
            }
        }

        public float YamukÜyelikFonksiyonu(float x, float a, float b, float c, float d)
        {
            if (x < a)
            {
                return 0;
            }
            else if (a <= x && x < b)
            {
                return (x - a) / (b - a);
            }
            else if (b <= x && x < c)
            {
                return 1;
            }
            else if (c <= x && x < d)
            {
                return (d - x) / (d - c);
            }
            else
            {
                return 0;
            }
        }

    }
}
