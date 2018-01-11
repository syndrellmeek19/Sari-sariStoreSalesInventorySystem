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
            SqlDataAdapter sdaNode1 = new SqlDataAdapter("SELECT * FROM [SUPPLIER] ", con);
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

            ProductList.Items.Add("ID" + "\t\t\t" + "Name"+"\t\t\t\t" + "Quantity" + "\t\t\t" + "Cost");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                object ob1 = dt2.Rows[i]["Product_ID"];
                object ob2 = dt2.Rows[i]["Product_Name"];
                object ob3 = dt2.Rows[i]["Quantity"];
                object ob4 = dt2.Rows[i]["Cost"];

                ProductList.Items.Add(ob1.ToString() + "\t\t\t" + ob2.ToString() + "\t\t\t" + ob3.ToString() + "\t\t\t" + ob4.ToString());
                ItemList.Items.Add(ob2.ToString());
            }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlDataAdapter sdaNode1 = new SqlDataAdapter("SELECT * FROM [SUPPLIER] where Supplier_Name='"+SupplierList.SelectedItem.ToString()+"'", con);
            DataTable dt = new DataTable();
            sdaNode1.Fill(dt);
            object ob1 = dt.Rows[0]["Supplier_ID"];
            TxtID.Text = ob1.ToString();
            for (int i = 0; i < SupplierList.Items.Count - 1; i++)
            {
                TxtName.Text = SupplierList.SelectedItem.ToString();

            }
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
            object ob1 = dt.Rows[ProductList.SelectedIndex-1]["Product_ID"];
            object ob2 = dt.Rows[ProductList.SelectedIndex-1]["Product_Name"];
            object ob3 = dt.Rows[ProductList.SelectedIndex-1]["Quantity"];
            object ob4 = dt.Rows[ProductList.SelectedIndex-1]["Cost"];

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewCustomer anc = new AddNewCustomer();
            anc.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddNewSupplier ans = new AddNewSupplier();
            ans.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddNewProduct anp = new AddNewProduct();
            anp.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [SUPPLIER] ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SupplierList.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object ob = dt.Rows[i]["Supplier_Name"];
                SupplierList.Items.Add(ob.ToString());
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [PRODUCT] ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ProductList.Items.Clear();
            ItemList.Items.Clear();
            ProductList.Items.Add("ID" + "\t\t\t" + "Name" + "\t\t\t\t" + "Quantity" + "\t\t\t" + "Cost");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object ob1 = dt.Rows[i]["Product_ID"];
                object ob2 = dt.Rows[i]["Product_Name"];
                object ob3 = dt.Rows[i]["Quantity"];
                object ob4 = dt.Rows[i]["Cost"];

                ProductList.Items.Add(ob1.ToString() + "\t\t\t" + ob2.ToString() + "\t\t\t" + ob3.ToString() + "\t\t\t" + ob4.ToString());
                ItemList.Items.Add(ob2.ToString());
            }
        }
    }
}
