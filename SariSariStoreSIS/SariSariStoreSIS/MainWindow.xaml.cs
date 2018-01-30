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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModelLocator.MainViewModel;
            ViewModelLocator.MainViewModel.RefreshProduct();
        }


        private void Add_Product(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MainViewModel.AddNewProduct();
            ViewModelLocator.MainViewModel.RefreshProduct();
        }

        private void Delete_Product(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MainViewModel.DeleteProduct();
            ViewModelLocator.MainViewModel.RefreshProduct();
        }

        private void Update_Product(object sender, RoutedEventArgs e)
        {
            if (ViewModelLocator.MainViewModel.SelectedProduct != null)
            {
                if (isValid()==true)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\_\SariSariStoreSIS\SariSariStoreSIS\Database1.mdf;Integrated Security=True;Connect Timeout=30;");
                    SqlCommand command = new SqlCommand("UPDATE[PRODUCT] SET Product_Name = @Product_Name, Product_Type = @Product_Type, Quantity = @Quantity, Measurement = @Measurement, Original_Price = @Original_Price, Selling_Price = @Selling_Price WHERE Product_ID = '" + ViewModelLocator.MainViewModel.SelectedProduct.ProductID + "'", con);
                    command.Parameters.AddWithValue("@Product_Name", TxtName.Text);
                    command.Parameters.AddWithValue("@Product_Type", TxtType.Text);
                    command.Parameters.AddWithValue("@Quantity", TxtQuantity.Text);
                    command.Parameters.AddWithValue("@Measurement", TxtMeasurement.Text);
                    command.Parameters.AddWithValue("@Original_Price", TxtOriginalP.Text);
                    command.Parameters.AddWithValue("@Selling_Price", TxtSellingP.Text);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product Updated Successfully", "Update Product", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Please enter a valid input!", "Error: Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ViewModelLocator.MainViewModel.RefreshProduct();
        }

        public bool isValid()
        {
            decimal d1, d2;
            int i;
            if (int.TryParse(TxtQuantity.Text, out i) == true && decimal.TryParse(TxtOriginalP.Text, out d1) == true && decimal.TryParse(TxtSellingP.Text, out d2) == true)
            {
                return true;
            }
            return false;
        }
    }
  
}
