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

    class katman
    {
        public katmanAdı KatmanAdı { get; set; }
        public int KatmanNo { get; set; }
        public int NöronSayısı { get; set; } = 3;
        public List<nöron> NöronListesi = new List<nöron>();
        public aktivasyonFonksiyonu AktivasyonFonksiyonu { get; set; }
        public bool BiasVar = true;
        public int BiasDeğeri;

        //public bool BiasVar
        //{
        //    get { return biasVar; }
        //    set
        //    {
        //        if (value == true)
        //        {
        //            biasDeğeri = BiasDeğeri;
        //        }
        //        else
        //        {
        //            biasDeğeri = 0;
        //        }
        //        biasVar = value;
        //    }
        //}
        //public int BiasDeğeri
        //{
        //    get { return biasDeğeri; }
        //    set
        //    {
        //        if (value == 0)
        //        {
        //            biasVar = false;
        //        }
        //        else
        //        {
        //            biasVar = true;
        //        }
        //        biasDeğeri = value;
        //    }
        //}

        public int ToplamKatmanSayısı;// { get; private set; }

        public DiagramContainer container;

        public katman()
        {
            this.BiasDeğeri =StatikBilgiler.BiasDeğeri;

        }
        public void katmanDiyagramınıHazırla()
        {
            //Konteyner, nöronları,
            int konteynerYüksekliği = NöronSayısı * 70 + 50;
            container = new DiagramContainer((KatmanNo - 1) * 150 + 25, 50, 70, konteynerYüksekliği);  //sol üst köşenin koordinatları, en, boy
            container.ShowHeader = true;
            container.Header = konteynırBaşlığıAl();
            //containerGirişKatmanı.Shape = StandardContainers.Corners;
            container.Shape = StandardContainers.Banner;
            //container.Padding = Padding.Empty;        //birşeyler ters giderse burayı işle


        }
        private string konteynırBaşlığıAl()
        {
            switch (KatmanAdı)
            {
                case katmanAdı.GirişKatmanı: return "GİRİŞ KATMANI";
                case katmanAdı.GizliKatman: return "GİZLİ KATMAN " + (KatmanNo - 1);
                default: return "ÇIKIŞ KATMANI";
            }
        }
        internal void KonteynerleriOluştur(katman k, int toplamKatmanSayısı)
        {
            ToplamKatmanSayısı = toplamKatmanSayısı;
            katmanDiyagramınıHazırla();
            nöronlarıHazırla();
            nöronlarıContainereYerleştir();
        }
        private void nöronlarıContainereYerleştir()
        {
            for (int i = 0; i < NöronListesi.Count; i++)
            {
                NöronListesi[i].nöronDiyagram.X = (container.Width / 2) - NöronListesi[i].nöronDiyagram.Width / 2;   //konteynırda ortalamak için
                NöronListesi[i].nöronDiyagram.Y = (i * 60) + 10;  //konteynırda yukarıdan aşağı düzgün dizmek için
                container.Items.Add(NöronListesi[i].nöronDiyagram);
            }
        }

        private void nöronlarıHazırla()
        {
            NöronListesi.Clear();
            for (int i = 0; i < NöronSayısı; i++)
            {
                //nöron Nöron = new nöron(i, konteynerNo, ToplamKatmanSayısı);
                nöron Nöron = new nöron(this, i, ToplamKatmanSayısı);

                NöronListesi.Add(Nöron);
            }


        }

    }
}
