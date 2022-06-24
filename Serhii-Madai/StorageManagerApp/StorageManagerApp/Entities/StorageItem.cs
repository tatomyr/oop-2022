using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entities
{
    public class StorageItem : Entity
    {

        public DateTime IncomeDate
        {
            get;
            set;
        }

        public int Volume
        {
            get;
            set;
        }

        public Asset StorageAsset
        {
            get;
            set;
        }

        public decimal SquareMeterVolume
        {
            get { return Volume / StorageAsset.SquareMeterVolume; }
        }
    }
}
