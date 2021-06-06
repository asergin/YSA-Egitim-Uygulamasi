using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid.Views.Grid;
using static AI.üyelikFonksiyonları;

namespace AI.Formlar
{
    public partial class frmUyelikFonk : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        List<üyelikFonksiyonları> ÜyelikFonksiyonlarıListesi;
        private ConstantLine constantLine;
        private XYDiagram diagram;
        XYDiagramPaneBase myPane;

        public int TextAnnotationIndex = 0;

        public frmUyelikFonk()
        {
            InitializeComponent();
            diagram = (XYDiagram)chartControl1.Diagram;
            myPane = diagram.DefaultPane;
        }

        private void btnÇıkış_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmUyelikFonk_Load(object sender, EventArgs e)
        {
            ÜyelikFonksiyonlarıListesi = new List<üyelikFonksiyonları>();
            ÜyelikFonksiyonlarıListesi.Add(new üyelikFonksiyonları() { FonksiyonAdı = fonksiyonAdı.NB.ToString(), a = -40, b = -30, c = -20 });
            ÜyelikFonksiyonlarıListesi.Add(new üyelikFonksiyonları() { FonksiyonAdı = fonksiyonAdı.NM.ToString(), a = -30, b = -20, c = -10 });
            ÜyelikFonksiyonlarıListesi.Add(new üyelikFonksiyonları() { FonksiyonAdı = fonksiyonAdı.NL.ToString(), a = -20, b = -10, c = 0 });
            ÜyelikFonksiyonlarıListesi.Add(new üyelikFonksiyonları() { FonksiyonAdı = fonksiyonAdı.Z.ToString(), a = -10, b = 0, c = 10 });
            ÜyelikFonksiyonlarıListesi.Add(new üyelikFonksiyonları() { FonksiyonAdı = fonksiyonAdı.PL.ToString(), a = 0, b = 10, c = 20 });
            ÜyelikFonksiyonlarıListesi.Add(new üyelikFonksiyonları() { FonksiyonAdı = fonksiyonAdı.PM.ToString(), a = 10, b = 20, c = 30 });
            ÜyelikFonksiyonlarıListesi.Add(new üyelikFonksiyonları() { FonksiyonAdı = fonksiyonAdı.PB.ToString(), a = 20, b = 30, c = 40 });





            bindingSourceUyelikFonk.DataSource = ÜyelikFonksiyonlarıListesi;
            gridControl1.DataSource = bindingSourceUyelikFonk;
            gridView1.BestFitColumns(true);

            //ilkGrafik();
            ilkGrafik2();
            //for (int i = 0; i < 100; i++)
            //{
            //    //chartControl1.Series["NB"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(i, 1));
            //    chartControl1.Series["NB"].Points.AddPoint(i, 1);

            //}


        }

        private void ilkGrafik2()
        {
            üyelikFonksiyonları ÜyelikFonksiyonları = new üyelikFonksiyonları();
            for (float i = -40; i < -20; i += 0.01f)
            {
                float deger = ÜyelikFonksiyonları.ÜçgenÜyelikFonksiyonu(i, -40, -30, -20, "NB");
                chartControl1.Series["NB"].Points.AddPoint(i, deger);
            }
            for (float i = -30; i < -10; i += 0.01f)
            {
                float deger = ÜyelikFonksiyonları.ÜçgenÜyelikFonksiyonu(i, -30, -20, -10, "NM");
                chartControl1.Series["NM"].Points.AddPoint(i, deger);
            }
            for (float i = -20; i < 0; i += 0.01f)
            {
                float deger = ÜyelikFonksiyonları.ÜçgenÜyelikFonksiyonu(i, -20, -10, 0, "NL");
                chartControl1.Series["NL"].Points.AddPoint(i, deger);
            }
            for (float i = -10; i < 10; i += 0.01f)
            {
                float deger = ÜyelikFonksiyonları.ÜçgenÜyelikFonksiyonu(i, -10, 0, 10, "Z");
                chartControl1.Series["Z"].Points.AddPoint(i, deger);
            }
            for (float i = 0; i < 20; i += 0.01f)
            {
                float deger = ÜyelikFonksiyonları.ÜçgenÜyelikFonksiyonu(i, 0, 10, 20, "PL");
                chartControl1.Series["PL"].Points.AddPoint(i, deger);
            }
            for (float i = 10; i < 30; i += 0.01f)
            {
                float deger = ÜyelikFonksiyonları.ÜçgenÜyelikFonksiyonu(i, 10, 20, 30, "PM");
                chartControl1.Series["PM"].Points.AddPoint(i, deger);
            }
            for (float i = 20; i < 40; i += 0.01f)
            {
                float deger = ÜyelikFonksiyonları.ÜçgenÜyelikFonksiyonu(i, 20, 30, 40, "PB");
                chartControl1.Series["PB"].Points.AddPoint(i, deger);
            }

        }

        private void ilkGrafik()
        {
            chartControl1.Series["NB"].Points.AddPoint(-40, 1);
            chartControl1.Series["NB"].Points.AddPoint(-30, 1);
            chartControl1.Series["NB"].Points.AddPoint(-20, 0);

            chartControl1.Series["NM"].Points.AddPoint(-30, 0);
            chartControl1.Series["NM"].Points.AddPoint(-20, 1);
            chartControl1.Series["NM"].Points.AddPoint(-10, 0);

            chartControl1.Series["NL"].Points.AddPoint(-20, 0);
            chartControl1.Series["NL"].Points.AddPoint(-10, 1);
            chartControl1.Series["NL"].Points.AddPoint(0, 0);

            chartControl1.Series["Z"].Points.AddPoint(-10, 0);
            chartControl1.Series["Z"].Points.AddPoint(0, 1);
            chartControl1.Series["Z"].Points.AddPoint(10, 0);

            chartControl1.Series["PL"].Points.AddPoint(0, 0);
            chartControl1.Series["PL"].Points.AddPoint(10, 1);
            chartControl1.Series["PL"].Points.AddPoint(20, 0);

            chartControl1.Series["PM"].Points.AddPoint(10, 0);
            chartControl1.Series["PM"].Points.AddPoint(20, 1);
            chartControl1.Series["PM"].Points.AddPoint(30, 0);

            chartControl1.Series["PB"].Points.AddPoint(20, 0);
            chartControl1.Series["PB"].Points.AddPoint(30, 1);
            chartControl1.Series["PB"].Points.AddPoint(40, 1);

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {


        }

        private void grafikÇiz()
        {
            waitFormGöster();

            foreach (var fonk in ÜyelikFonksiyonlarıListesi)
            {
                string fonkAdı = fonk.FonksiyonAdı;
                chartControl1.Series[fonkAdı].Points.Clear();

                for (float i = fonk.a; i < fonk.b; i += 0.01f)
                {
                    float deger = fonk.ÜçgenÜyelikFonksiyonu(i, fonk.a, fonk.b, fonk.c, fonkAdı);
                    chartControl1.Series[fonkAdı].Points.AddPoint(i, deger);
                }
                for (float i = fonk.b; i < fonk.c; i += 0.01f)
                {
                    float deger = fonk.ÜçgenÜyelikFonksiyonu(i, fonk.a, fonk.b, fonk.c, fonkAdı);
                    chartControl1.Series[fonkAdı].Points.AddPoint(i, deger);
                }

            }
            waitFormkapat();

        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //burada, grid üzerinde değişiklik yapıldığındaki etkinleştirme aktif/pasif yapılacak
            GridView view = sender as GridView;
            int rowHandle = view.FocusedRowHandle;

            if (view.FocusedColumn.FieldName == "FonksiyonAdı")
            {
                e.Valid = false;
                e.ErrorText = "Bu Bilgiyi Değiştiremezsiniz!";
            }


            string alanAdı = view.FocusedColumn.FieldName;
            float aDegeri = float.Parse(view.GetRowCellValue(rowHandle, "a").ToString());
            float bDegeri = float.Parse(view.GetRowCellValue(rowHandle, "b").ToString());
            float cDegeri = float.Parse(view.GetRowCellValue(rowHandle, "c").ToString());

            if (alanAdı == "a")
            {
                var deger = e.Value;
                bool Rakamsal = ExtensionManager.isNumeric(deger.ToString());
                
                
                if (deger == "" || !Rakamsal)
                {
                    e.Valid = false;
                    e.ErrorText = "a değeri boş ya da sayı dışı bir değer olamaz!";
                    return;
                }

                float aYeniDegeri = float.Parse(deger.ToString());

                if (aYeniDegeri > bDegeri)
                {
                    e.Valid = false;
                    e.ErrorText = "a, b'den daha büyük olamaz!";
                    return;
                }
            }

            if (alanAdı == "b")
            {
                var deger = e.Value;
                if (deger == "")
                {
                    e.Valid = false;
                    e.ErrorText = "b değeri boş olamaz!";
                    return;
                }

                float bYeniDegeri = float.Parse(deger.ToString());

                if (bYeniDegeri > cDegeri)
                {
                    e.Valid = false;
                    e.ErrorText = "b, c'den daha büyük olamaz!";
                    return;
                }
                if (bYeniDegeri < aDegeri)
                {
                    e.Valid = false;
                    e.ErrorText = "b, a'dan daha küçük olamaz!";
                    return;
                }


            }

            if (alanAdı == "c")
            {
                var deger = e.Value;
                if (deger == "")
                {
                    e.Valid = false;
                    e.ErrorText = "c değeri boş olamaz!";
                    return;
                }

                float cYeniDegeri = float.Parse(deger.ToString());

                if (cYeniDegeri < bDegeri)
                {
                    e.Valid = false;
                    e.ErrorText = "c, b'den daha küçük olamaz!";
                    return;
                }
            }
        }

        private void btnGrafikÇiz_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtY.Clear();
            txtX.Clear();
            grafikÇiz();
        }

      

        private void txtX_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string msg = "";
                txtY.Clear();
                TextAnnotationIndex = 0;
                myPane.Annotations.Clear();
                if (constantLine!=null)
                {
                    diagram.AxisX.ConstantLines.Remove(constantLine);
                }
                if (string.IsNullOrEmpty(txtX.Text))
                {
                    txtY.Clear();
                }
                else if (txtX.Text=="-")
                {
                    return; //bir tane -'ye izin ver
                }
                else
                {
                    float x = float.Parse(txtX.Text);

                    foreach (var fonk in ÜyelikFonksiyonlarıListesi)
                    {
                        string fonkAdı = fonk.FonksiyonAdı;
                        //chartControl1.Series[fonkAdı].Points.Clear();
                        float fonkDeğeri = fonk.ÜçgenÜyelikFonksiyonu(x, fonk.a, fonk.b, fonk.c, fonkAdı);
                        if (fonkDeğeri>0)
                        {
                            noktaGöster(x, fonkDeğeri, fonkAdı);
                        }
                        msg += fonkAdı+"="+ fonkDeğeri + "\n";
                    }
                    txtY.Text = msg;
                    grafiğeÇizgiEkle(x);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void noktaGöster(float x, float fonkDeğeri, string fonkAdı)
        {
            
            myPane.Annotations.AddTextAnnotation(fonkAdı, fonkAdı + "=" + fonkDeğeri);
            TextAnnotation TextAnnotation = (TextAnnotation) myPane.Annotations[TextAnnotationIndex];
            TextAnnotationIndex++;
            ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisXCoordinate.AxisValue = x;
            ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisYCoordinate.AxisValue = fonkDeğeri;

            TextAnnotation.RuntimeMoving = true;
            TextAnnotation.RuntimeAnchoring = true;
            TextAnnotation.RuntimeResizing = true;
            TextAnnotation.RuntimeRotation = true;
            TextAnnotation.ShapeKind = ShapeKind.RoundedRectangle;
            TextAnnotation.ShapeFillet = 10;
            TextAnnotation.ConnectorStyle = AnnotationConnectorStyle.Arrow;
            TextAnnotation.TextColor = Color.Red;

        }

        private void grafiğeÇizgiEkle(float x)
        {
            diagram.AxisX.ConstantLines.Remove(constantLine);

            constantLine = new ConstantLine("");
            diagram.AxisX.ConstantLines.Add(constantLine);
            constantLine.AxisValue = x;
            constantLine.Visible = true;
            constantLine.ShowInLegend = false;
            constantLine.ShowBehind = false;
            constantLine.Color = Color.Red;
            constantLine.LineStyle.DashStyle = DashStyle.Dash;
            constantLine.LineStyle.Thickness = 1;


        }

        private void txtX_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 46)//. girişini engelle
            //{
            //    e.Handled = true;
            //    return;
            //}

            e.Handled = !(char.IsDigit(e.KeyChar) || (e.KeyChar == 44) || (e.KeyChar == 45) || char.IsControl(e.KeyChar));
        }
        private void waitFormkapat()
        {
            splashScreenManager1.CloseWaitForm();
        }
        private void waitFormGöster()
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("Bekleyin");
            splashScreenManager1.SetWaitFormDescription("Grafik Oluşturuluyor");
        }
    }

    public static class ExtensionManager
    {
        public static bool isNumeric(this string value)
        {
            double oReturn = 0; 
            return double.TryParse(value, out oReturn);
        }
    }
}