using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AI.StatikBilgiler;

namespace AI
{
    class veriSeti
    {
        private gate Kapı;
        public DataTable dt;
        public int girişSayısı;
        public int çıkışSayısı;

        //public int q { get; set; }
        //public int x0 { get; set; }
        //public int x1 { get; set; }
        //public int x2 { get; set; }
        //public int Y { get; set; }


        public veriSeti(gate kapı)
        {
            Kapı = kapı;
           KapıİçinVeriSetiOluştur();
        }

        public veriSeti(int girişSayısı, int çıkışSayısı)
        {
            this.girişSayısı = girişSayısı;
            this.çıkışSayısı = çıkışSayısı;
            DışVeriİçinVeriSetiOluştur();
        }

        private void DışVeriİçinVeriSetiOluştur()
        {
            dt = new DataTable();
            dt.Columns.Add("q", typeof(int));

            for (int i = 0; i < girişSayısı; i++)
            {
                dt.Columns.Add("x" + i, typeof(float));
            }

            if (çıkışSayısı == 1)
            {
                dt.Columns.Add("Y", typeof(float));
            }
            else
            {
                for (int i = 0; i < çıkışSayısı; i++)
                {
                    dt.Columns.Add("Y" + i, typeof(float));
                }
            }



            dt.AcceptChanges();
        }

        private void KapıİçinVeriSetiOluştur()
        {
            //Kapı için alttaki iki satır bilgi, sabittir
            girişSayısı = 3;
            çıkışSayısı = 1;
            dt = new DataTable();
            dt.Columns.Add("q", typeof(int));

            for (int i = 0; i < 3; i++)
            {
                dt.Columns.Add("x" + i, typeof(float));
            }
            dt.Columns.Add("Y", typeof(float));

            DataRow row;
            for (int i = 0; i < 4; i++)
            {
                row = dt.NewRow();
                row["q"] = i + 1;     //q, 1 den başlıyor
                row["x0"] = X0[i];
                row["x1"] = X1[i];
                row["x2"] = X2[i];
                if (Kapı == gate.AND)
                {
                    row["Y"] = AND_Y[i];
                }
                else if (Kapı == gate.OR)
                {
                    row["Y"] = OR_Y[i];
                }
                else if (Kapı == gate.XOR)
                {
                    row["Y"] = XOR_Y[i];
                }

                dt.Rows.Add(row);
            }

            dt.AcceptChanges();

        }

        
    }
}
