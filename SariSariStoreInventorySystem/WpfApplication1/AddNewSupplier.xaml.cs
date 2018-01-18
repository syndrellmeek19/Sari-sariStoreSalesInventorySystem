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
    /// Interaction logic for AddNewSupplier.xaml
    /// </summary>
    public partial class AddNewSupplier : Window
    {
        public AddNewSupplier()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\SYNMLMALUENDA\DESKTOP\SARISARISTOREINVENTORYSYSTEM\WPFAPPLICATION1\DATABASE1.MDF;Integrated Security=True;Connect Timeout=30;");
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            SqlCommand command1 = new SqlCommand();
            command1 = new SqlCommand("INSERT INTO [SUPPLIERS](Supplier_Name, Contact_Number) VALUES (@Supplier_Name,@Contact_Number)", con1);
            command1.Parameters.AddWithValue("@Supplier_Name", TxtNewName.Text);
            command1.Parameters.AddWithValue("@Contact_Number", TxtNewNumber.Text);
            con1.Open();
            command1.ExecuteNonQuery();
            con1.Close();

            this.Close();
        }
    }
}
