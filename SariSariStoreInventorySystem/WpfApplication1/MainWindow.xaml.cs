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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\_\SariSariStoreInventorySystem\WpfApplication1\Database1.mdf;Integrated Security=True;Connect Timeout=30;");
        public MainWindow()
        {
            InitializeComponent();
            SqlDataAdapter sdaNode1 = new SqlDataAdapter("SELECT * FROM [SUPPLIERS] ", con);
            SqlDataAdapter sdaNode2 = new SqlDataAdapter("SELECT * FROM [PRODUCT] ", con);
            SqlDataAdapter sdaNode3 = new SqlDataAdapter("SELECT * FROM [CUSTOMER] ", con);
            
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();

            sdaNode1.Fill(dt);
            sdaNode2.Fill(dt2);
            sdaNode3.Fill(dt3);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object ob = dt.Rows[i]["Supplier_Name"];
                SupplierList.Items.Add(ob.ToString());
            }
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                object ob = dt3.Rows[i]["Name"];
                CustomerList.Items.Add(ob.ToString());
                CmBName.Items.Add(ob.ToString());
            }
            List<PRODUCT> items = new List<PRODUCT>();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                object ob1 = dt2.Rows[i]["Product_ID"];
                object ob2 = dt2.Rows[i]["Product_Name"];
                object ob3 = dt2.Rows[i]["Product_Type"];
                object ob4 = dt2.Rows[i]["Quantity"];
                object ob5 = dt2.Rows[i]["Cost"];
               
                items.Add(new PRODUCT() {ProductID=int.Parse(ob1.ToString()),ProductName=ob2.ToString(),ProductType=ob3.ToString(),Quantity=int.Parse(ob4.ToString()),Cost=int.Parse(ob5.ToString()) });
               
                ItemList.Items.Add(ob2.ToString());
            }
            ProductList.ItemsSource = items;

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlDataAdapter sdaNode1 = new SqlDataAdapter("SELECT * FROM [SUPPLIERS] where Supplier_Name='"+SupplierList.SelectedItem.ToString()+"'", con);
            DataTable dt = new DataTable();
            sdaNode1.Fill(dt);
            object ob1 = dt.Rows[0]["Supplier_ID"];
            object ob2 = dt.Rows[0]["Contact_Number"];
            object ob3 = dt.Rows[0]["Supplier_Name"];
            TxtID.Text = ob1.ToString();
            TxtContact.Text = ob2.ToString();
            TxtName.Text = ob3.ToString();
        
        }
        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlDataAdapter sdaNode1 = new SqlDataAdapter("SELECT * FROM [CUSTOMER] where Name='" + CustomerList.SelectedItem.ToString() + "'", con);
            DataTable dt = new DataTable();
            sdaNode1.Fill(dt);
            object ob1 = dt.Rows[0]["Customer_ID"];
            object ob2 = dt.Rows[0]["Address"];
            object ob3 = dt.Rows[0]["Phone_Number"];
            TxtCID.Text = ob1.ToString();
            TxtCAddress.Text = ob2.ToString();
            TxtCNumber.Text = ob3.ToString();
            for (int i = 0; i < CustomerList.Items.Count - 1; i++)
            {
                TxtCName.Text = CustomerList.SelectedItem.ToString();

            }

        }

        private void ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            SqlDataAdapter sdaNode1 = new SqlDataAdapter("SELECT * FROM [PRODUCT]", con);
            DataTable dt = new DataTable();
            sdaNode1.Fill(dt);
            object ob1 = dt.Rows[ProductList.SelectedIndex]["Product_ID"];
            object ob2 = dt.Rows[ProductList.SelectedIndex]["Product_Name"];
            object ob3 = dt.Rows[ProductList.SelectedIndex]["Quantity"];
            object ob4 = dt.Rows[ProductList.SelectedIndex]["Cost"];

            TxtPID.Text = ob1.ToString();
            TxtPName.Text = ob2.ToString();
            TxtQuantity.Text = ob3.ToString();
            TxtCost.Text = ob4.ToString();
        }
        private void ProductList2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            SqlDataAdapter sdaNode1 = new SqlDataAdapter("SELECT * FROM [PRODUCT] where Product_Name='" + ItemList.SelectedItem.ToString() + "'", con);
            DataTable dt = new DataTable();
            sdaNode1.Fill(dt);
            object ob1 = dt.Rows[0]["Quantity"];
            object ob2 = dt.Rows[0]["Cost"];
            TxtAvailable.Text = ob1.ToString();
            TxtCPrice.Text = ob2.ToString();

        }

        private void Add_Customer(object sender, RoutedEventArgs e)
        {
            
            AddNewCustomer anc = new AddNewCustomer();
            anc.ShowDialog();
        }

        private void Add_Supplier(object sender, RoutedEventArgs e)
        {
            AddNewSupplier ans = new AddNewSupplier();
            ans.ShowDialog();
        }

        private void Add_Item(object sender, RoutedEventArgs e)
        {
            AddNewProduct anp = new AddNewProduct();
            anp.ShowDialog();
        }

        private void Refresh_Customer(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [CUSTOMER] ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CustomerList.Items.Clear();
            CmBName.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object ob = dt.Rows[i]["Name"];
                CustomerList.Items.Add(ob.ToString());
                CmBName.Items.Add(ob.ToString());
            }
        }

        private void Refresh_Supplier(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [SUPPLIERS] ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SupplierList.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object ob = dt.Rows[i]["Supplier_Name"];
                SupplierList.Items.Add(ob.ToString());
            }
        }

        private void Refresh_Product(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [PRODUCT] ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            
            List<PRODUCT> items = new List<PRODUCT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object ob1 = dt.Rows[i]["Product_ID"];
                object ob2 = dt.Rows[i]["Product_Name"];
                object ob3 = dt.Rows[i]["Product_Type"];
                object ob4 = dt.Rows[i]["Quantity"];
                object ob5 = dt.Rows[i]["Cost"];

                items.Add(new PRODUCT() { ProductID = int.Parse(ob1.ToString()), ProductName = ob2.ToString(), ProductType = ob3.ToString(), Quantity = int.Parse(ob4.ToString()), Cost = int.Parse(ob5.ToString()) });

                ItemList.Items.Add(ob2.ToString());
            }
            ProductList.ItemsSource = items;

        }

        private void Add_to_Cart(object sender, RoutedEventArgs e)
        {
            //SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\_\SariSariStoreInventorySystem\WpfApplication1\Database1.mdf;Integrated Security=True;Connect Timeout=30;");
            //SqlDataAdapter adapter1 = new SqlDataAdapter();
            //SqlCommand command1 = new SqlCommand();
            //command1 = new SqlCommand("INSERT INTO [ORDERS](Total_Quantity, Total_Cost) VALUES (@Total_Quantity, @Total_Cost)", con1);
            //command1.Parameters.AddWithValue("@Total_Quantity", TxtQ.Text);
            //command1.Parameters.AddWithValue("@Total_Cost", TxtTC.Text);
            //con1.Open();
            //command1.ExecuteNonQuery();
            //con1.Close();
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [ORDERS])", con);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //OrderList.Items.Clear();
            //List<ORDERS> ord = new List<ORDERS>();
            
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    object ob1 = dt.Rows[i]["Order_Number"];
            //    object ob2 = dt.Rows[i]["Total_Quantity"];
            //    object ob3 = dt.Rows[i]["Total_Cost"];
            //    ord.Add(new ORDERS() { OrderNumber = int.Parse(ob1.ToString()), Item = ItemList.Items.ToString(), TotalQuantity = int.Parse(ob2.ToString()), TotalCost = int.Parse(ob3.ToString()) });

            //}
            //OrderList.ItemsSource = ord;
        }

        private void Update_Supplier(object sender, RoutedEventArgs e)
        {
            SqlCommand command1 = new SqlCommand();
            command1 = new SqlCommand("UPDATE [SUPPLIERS] SET Contact_Number=@Contact_Number WHERE Supplier_Name='" + SupplierList.SelectedItem.ToString() + "'", con);
            command1.Parameters.AddWithValue("@Contact_Number", TxtContact.Text);
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
        }

        private void Update_Customer(object sender, RoutedEventArgs e)
        {
            SqlCommand command1 = new SqlCommand();
            command1 = new SqlCommand("UPDATE [CUSTOMER] SET Address=@Address WHERE Name='" + CustomerList.SelectedItem.ToString() + "'", con);
            command1 = new SqlCommand("UPDATE [CUSTOMER] SET Phone_Number=@Phone_Number WHERE Name='" + CustomerList.SelectedItem.ToString() + "'", con);
            command1.Parameters.AddWithValue("@Address", TxtCAddress.Text);
            command1.Parameters.AddWithValue("@Phone_Number", TxtCNumber.Text);
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
        }

        private void Update_Product(object sender, RoutedEventArgs e)
        {

        }
    }
}
