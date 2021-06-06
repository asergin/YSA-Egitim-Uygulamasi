using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static AI.StatikBilgiler;

namespace AI
{
    class ağ
    {
        public List<katman> KatmanListesi = new List<katman>();

        public List<dendrit> DendritListesi = new List<dendrit>();
        public DataView view;
        public veriSeti VeriSeti;
        gate kapı;
        public gate Kapı
        {
            get => kapı;
            set
            {
                kapı = value;
                KapıİşlemleriYap();
            }
        }
        public bool AğHazır { get; set; }
        public int MaximumIterasyonSayısı { get; private set; }
        public float MaximumHata { get; private set; }
        public float ÖğrenmeKatsayısı { get; private set; }
        public bool Önceki_w_DeğerleriyleEğitimeBaşla { get; private set; }
        public bool HataGrafiğiniGöster { get; private set; }
        public int VeriSatırıSayısı { get; private set; }
        public int VeriSütunuSayısı { get; private set; }
        public int GirişSayısı { get; private set; }
        public int ÇıkışSayısı { get; private set; }
        public bool RasgeleDendritAğırlıklarıAtandı { get; private set; }
        public bool EğitimTamam { get; internal set; }
        public float ToplamKareselHata { get; internal set; }

        //public List<veriSeti> VeriSetiListesi = new List<veriSeti>();
        public bool VeriSetiHazır = false;
        public ağ()
        {

        }

        public ağ(gate kapı)
        {
            Kapı = kapı;
            //kapıİşlemleriYap();
        }

        private void KapıİşlemleriYap()
        {
            if (this.kapı != gate.DIGER)
            {
                KapıİçinVeriSetiOluştur();
                KapıİçinKatmanListesiOluştur();
            }
            else
            {
                VeriSetiHazır = false;
                //????????????????????
                //VeriSetiListesi.Clear();
                //VeriSetiHazır = false;
            }

        }

        public void DışVeriİçinVeriSetiOluştur()
        {
            var GirişKatmanı = (from gk in KatmanListesi where gk.KatmanAdı == katmanAdı.GirişKatmanı select gk).First();
            int GirişSayısı = GirişKatmanı.NöronSayısı;

            var ÇıkışKatmanı = (from çk in KatmanListesi where çk.KatmanAdı == katmanAdı.ÇıkışKatmanı select çk).First();
            int ÇıkışSayısı = ÇıkışKatmanı.NöronSayısı;


            VeriSeti = new veriSeti(GirişSayısı, ÇıkışSayısı);
            view = new DataView(VeriSeti.dt);
            //VeriSetiHazır = true;
        }

        private void KapıİçinKatmanListesiOluştur()
        {
            KatmanListesi.Clear();
            katman Katman = new katman();
            //Katman.AktivasyonFonksiyonu = aktivasyonFonksiyonu.Tanh;
            Katman.KatmanAdı = katmanAdı.GirişKatmanı;
            Katman.KatmanNo = 1;
            Katman.NöronSayısı = 3;
            KatmanListesi.Add(Katman);

            Katman = new katman();
            //Katman.AktivasyonFonksiyonu = aktivasyonFonksiyonu.Sigmoid;
            Katman.KatmanAdı = katmanAdı.ÇıkışKatmanı;
            Katman.KatmanNo = 2;
            Katman.NöronSayısı = 1;
            KatmanListesi.Add(Katman);
        }
        private void KapıİçinVeriSetiOluştur()
        {
            VeriSeti = new veriSeti(Kapı);
            view = new DataView(VeriSeti.dt);
            VeriSetiHazır = true;
        }

        internal void GizliKatmanEkleSil(string EkleSil)
        {
            if (EkleSil == "Ekle")
            {
                katman Gizlikatman = new katman();
                Gizlikatman.KatmanAdı = katmanAdı.GizliKatman;
                Gizlikatman.KatmanNo = KatmanListesi.Count;
                KatmanListesi.Add(Gizlikatman);
            }
            else   // Son eklenen gizli katmanı sil
            {
                if (KatmanListesi.Count > 2)//gizli katman mevcutsa
                {
                    var sonEklenenGizKat = (from k in KatmanListesi
                                            where k.KatmanNo == KatmanListesi.Count - 1
                                            select k).First();
                    KatmanListesi.Remove(sonEklenenGizKat);
                }
                else
                {
                    MessageBox.Show("Bir Ağdaki Çıkış Katmanını Silemezsiniz!");
                    return;
                }
            }
            çıkışKatmanNoGüncelle();
        }

        private void çıkışKatmanNoGüncelle()
        {
            var çıkışKatmanı = (from k in KatmanListesi
                                where k.KatmanAdı == katmanAdı.ÇıkışKatmanı
                                select k).First();
            çıkışKatmanı.KatmanNo = KatmanListesi.Count;
        }

        internal void YeniDiyagramHazırla()
        {
            //DendritListesi.Clear();
            katmanlarıHazırla();
            dendritleriHazırla();
            AğHazır = true;
        }

        private void katmanlarıHazırla()
        {
            //KatmanListesi.Clear();
            foreach (var k in KatmanListesi)
            {
                k.KonteynerleriOluştur(k, KatmanListesi.Count);
            }

            //konteyner Konteynır = new konteyner(i, girişKatmanıNöronSayısı, gizliKatmanNöronSayısı, çıkışKatmanıNöronSayısı, toplamKatmanSayısı);

            KatmanListesi = (from kl in KatmanListesi
                             orderby kl.KatmanNo
                             select kl).ToList();

            foreach (var kl in KatmanListesi)
            {
                foreach (var kn in kl.NöronListesi)
                {
                    kn.AktivasyonFonksiyonu = kl.AktivasyonFonksiyonu;
                }
            }
        }

        private void dendritleriHazırla()
        {
            DendritListesi.Clear();
            //dendrit  Dendrit = new dendrit();
            for (int i = 1; i < KatmanListesi.Count; i++)
            {
                katman konteynır1 = KatmanListesi[i - 1];
                katman konteynır2 = KatmanListesi[i];

                foreach (var knl1 in konteynır1.NöronListesi)
                {
                    foreach (var knl2 in konteynır2.NöronListesi)
                    {
                        if (knl2.biasMı) continue;  // || (knl2.NöronKatmanNo==toplamKatmanSayısı && knl2.NöronNo==0)
                        dendrit Dendrit = new dendrit(knl1, knl2);
                        DendritListesi.Add(Dendrit);

                    }
                }
            }
        }

        internal void AğEğitimVerileriniBelirle(frmYSA frmYSA)
        {
            MaximumIterasyonSayısı = int.Parse(frmYSA.barEditItemMaxIterasyon.EditValue.ToString());
            MaximumHata = float.Parse(frmYSA.barEditItemMaxHata.EditValue.ToString());
            ÖğrenmeKatsayısı = float.Parse(frmYSA.barEditItemÖğrenmeKatSayısı.EditValue.ToString());
            Önceki_w_DeğerleriyleEğitimeBaşla = frmYSA.chkOnceki_W_Degerleri_Ile_Basla.Checked;

            VeriSatırıSayısı = VeriSeti.dt.Rows.Count;
            VeriSütunuSayısı = VeriSeti.dt.Columns.Count;
            GirişSayısı = VeriSeti.girişSayısı;
            ÇıkışSayısı = VeriSeti.çıkışSayısı;
            if (!RasgeleDendritAğırlıklarıAtandı || !Önceki_w_DeğerleriyleEğitimeBaşla)
            {
                RasgeleDendritAğırlıklarıAta();
            }

        }

        private void RasgeleDendritAğırlıklarıAta()
        {
            foreach (var d in DendritListesi)
            {
                d.Ağırlıklar.Clear();   //yeni işlem yapılacağı zaman eski ağırlıklar listesini sıfırla
                d.RasgeleAğırlıkAta();
            }
            RasgeleDendritAğırlıklarıAtandı = true;
        }

        internal void AğıEğit()
        {
            ToplamKareselHata = 0;
            DendritDeltaSıfırla();
            //*******Bu ilk blokta ağın giriş ve beklenen çıkış değerleri nöronlara atanır
            var girişKatmanı = (from gk in KatmanListesi
                                where gk.KatmanAdı == katmanAdı.GirişKatmanı
                                select gk).First();

            var çıkışKatmanı = (from çk in KatmanListesi
                                where çk.KatmanAdı == katmanAdı.ÇıkışKatmanı
                                select çk).First();

            for (int i = 0; i < VeriSatırıSayısı; i++)
            {
                #region giriş-çıkışAta
                int j;
                for (j = 1; j < GirişSayısı + 1; j++)   //j=0; 
                {
                    girişKatmanı.NöronListesi[j - 1].ÇıkışDeğeri = (float)VeriSeti.dt.Rows[i][j];
                }

                for (int k = 0; k < ÇıkışSayısı; k++)
                {
                    çıkışKatmanı.NöronListesi[k].BeklenenÇıkışDeğeri = (float)VeriSeti.dt.Rows[i][k + j];
                }

                #endregion
                //***********Bu blokta veri satırı değerleri için çıkış değer(ler)i hesaplanır******
                VeriSatırıİçinAğıÇalıştır();
                DeltaÇarpanlarınıHesapla();
                DeltaGüncelle();
            }

            if (ToplamKareselHata <= MaximumHata)
            {
                EğitimTamam = true;
            }

        }

        private void DeltaGüncelle()
        {
            var dendritler = (from dnt in DendritListesi
                              orderby dnt.BaşlangıçNöronu.NöronKatmanNo
                              select dnt).ToList();
            foreach (var d in dendritler)
            {
                //d.Delta = ÖğrenmeKatsayısı * d.BaşlangıçNöronu.ÇıkışDeğeri * d.BitişNöronu.DeltaÇarpanı;
                d.Delta += d.BaşlangıçNöronu.ÇıkışDeğeri * d.BitişNöronu.DeltaÇarpanı;
            }

        }

        private void DeltaÇarpanlarınıHesapla()
        {
            var gizliKatmanlar = (from gk in KatmanListesi
                                  where gk.KatmanAdı == katmanAdı.GizliKatman //Gizli katmanlar
                                  orderby gk.KatmanNo descending
                                  select gk).ToList();

            foreach (var k in gizliKatmanlar)
            {
                foreach (var n in k.NöronListesi)
                {
                    if (n.biasMı) continue;
                    var dendritler = (from d in DendritListesi
                                      where d.BaşlangıçNöronu == n
                                      select d).ToList();
                    float geçiciÇarpan = 0;
                    foreach (var dnt in dendritler)
                    {
                        geçiciÇarpan += dnt.Ağırlık * dnt.BitişNöronu.DeltaÇarpanı;
                    }
                    n.DeltaÇarpanı = n.Türev * geçiciÇarpan;
                }
            }
        }

        private void DendritDeltaSıfırla()
        {
            foreach (var dnt in DendritListesi)
            {
                dnt.Delta = 0.0f;
            }
        }

        private void VeriSatırıİçinAğıÇalıştır()
        {
            float satırHatası = 0;  //Tek satır veri seti için toplam hatayı tutup, bu değeri Ağ hatasına aktaracak
            var ağKatmanı = (from k in KatmanListesi
                             where k.KatmanAdı == katmanAdı.GizliKatman     //  != katmanAdı.GirişKatmanı && k.KatmanAdı != katmanAdı.ÇıkışKatmanı  //Giriş ve çıkış katmanı hariç tüm katmanlar
                             orderby k.KatmanNo
                             select k).ToList();
            foreach (var kt in ağKatmanı)
            {
                foreach (var kn in kt.NöronListesi)
                {
                    if (kn.biasMı) continue;
                    var dentritler = (from d in DendritListesi
                                      where d.BitişNöronu == kn
                                      select d).ToList();
                    float nöronNeti = 0;
                    foreach (var dnt in dentritler)
                    {
                        nöronNeti += dnt.Ağırlık * dnt.BaşlangıçNöronu.ÇıkışDeğeri;
                    }
                    kn.GirişDeğeri = nöronNeti;
                    kn.çıkışDeğeriHesapla();
                    kn.TürevHesapla();
                }
            }

            //çıkış katmanında, yukarıdakine ilaveten çıkış hata değerini de hesaplanır
            var çıkışKatı = (from k in KatmanListesi
                             where k.KatmanAdı == katmanAdı.ÇıkışKatmanı  //Giriş ve çıkış katmanı hariç tüm katmanlar
                             select k).ToList();
            foreach (var kt in çıkışKatı)
            {
                foreach (var kn in kt.NöronListesi)
                {
                    var dentritler = (from d in DendritListesi
                                      where d.BitişNöronu == kn
                                      select d).ToList();
                    float nöronNeti = 0;
                    foreach (var dnt in dentritler)
                    {
                        nöronNeti += dnt.Ağırlık * dnt.BaşlangıçNöronu.ÇıkışDeğeri;
                    }
                    kn.GirişDeğeri = nöronNeti;
                    kn.çıkışDeğeriHesapla();
                    kn.TürevHesapla();

                    float fark = kn.BeklenenÇıkışDeğeri - kn.ÇıkışDeğeri;
                    kn.ÇıkışHatası = 0.5f * fark * fark;
                    satırHatası += kn.ÇıkışHatası;
                    kn.DeltaÇarpanı = fark * kn.Türev;
                }
            }
            ToplamKareselHata += satırHatası;
        }

        internal void AğırlıklarıGüncelle()
        {
            var dendritler = (from dnt in DendritListesi
                              orderby dnt.BaşlangıçNöronu.NöronKatmanNo
                              select dnt).ToList();
            foreach (var d in dendritler)
            {
                d.Ağırlık += ÖğrenmeKatsayısı * d.Delta;
                d.Ağırlıklar.Add(d.Ağırlık);
            }
        }
    }
}
