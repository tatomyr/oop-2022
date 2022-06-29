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
    public partial class AssetAddForm : Form
    {

        Asset item = null;

        public Asset Item { get => item; set => item = value; }

        public AssetAddForm()
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

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            item = new Asset();
            item.Name = textBox1.Text;
            item.StorageType = (StorageType)Enum.Parse(typeof(StorageType), comboBox1.SelectedItem.ToString());
            item.SquareMeterVolume = numericUpDown1.Value;
            item.ExpirationDays = (int)numericUpDown2.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = textBox2.Text;
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.V && e.Modifiers == Keys.Control)
                (sender as TextBox).Paste();
        }
    }
}
