using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Services;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1.Forms
{
    public partial class AssetManagerForm : Form
    {
        public AssetManagerForm()
        {
            InitializeComponent();
        }

        private void AssetManagerForm_Load(object sender, EventArgs e)
        {
            RefreshListViewItem();
        }


        void RefreshListViewItem()
        {
            AssetServices assetService = new AssetServices();
            List<Asset> assetsList = assetService.GetAllAsset();


            listView1.Items.Clear();

            if (assetsList != null)
            {
                foreach (Asset asset in assetsList)
                {
                    AddListViewItem(asset);
                }


            }
        }



        void AddListViewItem(Asset a)
        {
            ListViewItem item = new ListViewItem(a.Name);
            item.Tag = a;
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, a.SquareMeterVolume.ToString()));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, a.ExpirationDays.ToString()));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, a.StorageType.ToString()));

            listView1.Items.Add(item);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AssetAddForm addForm = new AssetAddForm();
            var result = addForm.ShowDialog();


            if (result == DialogResult.OK)
            {
                AssetServices stService = new AssetServices();
                Asset asset = addForm.Item;

                stService.Add(asset);

                RefreshListViewItem();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AssetEditForm editForm = new AssetEditForm();
            editForm.Item = (Asset)listView1.SelectedItems[0].Tag;
            var result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                RefreshListViewItem();
            }


        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
            }
            else
            {
                toolStripButton2.Enabled = false;
                toolStripButton3.Enabled = false;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this asset ??",
                                    "Confirm Delete!!",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                AssetServices stService = new AssetServices();
                Asset asset = (Asset)listView1.SelectedItems[0].Tag;
                stService.Delete(asset);
                RefreshListViewItem();
            }
        }
    }
}
