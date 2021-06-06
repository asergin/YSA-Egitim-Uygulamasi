using DevExpress.Diagram.Core;
using DevExpress.XtraDiagram;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static AI.StatikBilgiler;

namespace AI
{
    class dendrit
    {
        private Random rastgeleUretec;
        public DiagramConnector Konnektör;
        public float Ağırlık { get; set; }
        public float Delta { get; set; }
        internal nöron BaşlangıçNöronu { get; set; }
        internal nöron BitişNöronu { get; set; }

        public Point pointlblAğırlık = new Point();
        string dendritEtiket;
        public List<float> Ağırlıklar = new List<float>();

        public dendrit(nöron başlangıçNöronu, nöron bitişNöronu)
        {
            BaşlangıçNöronu = başlangıçNöronu;
            BitişNöronu = bitişNöronu;

            konnektörÖzellikleriniBelirle();
        }

        private void konnektörÖzellikleriniBelirle()
        {
            dendritEtiket = dendtitEtiketiGetir(BaşlangıçNöronu, BitişNöronu);

            Konnektör = new DiagramConnector();
            Konnektör.Type = ConnectorType.Straight;
            //konnektör.Width = 100;  //???
            Konnektör.Content = dendritEtiket;
            Konnektör.Appearance.BorderColor = BaşlangıçNöronu.nöronDiyagram.Appearance.BorderColor;
            Konnektör.Appearance.ForeColor = BaşlangıçNöronu.nöronDiyagram.Appearance.ForeColor;  //dendrit adı rengi
            Konnektör.BeginItem = BaşlangıçNöronu.nöronDiyagram;
            Konnektör.EndItem = BitişNöronu.nöronDiyagram;
            Konnektör.Appearance.FontSizeDelta = 0; //fontu büyütmek gerekirse kullan
        }
        public void RasgeleAğırlıkAta()
        {
            Thread.Sleep(10);
            rastgeleUretec = new Random();
            Ağırlık = rastgeleUretec.Next(1, 999) / 1000.0f; // 0.001 ve 0.999 arasında rastgele sayılar.
            Ağırlıklar.Add(Ağırlık);    //Ağırlıklar listesinin ilk elemanı burada atanıyor
        }
    }
}
