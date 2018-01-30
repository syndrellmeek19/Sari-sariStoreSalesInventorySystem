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
    /// Interaction logic for AddNewProductWindow.xaml
    /// </summary>
    public partial class AddNewProductWindow : Window
    {
        public AddNewProductWindow()
        {
            InitializeComponent();
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            if (isValid()==true)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\_\SariSariStoreSIS\SariSariStoreSIS\Database1.mdf;Integrated Security=True;Connect Timeout=30;");
                SqlDataAdapter adapter1 = new SqlDataAdapter();
                SqlCommand command1 = new SqlCommand("INSERT INTO [PRODUCT](Product_Name, Product_Type, Quantity, Measurement, Original_Price, Selling_Price) VALUES (@Product_Name, @Product_Type, @Quantity, @Measurement, @Original_Price, @Selling_Price)", con);
                command1.Parameters.AddWithValue("@Product_Name", TxtName.Text);
                command1.Parameters.AddWithValue("@Product_Type", TxtType.Text);
                command1.Parameters.AddWithValue("@Quantity", TxtQuantity.Text);
                command1.Parameters.AddWithValue("@Measurement", TxtMeasurement.Text);
                command1.Parameters.AddWithValue("@Original_Price", TxtOriginalP.Text);
                command1.Parameters.AddWithValue("@Selling_Price", TxtSellingP.Text);
                con.Open();
                command1.ExecuteNonQuery();
                con.Close();
                DialogResult = true;
                MessageBox.Show("Product Added Successfully", "New Product", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Please enter a valid input!", "Error: Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public bool isValid()
        {
            decimal d1, d2;
            int i;
            if (int.TryParse(TxtQuantity.Text, out i)==true && decimal.TryParse(TxtOriginalP.Text, out d1)==true && decimal.TryParse(TxtSellingP.Text, out d2) == true)
            {
                return true;
            }
            return false;
        }
        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
