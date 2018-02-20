using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SariSariStoreSIS
{
    class ORDER
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

        private string _customer;
        private string _itemName;
        private int _quantityR;
        private double _finalPrice;

        public string Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
                OnPropertyChanged("Customer");
            }
        }
        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                _itemName = value;
                OnPropertyChanged("ItemName");
            }
        }
        public int QuantityRequired
        {
            get
            {
                return _quantityR;
            }
            set
            {
                _quantityR = value;
                OnPropertyChanged("QuantityRequired");
            }
        }
        public double FinalPrice
        {
            get
            {
                return _finalPrice;
            }
            set
            {
                _finalPrice = value;
                OnPropertyChanged("FinalPrice");
            }
        }
        public ORDER() { }
        public ORDER(string customer, string itemName, int quantityR, double finalPrice)
        {
            Customer = customer;
            ItemName = itemName;
            QuantityRequired = quantityR;
            FinalPrice = finalPrice;
        }
    }
}
