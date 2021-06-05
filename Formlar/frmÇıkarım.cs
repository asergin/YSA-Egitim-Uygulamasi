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
using DevExpress.Utils.Extensions;
using DevExpress.XtraCharts;

namespace AI.Formlar
{
    public partial class frmÇıkarım : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private inference Inference;
        private float v0 = 0;
        private float u0 = 0;
        public frmÇıkarım()
        {
            InitializeComponent();
            txtY.KeyUp += txtX_KeyUp;
        }
        private void btnÇıkış_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmÇıkarım_Load(object sender, EventArgs e)
        {
            ilkGrafik();
        }

        private void ilkGrafik()
        {
            waitFormGöster();
            Inference = new inference();
            foreach (var uFonksiyonu in Inference.ÜçgenÜyelikFonksiyonlarıListesi)
            {
                if (uFonksiyonu.FonksiyonAdı == "A11")
                {
                    uFonksiyonu.diagram = (XYDiagram)chartControlA11.Diagram;
                    uFonksiyonu.myPane = uFonksiyonu.diagram.DefaultPane;
                    for (float i = -30; i < 30; i += 0.01f)
                    {
                        chartControlA11.Series[0].Points.AddPoint(i, uFonksiyonu.fonksiyonYDeğeri(i));
                    }
                }
                else if (uFonksiyonu.FonksiyonAdı == "A12")
                {
                    uFonksiyonu.diagram = (XYDiagram)chartControlA12.Diagram;
                    uFonksiyonu.myPane = uFonksiyonu.diagram.DefaultPane;
                    for (float i = -30; i < 30; i += 0.01f)
                    {
                        chartControlA12.Series[0].Points.AddPoint(i, uFonksiyonu.fonksiyonYDeğeri(i));
                    }
                }
                else if (uFonksiyonu.FonksiyonAdı == "A21")
                {
                    uFonksiyonu.diagram = (XYDiagram)chartControlA21.Diagram;
                    uFonksiyonu.myPane = uFonksiyonu.diagram.DefaultPane;
                    for (float i = -30; i < 30; i += 0.01f)
                    {
                        chartControlA21.Series[0].Points.AddPoint(i, uFonksiyonu.fonksiyonYDeğeri(i));
                    }
                }
                else if (uFonksiyonu.FonksiyonAdı == "A22")
                {
                    uFonksiyonu.diagram = (XYDiagram)chartControlA22.Diagram;
                    uFonksiyonu.myPane = uFonksiyonu.diagram.DefaultPane;
                    for (float i = -30; i < 30; i += 0.01f)
                    {
                        chartControlA22.Series[0].Points.AddPoint(i, uFonksiyonu.fonksiyonYDeğeri(i));
                    }
                }
                else if (uFonksiyonu.FonksiyonAdı == "B11")
                {
                    uFonksiyonu.diagram = (XYDiagram)chartControlB11.Diagram;
                    uFonksiyonu.myPane = uFonksiyonu.diagram.DefaultPane;
                    for (float i = -30; i < 30; i += 0.01f)
                    {
                        chartControlB11.Series[0].Points.AddPoint(i, uFonksiyonu.fonksiyonYDeğeri(i));
                    }
                }
                else if (uFonksiyonu.FonksiyonAdı == "B21")
                {
                    uFonksiyonu.diagram = (XYDiagram)chartControlB21.Diagram;
                    uFonksiyonu.myPane = uFonksiyonu.diagram.DefaultPane;
                    for (float i = -30; i < 30; i += 0.01f)
                    {
                        chartControlB21.Series[0].Points.AddPoint(i, uFonksiyonu.fonksiyonYDeğeri(i));
                    }
                }

                else if (uFonksiyonu.FonksiyonAdı == "B12")
                {
                    uFonksiyonu.diagram = (XYDiagram)chartControlB12.Diagram;
                    uFonksiyonu.myPane = uFonksiyonu.diagram.DefaultPane;
                    for (float i = -30; i < 30; i += 0.01f)
                    {
                        chartControlB12.Series[0].Points.AddPoint(i, uFonksiyonu.fonksiyonYDeğeri(i));
                    }
                }
                else if (uFonksiyonu.FonksiyonAdı == "B22")
                {
                    uFonksiyonu.diagram = (XYDiagram)chartControlB22.Diagram;
                    uFonksiyonu.myPane = uFonksiyonu.diagram.DefaultPane;
                    for (float i = -30; i < 30; i += 0.01f)
                    {
                        chartControlB22.Series[0].Points.AddPoint(i, uFonksiyonu.fonksiyonYDeğeri(i));
                    }
                }
                else if (uFonksiyonu.FonksiyonAdı == "C1")
                {
                    uFonksiyonu.diagram = (XYDiagram)chartControlC1.Diagram;
                    uFonksiyonu.myPane = uFonksiyonu.diagram.DefaultPane;
                    for (float i = -30; i < 30; i += 0.01f)
                    {
                        chartControlC1.Series[0].Points.AddPoint(i, uFonksiyonu.fonksiyonYDeğeri(i));
                    }
                }
                else if (uFonksiyonu.FonksiyonAdı == "C2")
                {
                    uFonksiyonu.diagram = (XYDiagram)chartControlC2.Diagram;
                    uFonksiyonu.myPane = uFonksiyonu.diagram.DefaultPane;
                    for (float i = -30; i < 30; i += 0.01f)
                    {
                        chartControlC2.Series[0].Points.AddPoint(i, uFonksiyonu.fonksiyonYDeğeri(i));
                    }
                }
                else if (uFonksiyonu.FonksiyonAdı == "C3")
                {
                    uFonksiyonu.diagram = (XYDiagram)chartControlC3.Diagram;
                    uFonksiyonu.myPane = uFonksiyonu.diagram.DefaultPane;
                    for (float i = -30; i < 30; i += 0.01f)
                    {
                        chartControlC3.Series[0].Points.AddPoint(i, uFonksiyonu.fonksiyonYDeğeri(i));
                    }
                }
                else if (uFonksiyonu.FonksiyonAdı == "C4")
                {
                    uFonksiyonu.diagram = (XYDiagram)chartControlC4.Diagram;
                    uFonksiyonu.myPane = uFonksiyonu.diagram.DefaultPane;
                    for (float i = -30; i < 30; i += 0.01f)
                    {
                        chartControlC4.Series[0].Points.AddPoint(i, uFonksiyonu.fonksiyonYDeğeri(i));
                    }
                }
                Application.DoEvents();
            }
            waitFormkapat();
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

        private void txtX_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                txtZ.Clear();
                lblmesaj.Caption = "";
                var a = (TextBox)sender;
                var TextBoxİsmi = a.Name;
                if (TextBoxİsmi == "txtX")
                {
                    v0 = float.Parse(txtX.Text);
                }
                else
                {
                    u0 = float.Parse(txtY.Text);
                }

                foreach (var F in Inference.ÜçgenÜyelikFonksiyonlarıListesi)
                {
                    F.FonksiyonNoktalarınıİşle(v0, u0, TextBoxİsmi);
                }
                Inference.CSütununuİşle();
                CUssuGrafikÇiz();
                tazele();
                Z_BulGöster();
            }
            catch (Exception ex)
            {
                timer1.Enabled = true;
                lblmesaj.Caption = ex.Message;
            }

        }

        private void Z_BulGöster()
        {
            txtZ.Text= Inference.Z_Getir().ToString();
        }

        private void CUssuGrafikÇiz()
        {
            chartControlCUssu.Series[0].Points.Clear();

            for (float i = -30; i < 30; i += 0.01f)
            {
                chartControlCUssu.Series[0].Points.AddPoint(i, fonksiyonDeğeriBul(i));
            }
        }

        private double fonksiyonDeğeriBul(float i)
        {
            //float fonksiyonYDeğeri = 0;
            List<float> MinDeğerler = new List<float>();

            foreach (var CFonk in Inference.CBlokListesi)
            {
                float d = CFonk.ÜyelikFonksiyou.fonksiyonYDeğeri(i);
                float e = CFonk.Min;
                if (d<e)
                    MinDeğerler.Add(d);
                else
                    MinDeğerler.Add(e);
            }
            return MinDeğerler.Max(); 
        }

        private void tazele()
        {
            chartControlA11.RefreshData();
            chartControlA12.RefreshData();
            chartControlA21.RefreshData();
            chartControlA22.RefreshData();
            chartControlB11.RefreshData();
            chartControlB12.RefreshData();
            chartControlB21.RefreshData();
            chartControlB22.RefreshData();
            chartControlC1.RefreshData();
            chartControlC2.RefreshData();
            chartControlC3.RefreshData();
            chartControlC4.RefreshData();

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblmesaj.Caption = "";
            timer1.Enabled = false;
        }

        private void txtX_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || (e.KeyChar == 44) || (e.KeyChar == 45) || char.IsControl(e.KeyChar));
        }

        private void txtY_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || (e.KeyChar == 44) || (e.KeyChar == 45) || char.IsControl(e.KeyChar));
        }
    }
}