using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SariSariStoreSIS
{
    class SUPPLIER
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int _supplierID;
        private string _supplierName;
        private string _contactNumber;
        private string _location;
        public int SupplierID
        {
            get
            {
                return _supplierID;
            }
            set
            {
                _supplierID = value;
                OnPropertyChanged("SupplierID");
            }
        }
        public string SupplierName
        {
            get
            {
                return _supplierName;
            }
            set
            {
                _supplierName = value;
                OnPropertyChanged("SupplierName");
            }
        }
        public string ContactNumber
        {
            get
            {
                return _contactNumber;
            }
            set
            {
                _contactNumber = value;
                OnPropertyChanged("ContactNumber");
            }
        }
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }
        public SUPPLIER()
        {

        }
        public SUPPLIER(int supplierID, string supplierName, string contactNumber, string location)
        {
            SupplierID = supplierID;
            SupplierName = supplierName;
            ContactNumber = contactNumber;
            Location = location;
        }
    }
}
