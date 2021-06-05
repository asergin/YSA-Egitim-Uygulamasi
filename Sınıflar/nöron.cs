using DevExpress.Diagram.Core;
using DevExpress.XtraDiagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AI.StatikBilgiler;

namespace AI
{
    class nöron
    {
        public float DeltaÇarpanı { get; set; }
        public string nöronEtiket;
        public DiagramShape nöronDiyagram;
        public aktivasyonFonksiyonu AktivasyonFonksiyonu { get; set; }
        public float ÇıkışDeğeri { get; set; }
        public float BeklenenÇıkışDeğeri { get; set; }  // Sadece çıkış katman nöronlarında kullanılacak
        public float Türev { get; set; }
        public float ÇıkışHatası { get; set; }          // Sadece çıkış katman nöronlarında kullanılacak
        public katman Katman { get; private set; }
        public int NöronNo;
        public int ToplamKatmanSayısı;
        public float GirişDeğeri { get; set; }

        public int NöronKatmanNo { get; internal set; }
        public bool biasMı { get; set; }
        private float AktivasyonFonksiyonundanGeçir()
        {
            if (AktivasyonFonksiyonu == aktivasyonFonksiyonu.Lineer) return GirişDeğeri;
            if (AktivasyonFonksiyonu == aktivasyonFonksiyonu.Sigmoid) return (float)(1.0f / (1.0f + Math.Exp(-1 * GirişDeğeri)));
            if (AktivasyonFonksiyonu == aktivasyonFonksiyonu.Tanh) return (float)Math.Tanh(GirişDeğeri);
            //Buraya gelindiyse, kalan tek seçenek (şimdilik) ReLU
            //if (GirişDeğeri > 0) return GirişDeğeri;
            //return 0;
            return Math.Max(0, GirişDeğeri);    //Yukarıdaki iki satır yerine
        }
        internal float AktivasyonFonksiyonuTürevindenGeçirGetir()
        {
            if (AktivasyonFonksiyonu == aktivasyonFonksiyonu.Lineer) return 1;
            if (AktivasyonFonksiyonu == aktivasyonFonksiyonu.Sigmoid) return ÇıkışDeğeri * (1 - ÇıkışDeğeri);
            if (AktivasyonFonksiyonu == aktivasyonFonksiyonu.Tanh) return 1 - ÇıkışDeğeri * ÇıkışDeğeri;
            if (ÇıkışDeğeri > 0) return 1; //Geriye kalan tek ihtimal (şimdilik) ReLU
            return 0;
        }

        public nöron(katman katman, int nöronNo, int toplamKatmanSayısı)
        {
            Katman = katman;
            NöronNo = nöronNo;
            ToplamKatmanSayısı = toplamKatmanSayısı;

            if (NöronNo == 0 && (Katman.KatmanAdı != katmanAdı.ÇıkışKatmanı))
            {
                biasMı = true;
                ÇıkışDeğeri = Katman.BiasDeğeri;
            }
            NöronKatmanNo = Katman.KatmanNo;
            nöronEtiket = nöronEtiketiGetir(this);

            nöronDiyagramÖzellikleriniBelirle();

        }
        private void nöronDiyagramÖzellikleriniBelirle()
        {
            nöronDiyagram = new DiagramShape(BasicShapes.Ellipse, 50, 50, 50, 50);
            nöronDiyagram.Appearance.BorderColor = renkGetir(NöronNo);
            nöronDiyagram.Appearance.ForeColor = nöronDiyagram.Appearance.BorderColor;
            nöronDiyagram.Content = nöronEtiket;
        }
        internal void çıkışDeğeriHesapla()
        {
            ÇıkışDeğeri = AktivasyonFonksiyonundanGeçir();
        }

        internal void TürevHesapla()
        {
            Türev = AktivasyonFonksiyonuTürevindenGeçirGetir();
        }
    }
}
