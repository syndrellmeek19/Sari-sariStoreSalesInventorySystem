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
    /// Interaction logic for AddNewCustomer.xaml
    /// </summary>
    public partial class AddNewCustomer : Window
    {
        public AddNewCustomer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\_\SariSariStoreInventorySystem\WpfApplication1\Database1.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            SqlCommand command1 = new SqlCommand();
            command1 = new SqlCommand("INSERT INTO [CUSTOMER](Name, Address, Phone_Number) VALUES (@Name, @Address, @Phone_Number)", con1);
            command1.Parameters.AddWithValue("@Name", TxtNewName.Text);
            command1.Parameters.AddWithValue("@Address", TxtNewAddress.Text);
            command1.Parameters.AddWithValue("@Phone_Number", TxtNewNumber.Text);
            con1.Open();
            command1.ExecuteNonQuery();
            con1.Close();

            this.Close();
        }
    }
}
