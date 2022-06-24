using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Forms;
using WindowsFormsApp1.Services;

namespace WindowsFormsApp1.Forms
{
    public partial class StorageDetailsForm : Form
    {
        private Storage storage;
        private StorageService storageService;
        private StorageAssetServices storageAssetService;

        public StorageDetailsForm()
        {
            InitializeComponent();
            storageService = new StorageService();
            storageAssetService = new StorageAssetServices();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                toolStripButton2.Enabled = true;
            }
            else
            {
                toolStripButton2.Enabled = false;
            }
        }


        public Storage StorageItem
        {
            get { return this.storage; }
            set { this.storage = value; }
        }
        void RefreshListViewItem()
        {
            listView1.Items.Clear();
            if (storage.StorageItemColection != null)
            {
                foreach (StorageItem sa in storage.StorageItemColection)
                {
                    AddListViewItem(sa);
                }
            }
        }

        void AddListViewItem(StorageItem sa)
        {
            ListViewItem item = new ListViewItem(sa.StorageAsset.Name);
            item.Tag = sa;
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, sa.StorageAsset.StorageType.ToString()));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, sa.SquareMeterVolume.ToString("#.##")));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, sa.IncomeDate.AddDays(sa.StorageAsset.ExpirationDays).ToShortDateString()));

            listView1.Items.Add(item);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            StorageAssetAddFrom saForm = new StorageAssetAddFrom();
            saForm.StorageItem = this.storage;
            var result = saForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                RefreshListViewItem();
            }
        }


        private void AsetDetailsForm_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("{0}", storage.Name);
            RefreshFormData();
        }

        void RefreshFormData()
        {

            this.storage = storageService.GetStorageById(storage.Id);

            label4.Text = storage.Name;
            label5.Text = String.Format("{0} m3", storage.ColdStorageSpace + storage.DryStorageSpace);
            label6.Text = String.Format("{0:F2} m3",  storage.DryStorageFreeSize + storage.ColdStorageFreeSize);

            RefreshSpacePieChart(dryStoragePieChart, "Dry Storage Space", 1 - storage.DryStorageFreePercent, storage.DryStorageFreePercent);
            RefreshSpacePieChart(coldStoragePieChart, "Cold Storage Space", 1 - storage.ColdStorageFreePercent, storage.ColdStorageFreePercent);


            List<AssetVolume> dryAssetsVolume = storage.StorageItemColection
                .Where(a => a.StorageAsset.StorageType == StorageType.Dry)
                .GroupBy(l => l.StorageAsset.Name)
                .Select(cl => new AssetVolume 
                    { 
                        AssetName = cl.First().StorageAsset.Name,
                        Volume = cl.Sum(c => c.SquareMeterVolume)
                    }).ToList();

            RefreshAssetPieChart(dryAssetsPieChart, dryAssetsVolume, "Dry Storage Assets Volume");

            List<AssetVolume> coldAssetsVolume = storage.StorageItemColection
                .Where(a => a.StorageAsset.StorageType == StorageType.Cold)
                .GroupBy(l => l.StorageAsset.Name)
                .Select(cl => new AssetVolume
                {
                    AssetName = cl.First().StorageAsset.Name,
                    Volume = cl.Sum(c => c.SquareMeterVolume)
                }).ToList();

            RefreshAssetPieChart(coldAssetsPieChart, coldAssetsVolume, "Cold Storage Assets Volume");


            RefreshListViewItem();
        }
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            StorageAssetAddFrom saForm = new StorageAssetAddFrom();
            saForm.StorageItem = this.storage;
            var result = saForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                RefreshFormData();
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this storage asset ??",
                        "Confirm Delete!!",
                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                StorageItem item = (StorageItem)listView1.SelectedItems[0].Tag;
                storageAssetService.Delete(item, storage.Id);
                RefreshFormData();
            }
        }

        private void RefreshSpacePieChart(Chart chart, string title, decimal freeSpace, decimal usedSpace)
        {
            //reset your chart series and legends
            chart.Series.Clear();
            chart.Legends.Clear();

            //Add a new Legend(if needed) and do some formating
            chart.Legends.Add("ColdStorageLegend");
            chart.Legends[0].LegendStyle = LegendStyle.Table;
            chart.Legends[0].Docking = Docking.Bottom;
            chart.Legends[0].Alignment = StringAlignment.Center;
            chart.Legends[0].Title = title;
            chart.Legends[0].BorderColor = Color.Black;

            //Add a new chart-series
            string seriesname = "MySeriesName";
            chart.Series.Add(seriesname);
            //set the chart-type to "Pie"
            chart.Series[seriesname].ChartType = SeriesChartType.Pie;

            //Add some datapoints so the series. in this case you can pass the values to this method
            chart.Series[seriesname].Points.AddXY("Used Space", usedSpace);
            chart.Series[seriesname].Points.AddXY("Free Space", freeSpace);

            chart.Series[seriesname].Points[0].Color = Color.LightCoral;
            chart.Series[seriesname].Points[0].IsValueShownAsLabel = true;
            chart.Series[seriesname].Points[0].LabelFormat = "##%";
            chart.Series[seriesname].Points[1].Color = Color.LightBlue;
            chart.Series[seriesname].Points[1].IsValueShownAsLabel = true;
            chart.Series[seriesname].Points[1].LabelFormat = "##%";
        }
        private void RefreshAssetPieChart(Chart chart, List<AssetVolume> assets, string title)
        {
            //reset your chart series and legends
            chart.Series.Clear();
            chart.Legends.Clear();

            //Add a new Legend(if needed) and do some formating
            chart.Legends.Add("StorageLegend");
            chart.Legends[0].LegendStyle = LegendStyle.Table;
            chart.Legends[0].Docking = Docking.Bottom;
            chart.Legends[0].Alignment = StringAlignment.Center;
            chart.Legends[0].Title = title;
            chart.Legends[0].BorderColor = Color.Black;

            //Add a new chart-series
            string seriesname = "StorageSeriesName";
            chart.Series.Add(seriesname);
            //set the chart-type to "Pie"
            chart.Series[seriesname].ChartType = SeriesChartType.Pie;

            foreach (AssetVolume av in assets)
            {
                DataPoint dataPoint = new DataPoint();
                dataPoint.SetValueXY(av.AssetName, av.Volume);
                dataPoint.IsValueShownAsLabel = true;
                dataPoint.LabelFormat = "#.## M3";
                chart.Series[seriesname].Points.Add(dataPoint);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class AssetVolume
    { 
        public string AssetName { get; set; }
        public decimal Volume { get; set; }
    }

}