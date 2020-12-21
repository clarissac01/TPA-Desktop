using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace TPA_Desktop_CC
{
    /// <summary>
    /// Interaction logic for ATMtftoVA.xaml
    /// </summary>
    public partial class ATMtftoVA : Window
    {
        Customer customer;

        public ATMtftoVA(Customer cust)
        {
            this.customer = cust;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (virtualacctxt.Text == "")
            {
                MessageBox.Show("Account Number Must Be Filled!");
                return;
            }
            if (amounttxt.Text == "")
            {
                MessageBox.Show("Amount Must Be Filled!");
                return;
            }
            if (customer.accountnumber == virtualacctxt.Text.ToString())
            {
                MessageBox.Show("You cannot transfer to yourself!");
                return;
            }
            label.Content = "";
                Window a = new PinConfirmationATM(customer, virtualacctxt.Text.ToString(), Int32.Parse(amounttxt.Text.ToString()), "virtualacc");
                a.Show();
                this.Close();
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window a = new ATMWindow(customer);
            a.Show();
            this.Close();

        }

        
    }
}
