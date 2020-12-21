using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
using System.Data;

namespace TPA_Desktop_CC.ATM
{
    /// <summary>
    /// Interaction logic for ATMPayments.xaml
    /// </summary>
    public partial class ATMPayments : Window
    {
        Customer customer;
        List<string> types = new List<string>();
        ConnectDatabase connect;

        public ATMPayments(Customer cust)
        {
            this.customer = cust;
            this.connect = ConnectDatabase.getInstance();

            InitializeComponent();

            types.Add("Electric Bill");
            types.Add("Phone Bill");
            types.Add("Voucher");
            types.Add("E-Commerce");
            types.Add("Credit Card");
            types.Add("Tickets");
            types.Add("Others");

            typebox.ItemsSource = types;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new ATMWindow(customer);
            back.Show();
            this.Close();
        }

        private void done(object sender, RoutedEventArgs e)
        {
            if(rcvtxt.Text == "")
            {
                MessageBox.Show("Account Number Must Be Filled!");
                return;
            }
            if(amountxt.Text == "")
            {
                MessageBox.Show("Amount Must Be Filled!");
                return;
            }
            int balance = Int32.Parse(amountxt.Text.ToString());

            string receiver = rcvtxt.Text.ToString();

            string note = typebox.SelectedValue.ToString();

            if (customer.balance - Int32.Parse(amountxt.Text.ToString()) <= 50000 && customer.type.ToString() != "Student")
            {
                MessageBox.Show("The Balance left in your account must be more than or equals 50000!");
                return;
            }
            if (customer.balance - Int32.Parse(amountxt.Text.ToString()) <= 1000 && customer.type.ToString() == "Student")
            {
                MessageBox.Show("The Balance left in your account must be more than or equals 1000!");
                return;
            }

            DataTable dt = new DataTable();
            dt = connect.executeQuery("select sum(amount) as 'Total' from transaction where transactiontype in ('Transfer Money','Payments') and senderaccnum = '" + customer.accountnumber + "' and date = current_date");
            DataRow data = dt.Rows[0];
            if (Int32.Parse(data["Total"].ToString()) + Int32.Parse(amountxt.Text.ToString()) > 2000000 && customer.type == "Bronze")
            {
                MessageBox.Show("You have achieved the limit of transfer money today!");
                Window a = new ATMWindow(customer);
                a.Show();
                this.Close();
                return;
            }
            if (Int32.Parse(data["Total"].ToString()) + Int32.Parse(amountxt.Text.ToString()) > 3000000 && customer.type == "Silver")
            {
                MessageBox.Show("You have achieved the limit of transfer money today!");
                Window a = new ATMWindow(customer);
                a.Show();
                this.Close();
                return;
            }
            if (Int32.Parse(data["Total"].ToString()) + Int32.Parse(amountxt.Text.ToString()) > 5000000 && customer.type == "Gold")
            {
                MessageBox.Show("You have achieved the limit of transfer money today!");
                Window a = new ATMWindow(customer);
                a.Show();
                this.Close();
                return;
            }
            if (Int32.Parse(data["Total"].ToString()) + Int32.Parse(amountxt.Text.ToString()) > 7000000 && customer.type == "Black")
            {
                MessageBox.Show("You have achieved the limit of transfer money today!");
                Window a = new ATMWindow(customer);
                a.Show();
                this.Close();
                return;
            }
            if (Int32.Parse(data["Total"].ToString()) + Int32.Parse(amountxt.Text.ToString()) > 500000 && customer.type == "Student")
            {
                MessageBox.Show("You have achieved the limit of transfer money today!");
                Window a = new ATMWindow(customer);
                a.Show();
                this.Close();
                return;
            }

            string id = customer.accountnumber;
            connect.executeUpdate("update customer set balance = balance - "+balance+" where accountnumber = '"+id+"'");

            connect.executeUpdate("insert into transaction values('" + customer.name + "','" + customer.accountnumber + "', 'Payments', " + balance+", '" + receiver + "', '" + note+"', current_Date)");

            MessageBox.Show("Success!");
            Window nextw = new ATMWindow(customer);
            nextw.Show();
            this.Close();

        }
    }
}
