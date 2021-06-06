using DevExpress.Diagram.Core;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraDiagram;
using static AI.StatikBilgiler;
using Excel = Microsoft.Office.Interop.Excel;

namespace AI
{
    public partial class frmYSA : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ağ Ağ;
        RepositoryItemSpinEdit spinEdit = new RepositoryItemSpinEdit();

        public frmYSA()
        {
            InitializeComponent();
            btnGizliKatmanSil.ItemClick += btnGizliKatmanEkle_ItemClick;
            chkOR.ItemClick += chkAND_ItemClick;
            chkXOR.ItemClick += chkAND_ItemClick;
            chkDiğer.ItemClick += chkAND_ItemClick;


        }

        private void btnÇıkış_ItemClick(object sender, ItemClickEventArgs e)
        {
            Kapat();
        }

        private void Kapat()
        {
            Close();
        }

        private void gridViewKatmanBilgileri_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //burada, grid üzerinde değişiklik yapıldığındaki etkinleştirme aktif/pasif yapılacak
            GridView view = sender as GridView;
            int rowHandle = view.FocusedRowHandle;

            //Katman Adı Gridden değiştirilememeli
            if (view.FocusedColumn.FieldName == "KatmanAdı")
            {
                e.Valid = false;
                e.ErrorText = "Bu Bilgiyi Değiştiremezsiniz!";
            }

            //katman No, gridden değiştirilemez                 
            if (view.FocusedColumn.FieldName == "KatmanNo")
            {
                e.Valid = false;
                e.ErrorText = "Bu Bilgiyi Değiştiremezsiniz!";
            }


            string katman = view.GetRowCellValue(rowHandle, "KatmanAdı").ToString();
            if ((katman == "GirişKatmanı" || katman == "ÇıkışKatmanı") && view.FocusedColumn.FieldName == "NöronSayısı")
            {
                int sayı = int.Parse(e.Value.ToString());

                //if (!int.TryParse(e.Value as String, out sayı))
                //{
                //    e.Valid = false;
                //    e.ErrorText = "Buraya Sadece Tamsayı Değeri Giriniz.";
                //}
                if (sayı < 1)
                {
                    e.Valid = false;
                    e.ErrorText = "Giriş Veya Çıkış Katmanı Nöron Sayıları 1'den küçük Olamaz";
                }
                //e.Valid = false;
                //e.ErrorText = "Bu değişikliği buradan yapmayın";
                //double price = 0;
                //if (!Double.TryParse(e.Value as String, out price))
                //{
                //    e.Valid = false;
                //    e.ErrorText = "Only numeric values are accepted.";
                //}
                //else if (price <= 0)
                //{
                //    e.Valid = false;
                //    e.ErrorText = "The unit price must be positive.";
                //}
            }

            if ((katman == "ÇıkışKatmanı") && view.FocusedColumn.FieldName == "NöronSayısı" && Ağ.Kapı != gate.DIGER)
            {
                int sayı = int.Parse(e.Value.ToString());
                if (sayı > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "Lojik Kapıların Çıkış Sayısı 1 olmalıdır.";
                }
            }

            if ((katman == "GirişKatmanı") && view.FocusedColumn.FieldName == "NöronSayısı" && Ağ.Kapı != gate.DIGER)
            {
                int sayı = int.Parse(e.Value.ToString());
                if (sayı != 3)
                {
                    e.Valid = false;
                    e.ErrorText = "Lojik Kapıların Giriş Nöron Sayısını değiştiremezsiniz!.";
                }
            }
            if (katman == "GizliKatman" && view.FocusedColumn.FieldName == "NöronSayısı")
            {
                int sayı = int.Parse(e.Value.ToString());
                //if (!int.TryParse(e.Value as String, out sayı))
                //{
                //    e.Valid = false;
                //    e.ErrorText = "Buraya Sadece Tamsayı Değeri Giriniz.";
                //}
                if (sayı < 2)
                {
                    e.Valid = false;
                    e.ErrorText = "Gizli Katman Nöron Sayıları 2'den küçük Olamaz";
                }
            }


            if (katman == "GirişKatmanı" && view.FocusedColumn.FieldName == "AktivasyonFonksiyonu")
            {
                e.Valid = false;
                e.ErrorText = "Giriş Katmanının Aktivasyon Fonksiyonu Yoktur. Bu değişikliği yapmanız gereksiz!";
            }
            if (e.Valid == true) Ağ.AğHazır = false;

        }

        private void btnGizliKatmanEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            xtraTabControlVeriler.SelectedTabPage = xtraTabPageKatmanBilgileri;

            if (e.Item.Caption == ("Gizli Katman Ekle"))
            {
                Ağ.GizliKatmanEkleSil("Ekle");
            }
            else
            {
                Ağ.GizliKatmanEkleSil("Sil");
            }
            KatmanListesiniGrideBindet(Ağ.KatmanListesi);

        }

        private void frmYSA_Load(object sender, EventArgs e)
        {
            Ağ = new ağ(gate.AND);
            KatmanListesiniGrideBindet(Ağ.KatmanListesi);
            VeriSetiniGrideBindet(Ağ.view);

            gridControlKatmanBilgileri.RepositoryItems.Add(spinEdit);
            gridViewKatmanBilgileri.Columns["NöronSayısı"].ColumnEdit = spinEdit;


            //colModelPrice.DisplayFormat.FormatType = Utils.FormatType.Numeric;
            //colModelPrice.DisplayFormat.FormatString = "c0";
        }

        private void VeriSetiniGrideBindet(DataView view)
        {
            bindingSourceVeriSeti.DataSource = Ağ.view;
            gridControlVeriSeti.DataSource = bindingSourceVeriSeti;
            gridViewVeriSeti.BestFitColumns(true);
        }

        private void KatmanListesiniGrideBindet(List<katman> katmanListesi)
        {
            bindingSourceKatmanBilgileri.DataSource = katmanListesi;
            gridControlKatmanBilgileri.DataSource = bindingSourceKatmanBilgileri;
            gridViewKatmanBilgileri.BestFitColumns(true);
            summaryHesapla();
        }
        private void summaryHesapla()
        {
            gridViewKatmanBilgileri.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridViewKatmanBilgileri.Columns[0].SummaryItem.DisplayFormat = "{0} Katman";
            gridViewKatmanBilgileri.Columns[0].SummaryItem.Tag = 1;
            gridViewKatmanBilgileri.RefreshData();

            gridViewKatmanBilgileri.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridViewKatmanBilgileri.Columns[2].SummaryItem.DisplayFormat = "{0} Nöron";
            gridViewKatmanBilgileri.Columns[2].SummaryItem.Tag = 1;
        }

        private void chkAND_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ağ.AğHazır = false;
            xtraTabControlVeriler.SelectedTabPage = xtraTabPageVeriSeti;
            if (e.Item.Name == "chkAND")
            {
                chkAND.Checked = true;
                chkOR.Checked = false;
                chkXOR.Checked = false;
                chkDiğer.Checked = false;
                Ağ.Kapı = gate.AND;
                RPGDışarıdanVeriAl.Visible = false;
            }
            else if (e.Item.Name == "chkOR")
            {
                chkAND.Checked = false;
                chkOR.Checked = true;
                chkXOR.Checked = false;
                chkDiğer.Checked = false;
                Ağ.Kapı = gate.OR;
                RPGDışarıdanVeriAl.Visible = false;
                //VeriSeti = new veriSeti(gate.OR);

            }
            else if (e.Item.Name == "chkXOR")
            {
                chkAND.Checked = false;
                chkOR.Checked = false;
                chkXOR.Checked = true;
                chkDiğer.Checked = false;
                Ağ.Kapı = gate.XOR;
                RPGDışarıdanVeriAl.Visible = false;
                //VeriSeti = new veriSeti(gate.XOR);

            }
            else
            {
                chkAND.Checked = false;
                chkOR.Checked = false;
                chkXOR.Checked = false;
                chkDiğer.Checked = true;
                RPGDışarıdanVeriAl.Visible = true;
                Ağ.Kapı = gate.DIGER;
                Ağ.view.Table.Clear();
                //Ağ.VeriSetiHazır = false;

            }
            KatmanListesiniGrideBindet(Ağ.KatmanListesi);
            VeriSetiniGrideBindet(Ağ.view);
        }

        private void btnAğıOluştur_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (başlangıçKoşulları() == false) return;     // Şu anda bu komutla sınanacak bir durum yok. Olduğunda aktif et ve kullan
            AğıOluştur();
        }

        private void AğıOluştur()
        {
            diagramıTemizle();
            Ağ.YeniDiyagramHazırla();
            AğıKur();
            diagramControl1.FitToDrawing();
        }

        private void AğıKur()
        {
            foreach (var kont in Ağ.KatmanListesi)
            {
                diagramControl1.Items.Add(kont.container);
            }
            diagramControl1.FitToWidth();
            Application.DoEvents();

            foreach (var konnekt in Ağ.DendritListesi)
            {
                diagramControl1.Items.Add(konnekt.Konnektör);
            }
            Application.DoEvents();
        }
        private void diagramıTemizle()
        {
            diagramControl1.SelectAll();
            diagramControl1.DeleteSelectedItems();
        }

        private void btnDışVeriAl_ItemClick(object sender, ItemClickEventArgs e)
        {
            exceldenVeriAl();
        }
        private void exceldenVeriAl()
        {
            try
            {
                waitFormGöster();
                //Ağ.dt = null;
                Ağ.DışVeriİçinVeriSetiOluştur();
                gridViewVeriSeti.Columns.Clear();
                //bindingSourceVeriSeti.DataSource = dt; //?????????????????

                int satırNo = 0;
                Excel.Application exel = new Excel.Application();
                if (exel == null)
                {
                    MessageBox.Show("Excel yüklü değil!!");
                    return;
                }
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = Missing.Value;

                OpenFileDialog openFile = new OpenFileDialog();
                //openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFile.InitialDirectory = Application.StartupPath + "\\Data\\Excel\\";
                string dosyaYolu = "";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    dosyaYolu = openFile.FileName;
                }
                else
                {
                    waitFormkapat();
                    MessageBox.Show("Dosya Seçilmedi");
                    //Ağ.VeriSetiHazır = false;
                    return;
                }
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkBook = exel.Workbooks.Open(dosyaYolu);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                while (true)
                {
                    satırNo++;
                    string ilk = xlWorkSheet.get_Range("A" + satırNo).Text;
                    if (!string.IsNullOrEmpty(ilk))
                    {
                        DataRow dataRow = Ağ.VeriSeti.dt.NewRow();
                        dataRow["q"] = satırNo;
                        dataRow["x0"] = BiasDeğeri;

                        //girişÇıkışSatırı GirişÇıkışSayısı = new girişÇıkışSatırı();
                        int i;
                        for (i = 1; i < Ağ.VeriSeti.girişSayısı; i++)
                        {
                            dataRow["X" + (i)] = xlWorkSheet.get_Range(hücre(i, satırNo)).Text;
                        }

                        if (Ağ.VeriSeti.çıkışSayısı == 1)
                        {
                            dataRow["Y"] = xlWorkSheet.get_Range(hücre(i, satırNo)).Text;
                        }
                        else
                        {
                            for (int j = 0; j < Ağ.VeriSeti.çıkışSayısı; j++)
                            {
                                dataRow["Y" + j] = xlWorkSheet.get_Range(hücre(i + j, satırNo)).Text;
                            }

                        }
                        Ağ.VeriSeti.dt.Rows.Add(dataRow);
                    }
                    else
                    {
                        break;
                    }
                }
                xlWorkBook.Close(false, misValue, misValue);
                xlApp.Quit();
                Ağ.VeriSetiHazır = true;
                //dataGridViewDoğrulukTablosu.Refresh();
                waitFormkapat();

                Ağ.view = new DataView(Ağ.VeriSeti.dt);
                bindingSourceVeriSeti.DataSource = Ağ.view;
                gridControlVeriSeti.DataSource = bindingSourceVeriSeti;

                gridControlVeriSeti.RefreshDataSource();
                gridViewVeriSeti.RefreshData();
                gridViewVeriSeti.BestFitColumns(true);
                MessageBox.Show(satırNo - 1 + " Adet kayıt Excelden Aktarıldı");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void waitFormkapat()
        {
            splashScreenManager1.CloseWaitForm();
        }
        private void waitFormGöster()
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("Bekleyin");
            splashScreenManager1.SetWaitFormDescription("İşlem sürüyor");
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Kapat();
        }

        private void btnSayfagenişliğineSığdır_ItemClick(object sender, ItemClickEventArgs e)
        {
            diagramControl1.FitToPage();
        }

        private void btnŞekilGenişliğineSığdır_ItemClick(object sender, ItemClickEventArgs e)
        {
            diagramControl1.FitToDrawing();
        }

        private void btnKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                diagramControl1.SaveFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                diagramControl1.ExportDiagram();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnExportPDF_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                diagramControl1.ExportToPdf();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void chkSeçim_ItemClick(object sender, ItemClickEventArgs e)
        {
            chkSeçim.Checked = true;
            chkEl.Checked = false;
            diagramControl1.OptionsBehavior.PointerToolDragMode = PointerToolDragMode.Selection;
        }

        private void chkEl_ItemClick(object sender, ItemClickEventArgs e)
        {
            chkSeçim.Checked = false;
            chkEl.Checked = true;
            diagramControl1.OptionsBehavior.PointerToolDragMode = PointerToolDragMode.Pan;
        }

        private void btnAğıEğit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Ağ.AğHazır == false)
            {
                MessageBox.Show("Önce Ağın Hazırlanması Gerekir");
                return;
            }
            if (Ağ.VeriSetiHazır == false)
            {
                MessageBox.Show("Veri Seti Hazır Değil!");
                return;
            }
            grafikTemizle();
            txtAğırlıklar.Clear();
            kontrolleripasifyap();
            Ağ.AğEğitimVerileriniBelirle(this);
            Ağ.EğitimTamam = false;
            int MaxIterasyonSayısı = int.Parse(barEditItemMaxIterasyon.EditValue.ToString());
            for (int i = 0; i < MaxIterasyonSayısı; i++)
            {
                Ağ.AğıEğit();
                SonuçDeğerleriKontrollerdeGöster(i);

                if (!Ağ.EğitimTamam)    //Eğitim tamamlanmadıysa, ağırlıkları güncelle
                {
                    Ağ.AğırlıklarıGüncelle();
                }
                else
                {
                    break;
                }
            }
            AğırlıklarıListele();

            kontrolleriAktifYap();
        }

        private void AğırlıklarıListele()
        {
            var dendritler = (from dnt in Ağ.DendritListesi
                              orderby dnt.BaşlangıçNöronu.NöronKatmanNo
                              select dnt).ToList();
            foreach (var d in dendritler)
            {
                //int ağırlıkSayısı = d.Ağırlıklar.Count-1;   //çevrimden çıkarken 1 artırıldığı için -1 ile o geri alındı
                //var a = d.Ağırlıklar[ağırlıkSayısı];
                //var b = d.Ağırlık;
                //var c = d.Konnektör.Content;
                string satır = d.Konnektör.Content + " = " + d.Ağırlık;
                txtAğırlıklar.AppendText(satır + Environment.NewLine);
                //txtAğırlıklar.Text += satır+"\n";
                txtAğırlıklar.Find(satır);
                txtAğırlıklar.SelectionColor = d.Konnektör.Appearance.ForeColor;

            }


        }

        private void grafikTemizle()
        {
            chartControl1.Series["Series 1"].Points.Clear();
            chartControl1.RefreshData();
        }

        private void SonuçDeğerleriKontrollerdeGöster(int iterasyon)
        {

            barEditItemToplamKareselHata.EditValue = Ağ.ToplamKareselHata;
            barEditItemMevcutİterason.EditValue = iterasyon + 1;
            if (chkHataGrafiğiniGöster.Checked)
            {
                dockPanel2.Show();  //Grafik nesnesinin bulunduğu paneli göster
                xtraTabControl2.SelectedTabPage = xtraTabPageGrafik;
                chartControl1.Series["Series 1"].Points.AddPoint(iterasyon, Ağ.ToplamKareselHata);
            }
            if (iterasyon % 100 == 0)
            {
                Application.DoEvents();
            }
        }


        private void HatayıGrafikteGöster()
        {

        }

        private void kontrolleripasifyap()
        {
            RPGAğİşlemleri.Enabled = false;
            RPGDışarıdanVeriAl.Enabled = false;
            RPGFonksiyonSeçimi.Enabled = false;
            RPGGizliKatmanEkleSil.Enabled = false;
            RPGKapat.Enabled = false;
            RPGEğitimParametreleri.Enabled = false;
            RPGEğitimVerileri.Enabled = false;
            xtraTabControlVeriler.Enabled = false;
        }

        private void kontrolleriAktifYap()
        {
            RPGAğİşlemleri.Enabled = true;
            RPGDışarıdanVeriAl.Enabled = true;
            RPGFonksiyonSeçimi.Enabled = true;
            RPGGizliKatmanEkleSil.Enabled = true;
            RPGKapat.Enabled = true;
            RPGEğitimParametreleri.Enabled = true;
            RPGEğitimVerileri.Enabled = true;
            xtraTabControlVeriler.Enabled = true;
        }

        private void diagramControl1_DoubleClick(object sender, EventArgs e)
        {
            bool kontrolEdildi = false;
            var item = diagramControl1.CalcHitItem(((MouseEventArgs)e).Location) as DiagramConnector;
            string dendritadı = item.Content;

            if (item != null)
            {

                var dendritler = (from dnt in Ağ.DendritListesi
                                  where dnt.Konnektör.Content == dendritadı
                                  //orderby dnt.BaşlangıçNöronu.NöronKatmanNo
                                  select dnt).ToList();
                foreach (var d in dendritler)
                {
                    if (!kontrolEdildi)
                    {
                        if (d.Ağırlıklar.Count > 0)
                        {
                            kontrolEdildi = true;
                            dockPanel2.Show();  //Grafik nesnesinin bulunduğu paneli göster
                            xtraTabControl2.SelectedTabPage = xtraTabPageAğırlıkGrafik;
                        }
                        else
                        {
                            MessageBox.Show("Eğitim Tamamlanmadı!");
                            break;
                        }
                    }
                    //****************** Ağ eğitildiyse sonrası çalışır            chartControl1.Series["Series 1"].Points.Clear();

                    chartControl2.Series["Series 1"].Points.Clear();
                    chartControl2.RefreshData();


                    for (int i = 0; i < d.Ağırlıklar.Count; i++)
                    {
                        chartControl2.Series["Series 1"].Points.AddPoint(i, d.Ağırlıklar[i]);
                    }
                }
            }

        }
    }
}