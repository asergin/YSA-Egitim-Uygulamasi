using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AI.Formlar;
using DevExpress.XtraBars;

namespace AI
{
    public partial class AI : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public AI()
        {
            InitializeComponent();
            btnKapat2.ItemClick += btnkapat_ItemClick;
            btnKapat3.ItemClick += btnkapat_ItemClick;
            btnKapat4.ItemClick += btnkapat_ItemClick;

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmYSA FrmYSA = new frmYSA();
            FrmYSA.ShowDialog();
        }

        private void btnkapat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Kapat();
        }

        private void Kapat()
        {
            Application.Exit();
        }

        private void btnDiagramFormunuAç_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDiagram FrmDiagram = new frmDiagram();
            FrmDiagram.ShowDialog();
        }

        private void btnUyelikFonk_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUyelikFonk FrmÜyelikFonk = new frmUyelikFonk();
            FrmÜyelikFonk.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmInference FrmInference = new frmInference();
            //FrmInference.Show();
            frmÇıkarım FrmÇıkarım=new frmÇıkarım();
            FrmÇıkarım.ShowDialog();
        }
    }
}