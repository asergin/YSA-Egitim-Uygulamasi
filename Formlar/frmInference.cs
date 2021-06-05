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
using static AI.inference;

namespace AI.Formlar
{
    public partial class frmInference : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        List<inference> A_InferenceÜyelikFonksiyonlarıListesi;
        List<inference> B_InferenceÜyelikFonksiyonlarıListesi;
        List<inference> C_InferenceÜyelikFonksiyonlarıListesi;

        private ConstantLine constantLine;
        private XYDiagram diagram;
        XYDiagramPaneBase myPane;

        public int TextAnnotationIndex = 0;

        public frmInference()
        {
            InitializeComponent();
            diagram = (XYDiagram)chartControl1.Diagram;
            //myPane = diagram.DefaultPane;

        }

        private void btnÇıkış_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmInference_Load(object sender, EventArgs e)
        {
            /*
            A_InferenceÜyelikFonksiyonlarıListesi = new List<inference>();
            A_InferenceÜyelikFonksiyonlarıListesi.Add(new inference() { FonksiyonAdı = fonksiyonAdı.A1.ToString(), a = -20, b = -10, c = 0 });
            A_InferenceÜyelikFonksiyonlarıListesi.Add(new inference() { FonksiyonAdı = fonksiyonAdı.A2.ToString(), a = -10, b = 0, c = 10 });
            B_InferenceÜyelikFonksiyonlarıListesi = new List<inference>();
            B_InferenceÜyelikFonksiyonlarıListesi.Add(new inference() { FonksiyonAdı = fonksiyonAdı.B1.ToString(), a = -10, b = 0, c = 10 });
            B_InferenceÜyelikFonksiyonlarıListesi.Add(new inference() { FonksiyonAdı = fonksiyonAdı.B2.ToString(), a = 0, b = 10, c = 20 });
            C_InferenceÜyelikFonksiyonlarıListesi = new List<inference>();
            C_InferenceÜyelikFonksiyonlarıListesi.Add(new inference() { FonksiyonAdı = fonksiyonAdı.C1.ToString(), a = -20, b = -10, c = 0 });
            C_InferenceÜyelikFonksiyonlarıListesi.Add(new inference() { FonksiyonAdı = fonksiyonAdı.C2.ToString(), a = -10, b = 0, c = 10 });
            C_InferenceÜyelikFonksiyonlarıListesi.Add(new inference() { FonksiyonAdı = fonksiyonAdı.C3.ToString(), a = 0, b = 10, c = 20 });
            C_InferenceÜyelikFonksiyonlarıListesi.Add(new inference() { FonksiyonAdı = fonksiyonAdı.C4.ToString(), a = 10, b = 20, c = 30 });


            bindingSourceA.DataSource = A_InferenceÜyelikFonksiyonlarıListesi;
            gridControlA.DataSource = bindingSourceA;
            gridViewA.BestFitColumns(true);

            bindingSourceB.DataSource = B_InferenceÜyelikFonksiyonlarıListesi;
            gridControlB.DataSource = bindingSourceB;
            gridViewA.BestFitColumns(true);

            bindingSourceC.DataSource = C_InferenceÜyelikFonksiyonlarıListesi;
            gridControlC.DataSource = bindingSourceC;
            gridViewA.BestFitColumns(true);



            //ilkGrafik();
            ilkGrafik2();
            //grafikÇiz();
            */
        }

        private void grafikÇiz()
        {
            /*
            waitFormGöster();

            foreach (var fonk in A_InferenceÜyelikFonksiyonlarıListesi)
            {
                string fonkAdı = fonk.FonksiyonAdı;
                chartControl1.Series[fonkAdı].Points.Clear();

                for (float i = fonk.a; i < fonk.b; i += 0.01f)
                {
                    float deger = fonk.ÜçgenÜyelikFonksiyonu(i, fonk.a, fonk.b, fonk.c);
                    chartControl1.Series[fonkAdı].Points.AddPoint(i, deger);
                }
                for (float i = fonk.b; i < fonk.c; i += 0.01f)
                {
                    float deger = fonk.ÜçgenÜyelikFonksiyonu(i, fonk.a, fonk.b, fonk.c);
                    chartControl1.Series[fonkAdı].Points.AddPoint(i, deger);
                }

            }
            waitFormkapat();
            */
        }

        private void ilkGrafik2()
        {
            /*
            inference Inference = new inference();

            for (float i = -30; i < 30; i += 0.01f)
            {
                float deger = Inference.ÜçgenÜyelikFonksiyonu(i, -20, -10, 0);
                chartControl1.Series["SeriA11"].Points.AddPoint(i, deger);
                chartControl1.Series["SeriA12"].Points.AddPoint(i, deger);
                chartControl1.Series["SeriC1"].Points.AddPoint(i, deger);
            }
            for (float i = -30; i < 30; i += 0.01f)
            {
                float deger = Inference.ÜçgenÜyelikFonksiyonu(i, -10, 0, 10);
                chartControl1.Series["SeriA21"].Points.AddPoint(i, deger);
                chartControl1.Series["SeriA22"].Points.AddPoint(i, deger);
                chartControl1.Series["SeriB11"].Points.AddPoint(i, deger);
                chartControl1.Series["SeriB12"].Points.AddPoint(i, deger);
                chartControl1.Series["SeriC2"].Points.AddPoint(i, deger);
            }
            for (float i = -30; i < 30; i += 0.01f)
            {
                float deger = Inference.ÜçgenÜyelikFonksiyonu(i, 0, 10, 20);
                chartControl1.Series["SeriB21"].Points.AddPoint(i, deger);
                chartControl1.Series["SeriB22"].Points.AddPoint(i, deger);
                chartControl1.Series["SeriC3"].Points.AddPoint(i, deger);
            }
            for (float i = -30; i < 30; i += 0.01f)
            {
                float deger = Inference.ÜçgenÜyelikFonksiyonu(i, 10, 20, 30);
                chartControl1.Series["SeriC4"].Points.AddPoint(i, deger);
            }
            */
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

        private void girişDeğerlendir(string F)
        {
            /*
            try
            {
                //string msg = "";
                txtZ.Clear();
                TextAnnotationIndex = 0;

                if (constantLineDüşey1 != null)
                {
                    diagram.AxisX.ConstantLines.Remove(constantLineDüşey1);
                }
                if (txtX.Text == "-" || txtY.Text == "-")
                {
                    return; //bir tane -'ye izin ver
                }

                if (F == "A")
                {
                    if (string.IsNullOrEmpty(txtX.Text))
                    {
                        //txtZ.Clear();
                        return;
                    }

                    float x = float.Parse(txtX.Text);
                    foreach (var fonk in A_InferenceÜyelikFonksiyonlarıListesi)
                    {
                        string fonkAdı = fonk.FonksiyonAdı;
                        setPane(fonkAdı);
                            
                        //chartControl1.Series[fonkAdı].Points.Clear();
                        float fonkDeğeri = fonk.ÜçgenÜyelikFonksiyonu(x, fonk.a, fonk.b, fonk.c);
                        if (fonkDeğeri > 0)
                        {
                            noktaGöster(x, fonkDeğeri, fonkAdı);
                        }
                        //msg += fonkAdı + "=" + fonkDeğeri + "\n";
                    }
                    grafiğeÇizgiEkle(x,"A");
                }
                else
                {
                    //if (string.IsNullOrEmpty(txtY.Text))
                    //{
                    //    txtZ.Clear();
                    //    return;
                    //}

                    float x = float.Parse(txtY.Text);
                    foreach (var fonk in B_InferenceÜyelikFonksiyonlarıListesi)
                    {
                        string fonkAdı = fonk.FonksiyonAdı;
                        setPane(fonkAdı);
                        //chartControl1.Series[fonkAdı].Points.Clear();
                        float fonkDeğeri = fonk.ÜçgenÜyelikFonksiyonu(x, fonk.a, fonk.b, fonk.c);
                        if (fonkDeğeri > 0)
                        {
                            noktaGöster(x, fonkDeğeri, fonkAdı);
                        }
                        //msg += fonkAdı + "=" + fonkDeğeri + "\n";
                    }
                    grafiğeÇizgiEkle(x, "B");
                }

                //txtZ.Text = msg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }

        private void setPane(string fonkAdı)
        {
            if (fonkAdı=="A1")
            {
                myPane = diagram.DefaultPane;
            }
            else if (fonkAdı == "A2")
            {
                myPane = diagram.Panes["PaneA21"];
            }
            else if (fonkAdı == "B1")
            {
                myPane = diagram.Panes["PaneB11"];
            }
            else if (fonkAdı == "B2")
            {
                myPane = diagram.Panes["PaneB21"];
            }
        }

        private void grafiğeÇizgiEkle(float x, string F)
        {
            //diagram.AxisX.ConstantLines.Remove(constantLineDüşey1);

            constantLine = new ConstantLine("");
            diagram.AxisX.ConstantLines.Add(constantLine);
            //
            //diagram.AxisY.ConstantLines.Add(constantLineDüşey1);
            //
            constantLine.AxisValue = x;
            constantLine.Visible = true;
            constantLine.ShowInLegend = false;
            constantLine.ShowBehind = false;
            constantLine.Color = Color.Red;
            constantLine.LineStyle.DashStyle = DashStyle.Dash;
            constantLine.LineStyle.Thickness = 1;


        }
        private void noktaGöster(float x, float fonkDeğeri, string fonkAdı)
        {
            myPane.Annotations.AddTextAnnotation(fonkAdı, fonkAdı + "=" + fonkDeğeri);
            TextAnnotation TextAnnotation = (TextAnnotation)myPane.Annotations[TextAnnotationIndex];
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

        private void txtX_KeyUp(object sender, KeyEventArgs e)
        {
            girişDeğerlendir("A");
        }

        private void txtY_KeyUp(object sender, KeyEventArgs e)
        {
            girişDeğerlendir("B");
        }

        private void btnTemizle_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (myPane != null)
            {
                myPane.Annotations.Clear();
            }
            if (constantLine != null)
            {
                diagram.AxisX.ConstantLines.Remove(constantLine);
            }
            chartControl1.Refresh();


        }
    }
}