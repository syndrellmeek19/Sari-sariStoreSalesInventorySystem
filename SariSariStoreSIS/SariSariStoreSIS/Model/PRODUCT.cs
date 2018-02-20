using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SariSariStoreSIS
{
    class PRODUCT
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

        private int _productID;
        private string _productName;
        private string _productType;
        private int _quantity;
        private string _measurement;
        private double _originalPrice;
        private double _sellingPrice;

        public int ProductID
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
                OnPropertyChanged("ProductID");
            }
        }
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                OnPropertyChanged("ProductName");
            }
        }
        public string ProductType
        {
            get
            {
                return _productType;
            }
            set
            {
                _productType = value;
                OnPropertyChanged("ProductType");
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        public string Measurement
        {
            get
            {
                return _measurement;
            }
            set
            {
                _measurement = value;
                OnPropertyChanged("Measurement");
            }
        }
        public double OriginalPrice
        {
            get
            {
                return _originalPrice;
            }
            set
            {
                _originalPrice = value;
                OnPropertyChanged("OriginalPrice");
            }
        }
        public double SellingPrice
        {
            get
            {
                return _sellingPrice;
            }
            set
            {
                _sellingPrice = value;
                OnPropertyChanged("SellingPrice");
            }
        }
        public PRODUCT() { }
        public PRODUCT(int productID, string productName, string productType, int quantity, string measurement, double originalPrice, double sellingPrice)
        {
            ProductID = productID;
            ProductName = productName;
            ProductType = productType;
            Quantity = quantity;
            Measurement = measurement;
            OriginalPrice = originalPrice;
            SellingPrice = sellingPrice;
        }

    }
}
