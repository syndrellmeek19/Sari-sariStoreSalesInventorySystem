using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class SUPPLIER
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactNumber { get; set; }
        public SUPPLIER() { }

        public SUPPLIER(int suppid, string suppname, string contactno)
        {
            SupplierID = suppid;
            SupplierName = suppname;
            ContactNumber = contactno;
        }
    }   
}
