using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Data.SMstorageTableAdapters;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1.Services
{
    public class AssetServices
    {
        AssetTableAdapter assetTableAdapter = null;

        public AssetServices()
        {
            this.assetTableAdapter = new AssetTableAdapter();
        }

        public List<Asset> GetAllAsset()
        {
            List<Asset> assetList = new List<Asset>();

            var assetTable = assetTableAdapter.GetData();


            foreach (var sr in assetTable)
            {
                Asset a = new Asset();

                a.Id = sr.Id;
                a.Name = sr.AssetName;
                a.StorageType = (StorageType)Enum.Parse(typeof(StorageType), sr.StorageType);
                a.ExpirationDays = sr.ExpirationDays;
                a.SquareMeterVolume = sr.SquareMeterVolume;

                assetList.Add(a);
            }

            return assetList;
        }


        public List<Asset> GetAllAssetByStorageType(StorageType storageType)
        {
            List<Asset> assetList = new List<Asset>();

            var assetTable = assetTableAdapter.GetDataByStorageType(storageType.ToString());

            foreach (var sr in assetTable)
            {
                Asset a = new Asset();

                a.Id = sr.Id;
                a.Name = sr.AssetName;
                a.StorageType = (StorageType)Enum.Parse(typeof(StorageType), sr.StorageType);
                a.ExpirationDays = sr.ExpirationDays;
                a.SquareMeterVolume = sr.SquareMeterVolume;

                assetList.Add(a);
            }

            return assetList;
        }

        public int Add(Asset asset)
        {
            return assetTableAdapter.Insert(asset.Name, asset.StorageType.ToString(), (int)asset.SquareMeterVolume, asset.ExpirationDays);
        }


        public int Edit(Asset asset, String assetName, StorageType storageType, decimal squareMeterVolume, int expirationDays)
        {
            return assetTableAdapter.Update(assetName
                , storageType.ToString()
                , (int)squareMeterVolume
                , expirationDays
                , asset.Id
                , asset.Name
                , asset.StorageType.ToString()
                , (int)asset.SquareMeterVolume
                , asset.ExpirationDays
                );
        }

        public int Delete(Asset asset)
        {
            return assetTableAdapter.Delete(asset.Id, asset.Name, asset.StorageType.ToString(), (int)asset.SquareMeterVolume, asset.ExpirationDays)  ;
        }


    }
}
