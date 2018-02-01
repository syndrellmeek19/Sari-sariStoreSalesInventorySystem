using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.IO.Ports;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace SariSariStoreSIS
{
    class MainViewModel
    {
 
        ObservableCollection<PRODUCT> productList = new ObservableCollection<PRODUCT>();
        public ObservableCollection<PRODUCT> ProductList
        {
            get { return productList; }
            set { productList = value; }
        }

        ObservableCollection<SUPPLIER> supplierNameList = new ObservableCollection<SUPPLIER>();
        public ObservableCollection<SUPPLIER> SupplierNameList
        {
            get { return supplierNameList; }
            set { supplierNameList = value; }
        }
        ObservableCollection<ORDER> orderList = new ObservableCollection<ORDER>();
        public ObservableCollection<ORDER> OrderList
        {
            get { return orderList; }
            set { orderList = value; }
        }


        public PRODUCT SelectedProduct { get; set; }
        public SUPPLIER SelectedSupplierName { get; set; }
        public PRODUCT SelectedItem { get; set; }

        public void RefreshProduct()
        {
            SqlConnection con = SQLCONNECTION.GetConnection();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * From [PRODUCT]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            ProductList.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PRODUCT prod = new PRODUCT();
                prod.ProductID = Convert.ToInt16(dt.Rows[i]["Product_ID"]);
                prod.ProductName = dt.Rows[i]["Product_Name"].ToString();
                prod.ProductType = dt.Rows[i]["Product_Type"].ToString();
                prod.Quantity = Convert.ToInt16(dt.Rows[i]["Quantity"]);
                prod.Measurement = dt.Rows[i]["Measurement"].ToString();
                prod.OriginalPrice = Convert.ToDouble(dt.Rows[i]["Original_Price"]);
                prod.SellingPrice = Convert.ToDouble(dt.Rows[i]["Selling_Price"]);
                ProductList.Add(prod);
            }
        }
        public void AddNewProduct()
        {
            AddNewProductWindow productWindow = new AddNewProductWindow();
            productWindow.Owner = Application.Current.MainWindow;
            productWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            PRODUCT prod = new PRODUCT();
            productWindow.DataContext = prod;

            var result = productWindow.ShowDialog();
            if (result == true)
            {
                productList.Add(prod);
            }
        }
       
        public void DeleteProduct()
        {
            if (SelectedProduct!=null)
            {
                if (MessageBox.Show("Are you sure?", "Delete Product", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
                {
                    SqlConnection con = SQLCONNECTION.GetConnection();
                    SqlCommand command = new SqlCommand("DELETE FROM [PRODUCT] where Product_ID=@Product_ID", con);
                    command.Parameters.AddWithValue("@Product_ID", SelectedProduct.ProductID);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public void RefreshSupplier()
        {
            SqlConnection con = SQLCONNECTION.GetConnection();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * From [SUPPLIER]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SupplierNameList.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SUPPLIER supp = new SUPPLIER();
                supp.SupplierName = dt.Rows[i]["Supplier_Name"].ToString();
                supp.SupplierID = Convert.ToInt16(dt.Rows[i]["Supplier_ID"]);
                supp.ContactNumber = dt.Rows[i]["Contact_Number"].ToString();
                supp.Location = dt.Rows[i]["Location"].ToString();
                SupplierNameList.Add(supp);
            }
        }
        public void AddNewSupplier()
        {
            AddNewSupplierWindow supplierWindow = new AddNewSupplierWindow();
            supplierWindow.Owner = Application.Current.MainWindow;
            supplierWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            SUPPLIER supp = new SUPPLIER();
            supplierWindow.DataContext = supp;

            var result = supplierWindow.ShowDialog();
            if (result == true)
            {
                supplierNameList.Add(supp);
            }
        }
        public void DeleteSupplier()
        {
            if (SelectedSupplierName != null)
            {
                if (MessageBox.Show("Are you sure?", "Delete Supplier", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    SqlConnection con = SQLCONNECTION.GetConnection();
                    SqlCommand command = new SqlCommand("DELETE FROM [SUPPLIER] where Supplier_ID=@Supplier_ID", con);
                    command.Parameters.AddWithValue("@Supplier_ID", SelectedSupplierName.SupplierID);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        
        
    }
}
