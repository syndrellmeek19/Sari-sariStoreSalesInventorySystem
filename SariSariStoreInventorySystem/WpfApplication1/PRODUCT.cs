using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class PRODUCT
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public int Quantity { get; set; }
        public int Cost { get; set; }
        public PRODUCT() { }

        public PRODUCT(int prodid, string prodname, string prodtype, int qty ,int cost)
        {
            ProductID = prodid;
            ProductName = prodname;
            ProductType = prodtype;
            Quantity = qty;
            Cost = cost;
        }
    }
}
