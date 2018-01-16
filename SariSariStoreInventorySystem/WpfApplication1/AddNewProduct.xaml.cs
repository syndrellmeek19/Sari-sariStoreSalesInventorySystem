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
    /// Interaction logic for AddNewProduct.xaml
    /// </summary>
    public partial class AddNewProduct : Window
    {
        public AddNewProduct()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\_\SariSariStoreInventorySystem\WpfApplication1\Database1.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            SqlCommand command1 = new SqlCommand();
            command1 = new SqlCommand("INSERT INTO [PRODUCT](Product_Name, Product_Type, Quantity, Cost) VALUES (@Product_Name, @Product_Type, @Quantity, @Cost)", con1);
            command1.Parameters.AddWithValue("@Product_Name", TxtName.Text);
            command1.Parameters.AddWithValue("@Product_Type", TxtType.Text);
            command1.Parameters.AddWithValue("@Quantity", TxtQuantity.Text);
            command1.Parameters.AddWithValue("@Cost", TxtPrice.Text);
            con1.Open();
            command1.ExecuteNonQuery();
            con1.Close();
            this.Close();
        }
    }
}
