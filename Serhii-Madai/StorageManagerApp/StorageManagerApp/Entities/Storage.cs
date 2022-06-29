using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entities
{
    public class Storage : Entity 
    {
        decimal dryStorageAssetsSpace = 0;
        decimal coldStorageAssetsSpace = 0;


        List<StorageItem> storageItemColection = null;

        public Storage()
        {
            this.storageItemColection = new List<StorageItem>();
        }

        public string Name
        {
            get;
            set;
        }
        public decimal DryStorageSpace
        {
            get;
            set;
        }
        public decimal ColdStorageSpace
        {
            get;
            set;
        }
        public List<StorageItem> StorageItemColection 
        {
            get { return this.storageItemColection; }
        }

        public decimal DryStorageFreePercent
        {
            get { return 1 - (this.dryStorageAssetsSpace / this.DryStorageSpace); }
        }

        public decimal ColdStorageFreeSize
        {
            get { return this.ColdStorageSpace - this.coldStorageAssetsSpace; }
        }

        public decimal DryStorageFreeSize
        {
            get { return this.DryStorageSpace - this.dryStorageAssetsSpace; }
        }

        public decimal ColdStorageFreePercent
        {
            get { return 1 - (this.coldStorageAssetsSpace / this.ColdStorageSpace); }
        }

        public decimal StorageFreePercent
        {
            get { return 1 - ((this.coldStorageAssetsSpace + this.dryStorageAssetsSpace) / (this.ColdStorageSpace + this.DryStorageSpace)); }
        }



        public void AddStorageItem(StorageItem item)
        {
            if (item.StorageAsset.StorageType == StorageType.Dry)
            {
                dryStorageAssetsSpace = dryStorageAssetsSpace + item.SquareMeterVolume;
                
            }
            else {

                coldStorageAssetsSpace = coldStorageAssetsSpace + item.SquareMeterVolume;
            }

            this.StorageItemColection.Add(item);
        }
    }
}
