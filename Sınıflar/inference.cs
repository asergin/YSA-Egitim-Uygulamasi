using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using static AI.inference;

namespace AI
{
    public class inference
    {
        public List<string> fonksiyonAdı = new List<string> { "A11", "A12", "A21", "A22", "B11", "B21", "B12", "B22", "C1", "C2", "C3", "C4" };
        public List<CBlok> CBlokListesi = new List<CBlok>();

        public List<üçgenÜyelikFonksiyonu> ÜçgenÜyelikFonksiyonlarıListesi
            = new List<üçgenÜyelikFonksiyonu>();

        public inference()
        {
            üyelikFonksiyonListeleriniOluştur();
            CBlokListesiOluştur();
        }

        public üçgenÜyelikFonksiyonu ÜçgenÜyelikFonksiyonuGetir(string ÜyelikFonksiyonuAdı)
        {
            üçgenÜyelikFonksiyonu ÜÜF = null;
            foreach (var ÜF in ÜçgenÜyelikFonksiyonlarıListesi)
            {
                if (ÜF.FonksiyonAdı == ÜyelikFonksiyonuAdı)
                {
                    ÜÜF = ÜF;
                    break;
                }
                    
            }
            return ÜÜF;
        }
        private void CBlokListesiOluştur()
        {
            foreach (var ÜyFonk in ÜçgenÜyelikFonksiyonlarıListesi)
            {
                //string FonkGrup = ÜyFonk.FonksiyonAdı.Substring(0, 1);
                if (ÜyFonk.FonksiyonGurubu == "C")
                {
                    CBlok C_Blok = new CBlok(ÜyFonk);
                    CBlokListesi.Add(C_Blok);
                }
            }
        }

        private void üyelikFonksiyonListeleriniOluştur()
        {
            foreach (var F in fonksiyonAdı)
            {
                üçgenÜyelikFonksiyonu ÜçgenÜyelikFonksiyonu = new üçgenÜyelikFonksiyonu(F);
                ÜçgenÜyelikFonksiyonlarıListesi.Add(ÜçgenÜyelikFonksiyonu);
            }
        }
        public void CSütununuİşle()
        {
            foreach (var CBlok in CBlokListesi)
            {
                CBlok.Temizle();  //annotation ve Yatay/Düşey çizgileri temizle

                CBlok.CSütunuEksenDeğerleriniGüncelle(this);
                //CBlok.CSütunuAnnotationGüncelle(this);
                CBlok.CSütunuYatayDüşeyÇizgileriGüncelle(this);


            }
        }

        internal float Z_Getir()
        {
            float Pay = 0;
            float Payda = 0;
            foreach (var CBlok in CBlokListesi)
            {
                Pay+= CBlok.Min * CBlok.ÜyelikFonksiyou.b;
                Payda += CBlok.Min;
            }
            return (Pay / Payda);
        }
    }

}
