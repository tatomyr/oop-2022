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
using WindowsFormsApp1.Services;

namespace WindowsFormsApp1.Forms
{
    public partial class StorageEditForm : Form
    {
        private Storage item;

        public StorageEditForm()
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
            set { this.item = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StorageService storageService = new StorageService();

            if (storageService.Update(this.item, textBox1.Text, numericUpDown1.Value, numericUpDown2.Value) == 1)
            {
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }

        private void StorageEditForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.item.Name;
            numericUpDown1.Value = this.item.DryStorageSpace;
            numericUpDown2.Value = this.item.ColdStorageSpace;
            RefreshTotalSize();
        }
    }
}
