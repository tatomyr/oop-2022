using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1.Forms
{
    public partial class StorageAddForm : Form
    {
        private Storage item;

        public StorageAddForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            RefreshTotalSize();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RefreshTotalSize();
        }

        private void RefreshTotalSize()
        {
            label5.Text = String.Format("{0} m2", numericUpDown1.Value + numericUpDown2.Value);
        }

        public Storage StorageItem
        {
            get { return this.item; }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.item = new Storage();

            this.item.Name = textBox1.Text;
            this.item.DryStorageSpace = numericUpDown1.Value;
            this.item.ColdStorageSpace = numericUpDown2.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
