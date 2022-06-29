using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Services;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Data.SMstorageTableAdapters;

namespace WindowsFormsApp1.Services
{
    public class StorageAssetServices
    {
        StorageAssetTableAdapter stAssetAdapter = null;
        AssetTableAdapter aAdapter = null;

        public StorageAssetServices()
        {
            stAssetAdapter = new StorageAssetTableAdapter();
            aAdapter = new AssetTableAdapter();
        }


        public List<StorageItem> GetDataByStorageId(int storageId)
        {
            List<StorageItem> storageItemList = new List<StorageItem>();


            var storageItemTable = stAssetAdapter.GetDataByStorageId(storageId);

            foreach (var row in storageItemTable)
            {
                StorageItem item = new StorageItem();
                item.Id = row.Id;
                item.IncomeDate = row.IncomeDate;
                item.Volume = row.Volume;

                var aRow = aAdapter.GetDataById(row.AssetId).First();
                Asset asset = new Asset();
                asset.Id = aRow.Id;
                asset.Name = aRow.AssetName;
                //asset.StorageType = 
                asset.SquareMeterVolume = aRow.SquareMeterVolume;
                asset.ExpirationDays = aRow.ExpirationDays;

                item.StorageAsset = asset;

                storageItemList.Add(item);
            }


            return storageItemList;
        }

        public int Add(StorageItem item, int storageId)
        {
            return stAssetAdapter.Insert(storageId, item.StorageAsset.Id, item.Volume, item.IncomeDate);
        }


        public int Delete(StorageItem item, int storageId)
        {
            return stAssetAdapter.Delete(item.Id, storageId, item.StorageAsset.Id, item.Volume, item.IncomeDate);
        }


    }
}



