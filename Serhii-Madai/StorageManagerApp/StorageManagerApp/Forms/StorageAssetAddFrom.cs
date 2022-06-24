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
    public partial class StorageAssetAddFrom : Form
    {
        Storage storage;
        List<Asset> assets;
        Asset selectedAsset;
        AssetServices assetService;
        StorageAssetServices saService;

        decimal storageFreeSize;

        public Storage StorageItem
        {
            get { return storage; }
            set { storage = value; }
        }

        public StorageAssetAddFrom()
        {
            InitializeComponent();
            assetService = new AssetServices();
            saService = new StorageAssetServices();
            storageFreeSize = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void StorageAssetAddFrom_Load(object sender, EventArgs e)
        {
            AssetServices assetService = new AssetServices();
            this.Text = String.Format("Add asset to - {0}", this.StorageItem.Name);
            comboBox1.DataSource = Enum.GetValues(typeof(StorageType));
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "Select an item";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != -1)
            {
                StorageType storageType = (StorageType)Enum.Parse(typeof(StorageType), comboBox1.SelectedItem.ToString());


                if (storageType == StorageType.Dry)
                {
                    this.storageFreeSize = this.storage.DryStorageFreeSize;
                }
                else
                {
                    this.storageFreeSize = this.storage.ColdStorageFreeSize;
                }

                textBox1.Text = this.storageFreeSize.ToString("0.00");
                assets = assetService.GetAllAssetByStorageType(storageType);

                comboBox2.Enabled = true;
                button1.Enabled = false;
                comboBox2.DataSource = assets;
                comboBox2.DisplayMember = "Name";
                comboBox2.SelectedIndex = -1;
                comboBox2.Text = "Select an item";
            }
            else
            {
                button1.Enabled = false;
                comboBox2.SelectedIndex = -1;
                comboBox2.Text = "";
                comboBox2.Enabled = false;
                storageFreeSize = 0;
                textBox1.Text = "0.00";
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {

                if (comboBox2.SelectedValue != null)
                {
                    if (comboBox2.SelectedValue is WindowsFormsApp1.Entities.Asset)
                    {
                        selectedAsset = (Asset)comboBox2.SelectedValue;
                        SetAssetTotalVolume(numericUpDown1.Value / selectedAsset.SquareMeterVolume);
                    }
                }
            }
            else
            {
                selectedAsset = null;
                button1.Enabled = false;
                SetAssetTotalVolume(0);
            }
        }


        private void SetAssetTotalVolume(decimal volume)
        {
            textBox2.Text = volume.ToString("0.00");

            textBox2.BackColor = SystemColors.Control;

            if (volume > 0)
            {
                button1.Enabled = true;
            }

            if (volume > storageFreeSize)
            {
                textBox2.BackColor = Color.Pink;
                button1.Enabled = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (selectedAsset != null)
            {
                SetAssetTotalVolume(numericUpDown1.Value / selectedAsset.SquareMeterVolume);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StorageItem stItem = new StorageItem();
            stItem.Volume = (int)numericUpDown1.Value;
            stItem.IncomeDate = DateTime.Now;
            stItem.StorageAsset = selectedAsset;

            if (saService.Add(stItem, storage.Id) == 1)
            {
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }
    }
}
