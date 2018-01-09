using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class ORDERS
    {
        public int OrderNumber { get; set; }
        public int TotalQuantity { get; set; }
        public int TotalCost { get; set; }
        public ORDERS() { }

        public ORDERS(int orderno, int totalqty, int totalcost)
        {
            OrderNumber = orderno;
            TotalQuantity = totalqty;
            TotalCost = totalcost;
        }
    }
}
