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

namespace TPA_Desktop_CC
{
    /// <summary>
    /// Interaction logic for WithdrawMoney.xaml
    /// </summary>
    public partial class WithdrawMoney : Window
    {
        Employee employee;
        Customer customer;
        ConnectDatabase connect;
        public WithdrawMoney(Employee emp, Customer cust)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            this.customer = cust;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window tellerwindow = new TellerWindow(employee);
            tellerwindow.Show();
            this.Close();
        }

        private void done(object sender, RoutedEventArgs e)
        {
            if (amountxt.Text == "")
            {
                MessageBox.Show("Must Input Amount!");
                return;
            }
            int amount = Int32.Parse(amountxt.Text.ToString());

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
            dt = connect.executeQuery("select sum(amount) as 'Total' from transaction where transactiontype = 'Withdraw Money' and receiver = '" + customer.accountnumber + "' and date = current_date");
            DataRow data = dt.Rows[0];
            //if (Int32.Parse(data["Total"].ToString()) + Int32.Parse(amountxt.Text.ToString()) > 2500000 && customer.type == "Bronze")
            //{
            //    MessageBox.Show("You have achieved the limit of withdraw money today!");
            //    Window a = new TellerWindow(employee);
            //    a.Show();
            //    this.Close();
            //    return;
            //}
            //if (Int32.Parse(data["Total"].ToString()) + Int32.Parse(amountxt.Text.ToString()) > 5000000 && customer.type == "Silver")
            //{
            //    MessageBox.Show("You have achieved the limit of withdraw money today!");
            //    Window a = new TellerWindow(employee);
            //    a.Show();
            //    this.Close();
            //    return;
            //}
            //if (Int32.Parse(data["Total"].ToString()) + Int32.Parse(amountxt.Text.ToString()) > 7500000 && customer.type == "Gold")
            //{
            //    MessageBox.Show("You have achieved the limit of withdraw money today!");
            //    Window a = new TellerWindow(employee);
            //    a.Show();
            //    this.Close();
            //    return;
            //}
            //if (Int32.Parse(data["Total"].ToString()) + Int32.Parse(amountxt.Text.ToString()) > 10000000 && customer.type == "Black")
            //{
            //    MessageBox.Show("You have achieved the limit of withdraw money today!");
            //    Window a = new TellerWindow(employee);
            //    a.Show();
            //    this.Close();
            //    return;
            //}
            //if (Int32.Parse(data["Total"].ToString()) + Int32.Parse(amountxt.Text.ToString()) > 1000000 && customer.type == "Student")
            //{
            //    MessageBox.Show("You have achieved the limit of withdraw money today!");
            //    Window a = new TellerWindow(employee);
            //    a.Show();
            //    this.Close();
            //    return;
            //}

            string id = customer.accountnumber;

                connect.executeUpdate("update customer set balance = balance - "+amount+" where accountnumber = '"+id+"'");
                connect.executeUpdate("insert into transaction values('','', 'Withdraw Money', "+amount+", '"+customer.accountnumber+"', '', current_Date)");
                
                MessageBox.Show("Success Withdraw Money!");
                Window qrcode = new QRCode(employee);
                qrcode.Show();
                this.Close();
        }
    }
}
