using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entities
{
    public class Asset : Entity
    {
        public string Name
        {
            get;
            set;
        }
        public StorageType StorageType
        {
            get;
            set;
        }
        public decimal SquareMeterVolume
        {
            get;
            set;
        }
        public int  ExpirationDays
        {
            get;
            set;
        }
    }
}
