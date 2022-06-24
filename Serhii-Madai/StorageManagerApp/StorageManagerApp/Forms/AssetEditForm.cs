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
    public partial class AssetEditForm : Form
    {

        Asset item = null;

        public Asset Item { get => item; set => item = value; }

        public AssetEditForm()
        {
            InitializeComponent();
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AssetAddForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.Item.Name;
            comboBox1.Text = this.Item.StorageType.ToString();
            numericUpDown1.Value = this.Item.SquareMeterVolume;
            numericUpDown2.Value = this.Item.ExpirationDays;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AssetServices assetService = new AssetServices();

            if (assetService.Edit(item, textBox1.Text, (StorageType)Enum.Parse(typeof(StorageType),comboBox1.Text), numericUpDown1.Value, (int)numericUpDown2.Value) == 1)
            {
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }
    }
}
