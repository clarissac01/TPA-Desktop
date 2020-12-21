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
    /// Interaction logic for ATMtftoRA.xaml
    /// </summary>
    public partial class ATMtftoRA : Window
    {
        Customer customer;
        DataTable dt;
        ConnectDatabase connect;

        public ATMtftoRA(Customer cust)
        {
            this.connect = ConnectDatabase.getInstance();
            this.customer = cust;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (accnumtxt.Text == "")
            {
                MessageBox.Show("Account Number Must Be Filled!");
                return;
            }
            if (amounttxt.Text == "")
            {
                MessageBox.Show("Amount Must Be Filled!");
                return;
            }
            if(customer.accountnumber == accnumtxt.Text.ToString())
            {
                MessageBox.Show("You cannot transfer to yourself!");
                return;
            }
            string accnum = accnumtxt.Text;

            dt = new DataTable();
            dt = connect.executeQuery("select * from customer where accountnumber = '"+ accnumtxt.Text.ToString() + "' limit 1");
            
            if (dt.Rows.Count == 0)
            {
                label.Content = "Invalid User!";
                return;
            }
            else
            {
                DataRow data = dt.Rows[0];
                label.Content = "";
                Customer receiver = new Customer(data["accountnumber"].ToString(), data["pin"].ToString(), data["name"].ToString(), data["identitycard"].ToString(), data["familycard"].ToString(), Int32.Parse(data["balance"].ToString()), data["type"].ToString());
                Window a = new PinConfirmationATM(customer, receiver, Int32.Parse(amounttxt.Text.ToString()), "regularacc");
                a.Show();
                this.Close();
            }

        }

     

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window a = new ATMWindow(customer);
            a.Show();
            this.Close();
        }
    }
}
