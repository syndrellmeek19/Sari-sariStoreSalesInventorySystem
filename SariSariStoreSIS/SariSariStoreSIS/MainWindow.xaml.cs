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
            ViewModelLocator.MainViewModel.RefreshSupplier();
        }


        private void Add_Product(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MainViewModel.AddNewProduct();
            ViewModelLocator.MainViewModel.RefreshProduct();
        }
        private void Add_Supplier(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MainViewModel.AddNewSupplier();
            ViewModelLocator.MainViewModel.RefreshSupplier();
        }

        private void Delete_Product(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MainViewModel.DeleteProduct();
            ViewModelLocator.MainViewModel.RefreshProduct();
        }
        private void Delete_Supplier(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MainViewModel.DeleteSupplier();
            ViewModelLocator.MainViewModel.RefreshSupplier();
        }
        private void Update_Product(object sender, RoutedEventArgs e)
        {
            if (ViewModelLocator.MainViewModel.SelectedProduct != null)
            {
                if (isValid()==true)
                {
                    SqlConnection con = SQLCONNECTION.GetConnection();
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

        private void Update_Supplier(object sender, RoutedEventArgs e)
        {
            if (ViewModelLocator.MainViewModel.SelectedSupplierName!=null)
            {
                SqlConnection con = SQLCONNECTION.GetConnection();
                SqlCommand command = new SqlCommand("UPDATE[SUPPLIER] SET Supplier_Name=@Supplier_Name, Contact_Number=@Contact_Number, Location=@Location WHERE Supplier_ID = '" + ViewModelLocator.MainViewModel.SelectedSupplierName.SupplierID + "'", con);
                command.Parameters.AddWithValue("@Supplier_Name", TxtSName.Text);
                command.Parameters.AddWithValue("@Contact_Number", TxtCN.Text);
                command.Parameters.AddWithValue("@Location", TxtL.Text);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Supplier Updated Successfully", "Update Supplier", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public bool isValid()
        {
            double d1, d2;
            int i1;
            if ((int.TryParse(TxtQuantity.Text, out i1) == true && double.TryParse(TxtOriginalP.Text, out d1) == true && double.TryParse(TxtSellingP.Text, out d2) == true))
            {
                return true;
            }
            return false;
        }
  

        private void Product_Grid(object sender, RoutedEventArgs e)
        {
            SupplierGrid.Visibility = Visibility.Hidden;
            OrderGrid.Visibility = Visibility.Hidden;
            ProductGrid.Visibility = Visibility.Visible;
            
        }

        private void Supplier_Grid(object sender, RoutedEventArgs e)
        {
            ProductGrid.Visibility = Visibility.Hidden;
            OrderGrid.Visibility = Visibility.Hidden;
            SupplierGrid.Visibility = Visibility.Visible;
        }
        private void Order_Grid(object sender, RoutedEventArgs e)
        {
            SupplierGrid.Visibility = Visibility.Hidden;
            ProductGrid.Visibility = Visibility.Hidden;
            OrderGrid.Visibility = Visibility.Visible;
        }
        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close window?", "Exit Application", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void TxtFP_MouseEnter(object sender, MouseEventArgs e)
        {
            int i;
            double d;
            if (TxtQR.Text!=null && TxtCP.Text!=null)
            {
                if (int.TryParse(TxtQR.Text, out i) == true && double.TryParse(TxtCP.Text, out d) == true)
                {
                    TxtFP.Text = (Convert.ToInt16(TxtQR.Text) * Convert.ToDouble(TxtCP.Text)).ToString();
                }
                
            }
        }

        private void Add_Cart(object sender, RoutedEventArgs e)
        {
            ORDER ord = new ORDER();
            if (ViewModelLocator.MainViewModel.SelectedItem!=null)
            {
                ord.Customer = TxtCstmr.Text;
                ord.ItemName = ViewModelLocator.MainViewModel.SelectedItem.ProductName;
                ord.QuantityRequired = Convert.ToInt16(TxtQR.Text);
                ord.FinalPrice = Convert.ToDouble(TxtFP.Text);
                LVItems.Items.Add(ord);
            }
            else
                MessageBox.Show("Please select an item!", "Error: No Selection", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void Delete_Cart(object sender, RoutedEventArgs e)
        {
            if (LVItems.SelectedItem!=null)
            {
                LVItems.Items.Remove(LVItems.SelectedItem);
            }
        }
    }
  
}
