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
    /// Interaction logic for ATMDeposit.xaml
    /// </summary>
    public partial class ATMDeposit : Window
    {
        Customer customer;
        ConnectDatabase connect;

        public ATMDeposit(Customer cust)
        {
            this.connect = ConnectDatabase.getInstance();
            this.customer = cust;
            InitializeComponent();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window a = new ATMWindow(customer);
            a.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(accnumtxt.Text == "")
            {
                MessageBox.Show("Account Number Must Be Filled!");
                return;
            }
            if(amountxt.Text == "")
            {
                MessageBox.Show("Amount Must Be Filled!");
                return;
            }

            DataTable dt = new DataTable();
            dt = connect.executeQuery("select * from customer where accountnumber = '"+ accnumtxt.Text.ToString() + "' limit 1");
            if (dt.Rows.Count == 0)
            {
                label.Content = "Invalid Username/Password!";
                return;
            }
            else
            {
                DataRow data = dt.Rows[0];
                Customer rvcr = new Customer(data["accountnumber"].ToString(), data["pin"].ToString(), data["name"].ToString(), data["identitycard"].ToString(), data["familycard"].ToString(), Int32.Parse(data["balance"].ToString()), data["type"].ToString());
                if(customer.familycard != rvcr.familycard)
                {
                    MessageBox.Show("Only siblings can do deposit!");
                    return;
                }
                else
                {
                    Window next = new PinConfirmationATM(customer, rvcr, Int32.Parse(amountxt.Text.ToString()), "deposit");
                    next.Show();
                    this.Close();
                }
            }
        }
    }
}
