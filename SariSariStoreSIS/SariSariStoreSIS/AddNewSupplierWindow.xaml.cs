using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;


namespace SariSariStoreSIS
{
    /// <summary>
    /// Interaction logic for AddNewSupplierWindow.xaml
    /// </summary>
    public partial class AddNewSupplierWindow : Window
    {
        public AddNewSupplierWindow()
        {
            InitializeComponent();
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            SqlConnection con = SQLCONNECTION.GetConnection();
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            SqlCommand command1 = new SqlCommand("INSERT INTO [SUPPLIER](Supplier_Name, Contact_Number, Location) VALUES (@Supplier_Name, @Contact_Number, @Location)", con);
            command1.Parameters.AddWithValue("@Supplier_Name", TxtName.Text);
            command1.Parameters.AddWithValue("@Contact_Number", TxtCN.Text);
            command1.Parameters.AddWithValue("@Location", TxtLoc.Text);
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            DialogResult = true;
            MessageBox.Show("Supplier Added Successfully", "New Supplier", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
