using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Forms;


namespace WindowsFormsApp1
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void storagesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StorageManagerForm frm_Storages = new StorageManagerForm();

            frm_Storages.MdiParent = this;
            frm_Storages.WindowState = FormWindowState.Maximized;
            frm_Storages.Show();

        }

        private void assetManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssetManagerForm frm_Asset = new AssetManagerForm();

            frm_Asset.MdiParent = this;
            frm_Asset.WindowState = FormWindowState.Maximized;
            frm_Asset.Show();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            StorageManagerForm frm_Storages = new StorageManagerForm();

            frm_Storages.MdiParent = this;
            frm_Storages.WindowState = FormWindowState.Maximized;
            frm_Storages.Show();
        }
    }
}
