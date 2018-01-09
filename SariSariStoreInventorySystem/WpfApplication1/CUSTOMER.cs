using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class CUSTOMER
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public CUSTOMER() { }

        public CUSTOMER(int cstmrid, string name, string address, string phoneno)
        {
            CustomerID = cstmrid;
            Name = name;
            Address = address;
            PhoneNumber = phoneno;
        }

    }
}
