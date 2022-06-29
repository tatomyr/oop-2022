using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WindowsFormsApp1.Data.SMstorageTableAdapters;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1.Services
{
    public class StorageService
    {

        StorageTableAdapter storageTableAdapter = null;
        StorageAssetTableAdapter storageAssetTableAdapter = null;
        AssetTableAdapter assetTableAdapter = null;


        public StorageService()
        {

            this.storageTableAdapter = new StorageTableAdapter();
            this.storageAssetTableAdapter = new StorageAssetTableAdapter();
            this.assetTableAdapter = new AssetTableAdapter();
        }


        public List<Storage> GetAllStorages()
        {
            List<Storage> storageList = new List<Storage>();

            var storageTable = storageTableAdapter.GetData();

            foreach (var row in storageTable)
            {
                Storage st = new Storage();
                st.Id = row.Id;
                st.Name = row.StorageName;
                st.DryStorageSpace = row.DryStorageSpace;
                st.ColdStorageSpace = row.HotStorageSpace;

                var storageAssetTable = storageAssetTableAdapter.GetDataByStorageId(st.Id);

                foreach (var siRow in storageAssetTable)
                {
                    StorageItem stItem = new StorageItem();
                    stItem.Id = siRow.Id;
                    stItem.IncomeDate = siRow.IncomeDate;
                    stItem.Volume = siRow.Volume;

                    var assetTable = assetTableAdapter.GetDataById(siRow.AssetId);
                    Asset a = new Asset();
                    var ar = assetTable.First();
                    a.Id = ar.Id;
                    a.Name = ar.AssetName;
                    a.StorageType = (StorageType)Enum.Parse(typeof(StorageType), ar.StorageType);
                    a.SquareMeterVolume = ar.SquareMeterVolume;
                    a.ExpirationDays = ar.ExpirationDays;

                    stItem.StorageAsset = a;
                    st.AddStorageItem(stItem);

                }

                storageList.Add(st);

            }

            return storageList;
        }


        public Storage GetStorageById(int id)
        {
            var row = storageTableAdapter.GetDataById(id).First();

            Storage st = new Storage();
            st.Id = row.Id;
            st.Name = row.StorageName;
            st.DryStorageSpace = row.DryStorageSpace;
            st.ColdStorageSpace = row.HotStorageSpace;

            var storageAssetTable = storageAssetTableAdapter.GetDataByStorageId(st.Id);

            foreach (var siRow in storageAssetTable)
            {
                StorageItem stItem = new StorageItem();
                stItem.Id = siRow.Id;
                stItem.IncomeDate = siRow.IncomeDate;
                stItem.Volume = siRow.Volume;

                var assetTable = assetTableAdapter.GetDataById(siRow.AssetId);
                Asset a = new Asset();
                var ar = assetTable.First();
                a.Id = ar.Id;
                a.Name = ar.AssetName;
                a.StorageType = (StorageType)Enum.Parse(typeof(StorageType), ar.StorageType);
                a.SquareMeterVolume = ar.SquareMeterVolume;
                a.ExpirationDays = ar.ExpirationDays;

                stItem.StorageAsset = a;
                st.AddStorageItem(stItem);

            }

            return st;
        }


        public int Add(Storage storage)
        {
            return storageTableAdapter.Insert(storage.Name, (int)storage.DryStorageSpace, (int)storage.ColdStorageSpace);
        }

        public int Update(Storage storage, String storageName, decimal dryStorageSpace, decimal coldStorageSpace)
        {
            return storageTableAdapter.Update(storageName, (int)dryStorageSpace, (int)coldStorageSpace, storage.Id, storage.Name, (int)storage.DryStorageSpace, (int)storage.ColdStorageSpace);
        }

        public int Delete(Storage storage)
        {
            return storageTableAdapter.Delete(storage.Id, storage.Name, (int)storage.DryStorageSpace, (int)storage.ColdStorageSpace);
        }

    }


}
