using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace AI
{
    public partial class frmDiagram : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmDiagram()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            kapat();
        }

        private void kapat()
        {
            Close();
        }

        private void btnOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Application.StartupPath + "\\Data";
                    openFileDialog.Filter = "xml dosyaları (*.xml)|*.xml";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        var fileStream = openFileDialog.OpenFile();
                        diagramControl1.LoadDocument(fileStream);
                        fileStream.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            diagramControl1.SaveFile();
            MessageBox.Show("Kaydedildi");
        }

        private void btnTemizle_ItemClick(object sender, ItemClickEventArgs e)
        {
            diagramControl1.SelectAll();
            diagramControl1.DeleteSelectedItems();
        }
    }
}