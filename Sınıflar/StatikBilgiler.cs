

using System.Collections.Generic;
using System.Drawing;

namespace AI
{
    public static class StatikBilgiler
    {
        public static int BiasDeğeri = -1;
        public static List<aktivasyonFonksiyonu> aktivasyonFonksiyonuListesi = new List<aktivasyonFonksiyonu>();
        public enum aktivasyonFonksiyonu { Lineer, Sigmoid, Tanh, ReLU }

        //public static aktivasyonFonksiyonu AktivasyonFonksiyonu;
        public enum katmanAdı { GirişKatmanı, GizliKatman, ÇıkışKatmanı }

        public enum nöronTipi { giriş, gizliKatman, Çıkış }
        public enum gate { AND, OR, XOR, DIGER }

        public static int[] X0 = { -1, -1, -1, -1 };
        public static int[] X1 = { 1, 1, 0, 0 };
        public static int[] X2 = { 1, 0, 1, 0 };
        public static int[] AND_Y = { 1, -1, -1, -1 };
        public static int[] OR_Y = { 1, 1, 1, -1 };
        public static int[] XOR_Y = { -1, 1, 1, -1 };


        internal static string nöronEtiketiGetir(nöron nöron)
        {
            if (nöron.NöronKatmanNo == 1) return "x" + nöron.NöronNo; //ilk katmansa, etiket x+nöronNo dur

            //tek gizli katman varsa etiket "h"+NöronNo dur
            if (nöron.NöronKatmanNo == 2 && nöron.ToplamKatmanSayısı == 3) return "h" + nöron.NöronNo;

            //değilse, gizli katman sayısı 1'den fazladır. Bu durumda h nin yanında 2 karakter olacaktır.
            if (nöron.NöronKatmanNo > 1 && nöron.ToplamKatmanSayısı > 3 && nöron.NöronKatmanNo < nöron.ToplamKatmanSayısı) return "h" + (nöron.NöronKatmanNo - 2) + nöron.NöronNo;

            // Buraya kadar gelindiyse nöron çıkış katmanına aittir ve etiket; "Y"+NöronNo
            return "Y" + nöron.NöronNo;
        }
        public static Color renkGetir(int sayı)
        {
            switch (sayı % 8)
            {
                case 1: return Color.Black;
                case 2: return Color.Purple;
                case 3: return Color.Red;
                case 4: return Color.Blue;
                case 5: return Color.Brown;
                case 6: return Color.Yellow;
                case 7: return Color.Orange;
                default: return Color.SeaGreen;
            }

        }

        internal static string dendtitEtiketiGetir(nöron başlangıçNöronu, nöron bitişNöronu)
        {
            string s1 = başlangıçNöronu.nöronEtiket.Remove(0, 1);//ilk karakteri (ilgili harf) kaldır
            string s2 = bitişNöronu.nöronEtiket.Remove(0, 1);//ilk karakteri (ilgili harf) kaldır
            string s3 = s2 + s1;
            switch (başlangıçNöronu.NöronKatmanNo)
            {
                case 1: return "w" + s3; //giriş katmanı için
                case 2: return "v" + s3; //bir sonraki katman için
                case 3: return "u" + s3; //...
                case 4: return "t" + s3; //...
                case 5: return "s" + s3;
                case 6: return "r" + s3;
                case 7: return "q" + s3;
                case 8: return "p" + s3;
                case 9: return "n" + s3;
                case 10: return "m" + s3;
                case 11: return "k" + s3;
                default: return "j" + s3;    //En son, izin verilen en büyük katman sayısı harfi olan 
                                             //12. katman harfi (1 giriş, 10 gizli, 1 çıkış olmak üzere)
            }
        }
        public static string hücre(int i, int satırNo)
        {
            switch (i)
            {
                case 0: return "A" + satırNo;
                case 1: return "B" + satırNo;
                case 2: return "C" + satırNo;
                case 3: return "D" + satırNo;
                case 4: return "E" + satırNo;
                case 5: return "F" + satırNo;
                case 6: return "G" + satırNo;
                case 7: return "H" + satırNo;
                case 8: return "I" + satırNo;
                case 9: return "J" + satırNo;
                case 10: return "K" + satırNo;
                case 11: return "L" + satırNo;
                case 12: return "M" + satırNo;
                case 13: return "N" + satırNo;
                case 14: return "O" + satırNo;
                case 15: return "P" + satırNo;
                case 16: return "Q" + satırNo;
                case 17: return "R" + satırNo;
                case 18: return "S" + satırNo;
                case 19: return "T" + satırNo;
                case 20: return "U" + satırNo;
                case 21: return "V" + satırNo;
                case 22: return "W" + satırNo;
                case 23: return "X" + satırNo;
                case 24: return "Y" + satırNo;
                case 25: return "Z" + satırNo;
                case 26: return "AA" + satırNo;
                case 27: return "AB" + satırNo;
                case 28: return "AC" + satırNo;
                case 29: return "AD" + satırNo;
                case 30: return "AE" + satırNo;
                case 31: return "AF" + satırNo;
                case 32: return "AG" + satırNo;
                case 33: return "AH" + satırNo;
                case 34: return "AI" + satırNo;

                default: return "AJ" + satırNo;
            }
        }

    }
}