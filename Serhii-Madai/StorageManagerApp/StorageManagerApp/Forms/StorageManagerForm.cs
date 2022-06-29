using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Services;
using WindowsFormsApp1.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class StorageManagerForm : Form
    {
        public StorageManagerForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }


        private void StorageForm_Load(object sender, EventArgs e)
        {
            RefreshListViewItem();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            if (listView1.SelectedItems.Count == 1)
            {
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
                toolStripButton4.Enabled = true;
                toolStripButton5.Enabled = true;

                toolStripMenuItem2.Enabled = true;
                toolStripMenuItem3.Enabled = true;
                toolStripMenuItem4.Enabled = true;
                toolStripMenuItem5.Enabled = true;


            }
            else {
                toolStripButton2.Enabled = false;
                toolStripButton3.Enabled = false;
                toolStripButton4.Enabled = false;
                toolStripButton5.Enabled = false;
                toolStripMenuItem2.Enabled = false;
                toolStripMenuItem3.Enabled = false;
                toolStripMenuItem4.Enabled = false;
                toolStripMenuItem5.Enabled = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            StorageAddForm addForm = new StorageAddForm();
            var result = addForm.ShowDialog();

            
            if (result == DialogResult.OK)
            {
                StorageService stService = new StorageService();
                Storage storage = addForm.StorageItem;

                stService.Add(storage);

                RefreshListViewItem();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        void RefreshListViewItem()
        {
            
            StorageService stService = new StorageService();
            List<Storage> storages = stService.GetAllStorages();

            listView1.Items.Clear();
            if (storages != null)
            {
                foreach (Storage s in storages)
                {
                    AddListViewItem(s);
                }
            }
        }


        void AddListViewItem(Storage s)
        {
            ListViewItem item = new ListViewItem(s.Name);
            item.Tag = s;
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (s.ColdStorageSpace + s.DryStorageSpace).ToString()));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, s.StorageFreePercent.ToString("P", CultureInfo.InvariantCulture)));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, s.DryStorageSpace.ToString()));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, s.DryStorageFreePercent.ToString("P", CultureInfo.InvariantCulture)));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, s.ColdStorageSpace.ToString()));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, s.ColdStorageFreePercent.ToString("P", CultureInfo.InvariantCulture)));
            listView1.Items.Add(item);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            StorageEditForm editForm = new StorageEditForm();
            editForm.StorageItem = (Storage)listView1.SelectedItems[0].Tag;
            var result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                RefreshListViewItem();
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this storage ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                StorageService stService = new StorageService();
                Storage storage = (Storage)listView1.SelectedItems[0].Tag;
                stService.Delete(storage);
                RefreshListViewItem();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            StorageAssetAddFrom saForm = new StorageAssetAddFrom();
            saForm.StorageItem = (Storage)listView1.SelectedItems[0].Tag;
            var result = saForm.ShowDialog();
            

            if (result == DialogResult.OK)
            {
                RefreshListViewItem();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            StorageDetailsForm detailsFrom = new StorageDetailsForm();
            detailsFrom.MdiParent = this.MdiParent;
            detailsFrom.WindowState = FormWindowState.Maximized;
            detailsFrom.StorageItem = (Storage)listView1.SelectedItems[0].Tag;
            detailsFrom.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            RefreshListViewItem();
        }

        private void StorageManagerForm_Activated(object sender, EventArgs e)
        {
            RefreshListViewItem();
        }
    }
}
