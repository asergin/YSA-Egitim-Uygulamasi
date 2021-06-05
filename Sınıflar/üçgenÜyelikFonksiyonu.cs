using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraCharts;

namespace AI
{
    public class üçgenÜyelikFonksiyonu
    {
        public float a, b, c, x, y;
        public string FonksiyonAdı;
        public string FonksiyonGurubu;

        //**********************************
        public ConstantLine constantLineDüşey1;
        public ConstantLine constantLineDüşey2;
        public ConstantLine constantLineDüşey3;
        public ConstantLine constantLineDüşey4;

        public ConstantLine constantLineYatay1;
        public ConstantLine constantLineYatay2;


        public XYDiagram diagram;
        public XYDiagramPaneBase myPane;
        public int TextAnnotationIndex = 0;

        //****************************************
        public üçgenÜyelikFonksiyonu(string Fonk)
        {
            FonksiyonAdı = Fonk;
            fonksiyonOluştur();
        }

        private void fonksiyonOluştur()
        {
            if (FonksiyonAdı == "A11" || FonksiyonAdı == "A12")
            {
                a = -20;
                b = -10;
                c = 0;
                FonksiyonGurubu = "A";
            }
            else if (FonksiyonAdı == "A21" || FonksiyonAdı == "A22")
            {
                a = -10;
                b = 0;
                c = 10;
                FonksiyonGurubu = "A";
            }
            else if (FonksiyonAdı == "B11" || FonksiyonAdı == "B12")
            {
                a = -10;
                b = 0;
                c = 10;
                FonksiyonGurubu = "B";
            }
            else if (FonksiyonAdı == "B21" || FonksiyonAdı == "B22")
            {
                a = 0;
                b = 10;
                c = 20;
                FonksiyonGurubu = "B";
            }
            else if (FonksiyonAdı == "C1")
            {
                a = -20;
                b = -10;
                c = 0;
                FonksiyonGurubu = "C";
            }
            else if (FonksiyonAdı == "C2")
            {
                a = -10;
                b = 0;
                c = 10;
                FonksiyonGurubu = "C";
            }
            else if (FonksiyonAdı == "C3")
            {
                a = 0;
                b = 10;
                c = 20;
                FonksiyonGurubu = "C";
            }
            else if (FonksiyonAdı == "C4")
            {
                a = 10;
                b = 20;
                c = 30;
                FonksiyonGurubu = "C";
            }
        }

        public float fonksiyonYDeğeri(float X)
        {
            x = X;
            fonksiyonYDeğeriHesapla();
            return y;
        }

        public float FonksiyonXDeğeri(float GelenYDeğeri, string IstenenX)
        {
            float dönüşDeğeri = 0;
            if (GelenYDeğeri == 0)
            {
                if (IstenenX == "X1A" || IstenenX == "X1B")
                {
                    dönüşDeğeri = a;
                }
                else if (IstenenX == "X2A" || IstenenX == "X2B")
                {
                    dönüşDeğeri = c;
                }
            }
            else if (GelenYDeğeri == 1)
            {
                dönüşDeğeri = b;
            }
            else
            {
                if (IstenenX == "X1A" || IstenenX == "X1B")
                {
                    dönüşDeğeri = (GelenYDeğeri * (b - a) + a);
                }
                else if (IstenenX == "X2A" || IstenenX == "X2B")
                {
                    dönüşDeğeri = (GelenYDeğeri * (c - b) - c) * (-1);
                }
            }
            return dönüşDeğeri;
        }
        private void fonksiyonYDeğeriHesapla()
        {
            if (x < a)
            {
                y = 0;
            }
            else if (a <= x && x < b)
            {
                y = (x - a) / (b - a);
            }
            else if (b <= x && x < c)
            {
                y = (c - x) / (c - b);
            }
            else
            {
                y = 0;
            }
        }

        internal void FonksiyonNoktalarınıİşle(float v0, float u0, string TextBoxİsmi)
        {
            NoktaAnnotationlarınıDüzenle(v0, u0, TextBoxİsmi);
            NoktaYatayDüşeyÇizgileriniDüzenle(v0, u0, TextBoxİsmi);
        }

        private void NoktaYatayDüşeyÇizgileriniDüzenle(float v0, float u0, string TextBoxİsmi)
        {
            if (TextBoxİsmi == "txtX" && FonksiyonGurubu == "A")
            {
                if (constantLineDüşey1 != null)
                {
                    diagram.AxisX.ConstantLines.Remove(constantLineDüşey1);
                }
                if (constantLineYatay1 != null)
                {
                    diagram.AxisY.ConstantLines.Remove(constantLineYatay1);
                }
                if (y > 0)
                {
                    constantLineDüşey1 = new ConstantLine("");
                    diagram.AxisX.ConstantLines.Add(constantLineDüşey1);
                    constantLineDüşey1.AxisValue = x;
                    constantLineDüşey1.Visible = true;
                    constantLineDüşey1.ShowInLegend = false;
                    constantLineDüşey1.ShowBehind = false;
                    constantLineDüşey1.Color = Color.Red;
                    constantLineDüşey1.LineStyle.DashStyle = DashStyle.Dash;
                    constantLineDüşey1.LineStyle.Thickness = 1;

                    constantLineYatay1 = new ConstantLine("");
                    diagram.AxisY.ConstantLines.Add(constantLineYatay1);
                    constantLineYatay1.AxisValue = y;
                    constantLineYatay1.Visible = true;
                    constantLineYatay1.ShowInLegend = false;
                    constantLineYatay1.ShowBehind = false;
                    constantLineYatay1.Color = Color.Red;
                    constantLineYatay1.LineStyle.DashStyle = DashStyle.Dash;
                    constantLineYatay1.LineStyle.Thickness = 1;
                }

            }
            else if (TextBoxİsmi == "txtY" && FonksiyonGurubu == "B")
            {
                if (constantLineDüşey1 != null)
                {
                    diagram.AxisX.ConstantLines.Remove(constantLineDüşey1);
                }
                if (constantLineYatay1 != null)
                {
                    diagram.AxisY.ConstantLines.Remove(constantLineYatay1);
                }

                if (y > 0)
                {
                    constantLineDüşey1 = new ConstantLine("");
                    diagram.AxisX.ConstantLines.Add(constantLineDüşey1);
                    constantLineDüşey1.AxisValue = x;
                    constantLineDüşey1.Visible = true;
                    constantLineDüşey1.ShowInLegend = false;
                    constantLineDüşey1.ShowBehind = false;
                    constantLineDüşey1.Color = Color.Blue;
                    constantLineDüşey1.LineStyle.DashStyle = DashStyle.Dash;
                    constantLineDüşey1.LineStyle.Thickness = 1;

                    constantLineYatay1 = new ConstantLine("");
                    diagram.AxisY.ConstantLines.Add(constantLineYatay1);
                    constantLineYatay1.AxisValue = y;
                    constantLineYatay1.Visible = true;
                    constantLineYatay1.ShowInLegend = false;
                    constantLineYatay1.ShowBehind = false;
                    constantLineYatay1.Color = Color.Blue;
                    constantLineYatay1.LineStyle.DashStyle = DashStyle.Dash;
                    constantLineYatay1.LineStyle.Thickness = 1;

                }
            }
        }

        private void NoktaAnnotationlarınıDüzenle(float v0, float u0, string TextBoxİsmi)
        {
            TextAnnotation TextAnnotation;
            TextAnnotationIndex = 0;
            if (TextBoxİsmi == "txtX" && FonksiyonGurubu == "A")
            {
                y = fonksiyonYDeğeri(v0);
                myPane.Annotations.Clear();
                if (y > 0)
                {
                    string ad = FonksiyonAdı.Substring(0, 2);
                    myPane.Annotations.AddTextAnnotation(FonksiyonAdı, ad + "=" + y);
                    TextAnnotation = (TextAnnotation)myPane.Annotations[TextAnnotationIndex];
                    TextAnnotationIndex++;
                    ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisXCoordinate.AxisValue = x;
                    ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisYCoordinate.AxisValue = y;

                    TextAnnotation.ShapePosition = new RelativePosition(180, 60);
                    TextAnnotation.RuntimeMoving = true;
                    TextAnnotation.RuntimeAnchoring = true;
                    TextAnnotation.RuntimeResizing = true;
                    TextAnnotation.RuntimeRotation = true;
                    TextAnnotation.ShapeKind = ShapeKind.RoundedRectangle;
                    TextAnnotation.ShapeFillet = 10;
                    TextAnnotation.ConnectorStyle = AnnotationConnectorStyle.Arrow;
                    TextAnnotation.TextColor = Color.Red;
                }
            }
            else if (TextBoxİsmi == "txtY" && FonksiyonGurubu == "B")
            {
                y = fonksiyonYDeğeri(u0);
                myPane.Annotations.Clear();

                if (y > 0)
                {
                    string ad = FonksiyonAdı.Substring(0, 2);
                    myPane.Annotations.AddTextAnnotation(FonksiyonAdı, ad + "=" + y);
                    TextAnnotation = (TextAnnotation)myPane.Annotations[TextAnnotationIndex];
                    TextAnnotationIndex++;
                    ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisXCoordinate.AxisValue = x;
                    ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisYCoordinate.AxisValue = y;

                    TextAnnotation.ShapePosition = new RelativePosition(180, 60);
                    TextAnnotation.RuntimeMoving = true;
                    TextAnnotation.RuntimeAnchoring = true;
                    TextAnnotation.RuntimeResizing = true;
                    TextAnnotation.RuntimeRotation = true;
                    TextAnnotation.ShapeKind = ShapeKind.RoundedRectangle;
                    TextAnnotation.ShapeFillet = 10;
                    TextAnnotation.ConnectorStyle = AnnotationConnectorStyle.Arrow;
                    TextAnnotation.TextColor = Color.Blue;
                }
            }
        }



        //burda kalmıştım
        void CBlokÇizgileriniÇiz()
        {
            //y = fonksiyonYDeğeri(x);
            TextAnnotation TextAnnotation;
            TextAnnotationIndex = 0;
            temizle();//sadece CBlok üzerindeki ilave çizgi ve noktaları temizler

            if (y > 0)
            {
                string ad = FonksiyonAdı.Substring(0, 2);
                myPane.Annotations.AddTextAnnotation(FonksiyonAdı, ad + "=" + y);
                TextAnnotation = (TextAnnotation)myPane.Annotations[TextAnnotationIndex];
                TextAnnotationIndex++;
                ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisXCoordinate.AxisValue = x;
                ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisYCoordinate.AxisValue = y;

                TextAnnotation.ShapePosition = new RelativePosition(180, 60);
                TextAnnotation.RuntimeMoving = true;
                TextAnnotation.RuntimeAnchoring = true;
                TextAnnotation.RuntimeResizing = true;
                TextAnnotation.RuntimeRotation = true;
                TextAnnotation.ShapeKind = ShapeKind.RoundedRectangle;
                TextAnnotation.ShapeFillet = 10;
                TextAnnotation.ConnectorStyle = AnnotationConnectorStyle.Arrow;
                TextAnnotation.TextColor = Color.Red;

                constantLineDüşey1 = new ConstantLine("");
                diagram.AxisX.ConstantLines.Add(constantLineDüşey1);
                constantLineDüşey1.AxisValue = x;
                constantLineDüşey1.Visible = true;
                constantLineDüşey1.ShowInLegend = false;
                constantLineDüşey1.ShowBehind = false;
                constantLineDüşey1.Color = Color.Red;
                constantLineDüşey1.LineStyle.DashStyle = DashStyle.Dash;
                constantLineDüşey1.LineStyle.Thickness = 1;

                constantLineYatay1 = new ConstantLine("");
                diagram.AxisY.ConstantLines.Add(constantLineYatay1);
                constantLineYatay1.AxisValue = y;
                constantLineYatay1.Visible = true;
                constantLineYatay1.ShowInLegend = false;
                constantLineYatay1.ShowBehind = false;
                constantLineYatay1.Color = Color.Red;
                constantLineYatay1.LineStyle.DashStyle = DashStyle.Dash;
                constantLineYatay1.LineStyle.Thickness = 1;

            }

        }

        private void temizle() //CBlok çizgi temizliği
        {
            myPane.Annotations.Clear();
            if (constantLineDüşey1 != null)
            {
                diagram.AxisX.ConstantLines.Remove(constantLineDüşey1);
            }
            if (constantLineDüşey2 != null)
            {
                diagram.AxisX.ConstantLines.Remove(constantLineDüşey2);
            }

            if (constantLineYatay1 != null)
            {
                diagram.AxisY.ConstantLines.Remove(constantLineYatay1);
            }
            if (constantLineYatay2 != null)
            {
                diagram.AxisY.ConstantLines.Remove(constantLineYatay2);
            }
        }
    }

}
