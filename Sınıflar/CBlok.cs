using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraCharts;

namespace AI
{

    public class CBlok
    {
        public üçgenÜyelikFonksiyonu ÜyelikFonksiyou;
        public float X1A, X2A, YA, X1B, X2B, YB, Min;
        private int TextAnnotationIndex;
        public List<string> EtkileyenABGrubu = new List<string>();

        public CBlok(üçgenÜyelikFonksiyonu ÜF)
        {
            ÜyelikFonksiyou = ÜF;
            if (ÜyelikFonksiyou.FonksiyonAdı=="C1")
            {
                EtkileyenABGrubu.Add("A11");
                EtkileyenABGrubu.Add("B11");
            }
            else if (ÜyelikFonksiyou.FonksiyonAdı == "C2")
            {
                EtkileyenABGrubu.Add("A12");
                EtkileyenABGrubu.Add("B21");
            }
            else if (ÜyelikFonksiyou.FonksiyonAdı == "C3")
            {
                EtkileyenABGrubu.Add("A21");
                EtkileyenABGrubu.Add("B12");
            }
            else if (ÜyelikFonksiyou.FonksiyonAdı == "C4")
            {
                EtkileyenABGrubu.Add("A22");
                EtkileyenABGrubu.Add("B22");
            }

        }

        private void EtkileyenABGrubuBul()
        {
            throw new NotImplementedException();
        }

        public void CSütunuEksenDeğerleriniGüncelle(inference inference)
        {
            //string FonkGrup = GeldiğiFonksiyon.FonksiyonAdı.Substring(0, 1);
            foreach (var EtkileyenAdı in EtkileyenABGrubu)
            {
                var EtkileyenFonksiyon = inference.ÜçgenÜyelikFonksiyonuGetir(EtkileyenAdı);
                if (EtkileyenFonksiyon.FonksiyonGurubu == "A")
                {
                    YA = EtkileyenFonksiyon.y;
                    X1A = ÜyelikFonksiyou.FonksiyonXDeğeri(YA, "X1A");
                    X2A = ÜyelikFonksiyou.FonksiyonXDeğeri(YA, "X2A");
                }
                else if (EtkileyenFonksiyon.FonksiyonGurubu == "B")
                {
                    YB = EtkileyenFonksiyon.y;
                    X1B = ÜyelikFonksiyou.FonksiyonXDeğeri(YB, "X1B");
                    X2B = ÜyelikFonksiyou.FonksiyonXDeğeri(YB, "X2B");
                }
            }

            if (YA < YB)
                Min = YA;
            else
                Min = YB;
        }
        internal void CSütunuAnnotationGüncelle(inference inference)
        {
            //TextAnnotation TextAnnotation;
            foreach (var EtkileyenAdı in EtkileyenABGrubu)
            {
                TextAnnotationIndex = 0;
                var EtkileyenFonksiyon = inference.ÜçgenÜyelikFonksiyonuGetir(EtkileyenAdı);
                if (EtkileyenFonksiyon.FonksiyonGurubu == "A")
                {
                    if (YA > 0)
                    {
                        //string ad = FonksiyonAdı.Substring(0, 2);
                        TextAnnotation TextAnnotation;
                        ÜyelikFonksiyou.myPane.Annotations.AddTextAnnotation(ÜyelikFonksiyou.FonksiyonAdı, ÜyelikFonksiyou.FonksiyonAdı + "=" + YA);
                        TextAnnotation = (TextAnnotation)ÜyelikFonksiyou.myPane.Annotations[TextAnnotationIndex];
                        TextAnnotationIndex++;
                        ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisXCoordinate.AxisValue = X1A;
                        ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisYCoordinate.AxisValue = YA;

                            

                        ÜyelikFonksiyou.myPane.Annotations.AddTextAnnotation(ÜyelikFonksiyou.FonksiyonAdı, ÜyelikFonksiyou.FonksiyonAdı + "=" + YA);
                        TextAnnotation = (TextAnnotation)ÜyelikFonksiyou.myPane.Annotations[TextAnnotationIndex];
                        TextAnnotationIndex++;
                        ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisXCoordinate.AxisValue = X2A;
                        ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisYCoordinate.AxisValue = YA;


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
                else if (EtkileyenFonksiyon.FonksiyonGurubu == "B")
                {
                    if (YB > 0)
                    {
                        //string ad = FonksiyonAdı.Substring(0, 2);
                        TextAnnotation TextAnnotation;
                        ÜyelikFonksiyou.myPane.Annotations.AddTextAnnotation(ÜyelikFonksiyou.FonksiyonAdı, ÜyelikFonksiyou.FonksiyonAdı + "=" + YB);
                        TextAnnotation = (TextAnnotation)ÜyelikFonksiyou.myPane.Annotations[TextAnnotationIndex];
                        TextAnnotationIndex++;
                        ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisXCoordinate.AxisValue = X1B;
                        ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisYCoordinate.AxisValue = YB;



                        ÜyelikFonksiyou.myPane.Annotations.AddTextAnnotation(ÜyelikFonksiyou.FonksiyonAdı, ÜyelikFonksiyou.FonksiyonAdı + "=" + YB);
                        TextAnnotation = (TextAnnotation)ÜyelikFonksiyou.myPane.Annotations[TextAnnotationIndex];
                        TextAnnotationIndex++;
                        ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisXCoordinate.AxisValue = X2B;
                        ((PaneAnchorPoint)TextAnnotation.AnchorPoint).AxisYCoordinate.AxisValue = YB;


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




            
        }

        internal void Temizle()
        {
            ÜyelikFonksiyou.myPane.Annotations.Clear();
            if (ÜyelikFonksiyou.constantLineDüşey1 != null)
            {
                ÜyelikFonksiyou.diagram.AxisX.ConstantLines.Remove(ÜyelikFonksiyou.constantLineDüşey1);
            }
            if (ÜyelikFonksiyou.constantLineDüşey2 != null)
            {
                ÜyelikFonksiyou.diagram.AxisX.ConstantLines.Remove(ÜyelikFonksiyou.constantLineDüşey2);
            }
            if (ÜyelikFonksiyou.constantLineDüşey3 != null)
            {
                ÜyelikFonksiyou.diagram.AxisX.ConstantLines.Remove(ÜyelikFonksiyou.constantLineDüşey3);
            }
            if (ÜyelikFonksiyou.constantLineDüşey4 != null)
            {
                ÜyelikFonksiyou.diagram.AxisX.ConstantLines.Remove(ÜyelikFonksiyou.constantLineDüşey4);
            }

            if (ÜyelikFonksiyou.constantLineYatay1 != null)
            {
                ÜyelikFonksiyou.diagram.AxisY.ConstantLines.Remove(ÜyelikFonksiyou.constantLineYatay1);
            }
            if (ÜyelikFonksiyou.constantLineYatay2 != null)
            {
                ÜyelikFonksiyou.diagram.AxisY.ConstantLines.Remove(ÜyelikFonksiyou.constantLineYatay2);
            }
        }

        internal void CSütunuYatayDüşeyÇizgileriGüncelle(inference inference)
        {
            if (YA>0)
            {
                ÜyelikFonksiyou.constantLineDüşey1 = new ConstantLine("");
                ÜyelikFonksiyou.diagram.AxisX.ConstantLines.Add(ÜyelikFonksiyou.constantLineDüşey1);
                ÜyelikFonksiyou.constantLineDüşey1.AxisValue = X1A;
                ÜyelikFonksiyou.constantLineDüşey1.Visible = true;
                ÜyelikFonksiyou.constantLineDüşey1.ShowInLegend = false;
                ÜyelikFonksiyou.constantLineDüşey1.ShowBehind = false;
                ÜyelikFonksiyou.constantLineDüşey1.Color = Color.Red;
                ÜyelikFonksiyou.constantLineDüşey1.LineStyle.DashStyle = DashStyle.Dash;
                ÜyelikFonksiyou.constantLineDüşey1.LineStyle.Thickness = 1;

                ÜyelikFonksiyou.constantLineDüşey2 = new ConstantLine("");
                ÜyelikFonksiyou.diagram.AxisX.ConstantLines.Add(ÜyelikFonksiyou.constantLineDüşey2);
                ÜyelikFonksiyou.constantLineDüşey2.AxisValue = X2A;
                ÜyelikFonksiyou.constantLineDüşey2.Visible = true;
                ÜyelikFonksiyou.constantLineDüşey2.ShowInLegend = false;
                ÜyelikFonksiyou.constantLineDüşey2.ShowBehind = false;
                ÜyelikFonksiyou.constantLineDüşey2.Color = Color.Red;
                ÜyelikFonksiyou.constantLineDüşey2.LineStyle.DashStyle = DashStyle.Dash;
                ÜyelikFonksiyou.constantLineDüşey2.LineStyle.Thickness = 1;


                ÜyelikFonksiyou.constantLineYatay1 = new ConstantLine("");
                ÜyelikFonksiyou.diagram.AxisY.ConstantLines.Add(ÜyelikFonksiyou.constantLineYatay1);
                ÜyelikFonksiyou.constantLineYatay1.AxisValue = YA;
                ÜyelikFonksiyou.constantLineYatay1.Visible = true;
                ÜyelikFonksiyou.constantLineYatay1.ShowInLegend = false;
                ÜyelikFonksiyou.constantLineYatay1.ShowBehind = false;
                ÜyelikFonksiyou.constantLineYatay1.Color = Color.Red;
                ÜyelikFonksiyou.constantLineYatay1.LineStyle.DashStyle = DashStyle.Dash;
                ÜyelikFonksiyou.constantLineYatay1.LineStyle.Thickness = 2;
            }
            
            if (YB > 0)
            {
                ÜyelikFonksiyou.constantLineDüşey3 = new ConstantLine("");
                ÜyelikFonksiyou.diagram.AxisX.ConstantLines.Add(ÜyelikFonksiyou.constantLineDüşey3);
                ÜyelikFonksiyou.constantLineDüşey3.AxisValue = X1B;
                ÜyelikFonksiyou.constantLineDüşey3.Visible = true;
                ÜyelikFonksiyou.constantLineDüşey3.ShowInLegend = false;
                ÜyelikFonksiyou.constantLineDüşey3.ShowBehind = false;
                ÜyelikFonksiyou.constantLineDüşey3.Color = Color.Blue;
                ÜyelikFonksiyou.constantLineDüşey3.LineStyle.DashStyle = DashStyle.Dash;
                ÜyelikFonksiyou.constantLineDüşey3.LineStyle.Thickness = 1;

                ÜyelikFonksiyou.constantLineDüşey4 = new ConstantLine("");
                ÜyelikFonksiyou.diagram.AxisX.ConstantLines.Add(ÜyelikFonksiyou.constantLineDüşey4);
                ÜyelikFonksiyou.constantLineDüşey4.AxisValue = X2B;
                ÜyelikFonksiyou.constantLineDüşey4.Visible = true;
                ÜyelikFonksiyou.constantLineDüşey4.ShowInLegend = false;
                ÜyelikFonksiyou.constantLineDüşey4.ShowBehind = false;
                ÜyelikFonksiyou.constantLineDüşey4.Color = Color.Blue;
                ÜyelikFonksiyou.constantLineDüşey4.LineStyle.DashStyle = DashStyle.Dash;
                ÜyelikFonksiyou.constantLineDüşey4.LineStyle.Thickness = 1;


                ÜyelikFonksiyou.constantLineYatay2 = new ConstantLine("");
                ÜyelikFonksiyou.diagram.AxisY.ConstantLines.Add(ÜyelikFonksiyou.constantLineYatay2);
                ÜyelikFonksiyou.constantLineYatay2.AxisValue = YB;
                ÜyelikFonksiyou.constantLineYatay2.Visible = true;
                ÜyelikFonksiyou.constantLineYatay2.ShowInLegend = false;
                ÜyelikFonksiyou.constantLineYatay2.ShowBehind = false;
                ÜyelikFonksiyou.constantLineYatay2.Color = Color.Blue;
                ÜyelikFonksiyou.constantLineYatay2.LineStyle.DashStyle = DashStyle.Dash;
                ÜyelikFonksiyou.constantLineYatay2.LineStyle.Thickness = 2;
            }

        }
    }

}
