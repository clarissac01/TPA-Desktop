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
    /// Interaction logic for DepositMoney.xaml
    /// </summary>
    public partial class DepositMoney : Window
    {
        Employee employee;
        Customer customer;
        DataTable dt;
        DataTable dt2;
        DataRow data;
        List<string> sendernames = new List<string>();
        List<string> senderaccnum = new List<string>();
        List<string> senderfamilycard = new List<string>();
        ConnectDatabase connect;

        public DepositMoney(Customer cust, Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            this.customer = cust;
            InitializeComponent();
           
            dt = new DataTable();
            dt = connect.executeQuery("select * from customer");

            int size = dt.Rows.Count;
            for (int i = 0; i < size; i++)
            {
                data = dt.Rows[i];
                sendernames.Add(data["name"].ToString());
                senderaccnum.Add(data["accountnumber"].ToString());
                senderfamilycard.Add(data["familycard"].ToString());
            }
            combobox.ItemsSource = sendernames;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window tellerwindow = new TellerWindow(employee);
            tellerwindow.Show();
            this.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (nominaltxt.Text == "")
            {
                MessageBox.Show("Must Input Nominal!");
                return;
            }
            int balance = Int32.Parse(nominaltxt.Text.ToString());

            if (senderfamilycard.ElementAt(combobox.SelectedIndex).Equals(customer.familycard))
            {
                DataTable getsender = new DataTable();
                getsender = connect.executeQuery("select * from customer where accountnumber = '" + senderaccnum.ElementAt(combobox.SelectedIndex) + "' limit 1");
                DataRow data2 = getsender.Rows[0];
                Customer sendercust = new Customer(data2["accountnumber"].ToString(), data2["pin"].ToString(), data2["name"].ToString(), data2["identitycard"].ToString(), data2["familycard"].ToString(), Int32.Parse(data2["balance"].ToString()), data2["type"].ToString());

                if (sendercust.balance - balance <= 50000 && sendercust.type.ToString() != "Student")
                {
                    MessageBox.Show("The Balance left in your account must be more than or equals 50000!");
                    return;
                }
                if (sendercust.balance - balance <= 1000 && sendercust.type.ToString() == "Student")
                {
                    MessageBox.Show("The Balance left in your account must be more than or equals 1000!");
                    return;
                }

                DataTable dt2 = new DataTable();
                dt2 = connect.executeQuery("select sum(amount) as 'Total' from transaction where transactiontype in ('Transfer Money','Payments','Deposit Money') and senderaccnum = '" + sendercust.accountnumber + "' and date = current_date");
                DataRow data = dt2.Rows[0];
                if (Int32.Parse(data["Total"].ToString()) + balance > 2000000 && sendercust.type == "Bronze")
                {
                    MessageBox.Show("You have achieved the limit of transfer money today!");
                    Window a = new TellerWindow(employee);
                    a.Show();
                    this.Close();
                    return;
                }
                if (Int32.Parse(data["Total"].ToString()) + balance > 3000000 && sendercust.type == "Silver")
                {
                    MessageBox.Show("You have achieved the limit of transfer money today!");
                    Window a = new TellerWindow(employee);
                    a.Show();
                    this.Close();
                    return;
                }
                if (Int32.Parse(data["Total"].ToString()) + balance > 5000000 && sendercust.type == "Gold")
                {
                    MessageBox.Show("You have achieved the limit of transfer money today!");
                    Window a = new TellerWindow(employee);
                    a.Show();
                    this.Close();
                    return;
                }
                if (Int32.Parse(data["Total"].ToString()) + balance > 7000000 && sendercust.type == "Black")
                {
                    MessageBox.Show("You have achieved the limit of transfer money today!");
                    Window a = new TellerWindow(employee);
                    a.Show();
                    this.Close();
                    return;
                }
                if (Int32.Parse(data["Total"].ToString()) + balance > 500000 && sendercust.type == "Student")
                {
                    MessageBox.Show("You have achieved the limit of transfer money today!");
                    Window a = new TellerWindow(employee);
                    a.Show();
                    this.Close();
                    return;
                }

                string id = customer.accountnumber;

                dt2 = new DataTable();
                dt2 = connect.executeQuery("select * from deposit where accountnumber = '"+customer.accountnumber+"' and enddate - current_date > 0");

                int size = dt2.Rows.Count;

                if (size == 0)
                {
                    MessageBox.Show("This user has no deposit account or deposit account has expired!");
                    return;
                }
                connect.executeUpdate("insert into transaction values('"+ combobox.Text + "','" + senderaccnum.ElementAt(combobox.SelectedIndex) + "', 'Deposit Money', "+ balance + ", '"+id+"', '', current_Date)");

                Double amount = 0;
                DataRow dtrow = dt2.Rows[0];
                if (Double.Parse(dtrow["currency"].ToString()).Equals("IDR"))
                {
                    amount = balance;
                }
                else if (Double.Parse(dtrow["currency"].ToString()).Equals("IDR"))
                {
                    amount = balance / 10638;
                }
                else
                {
                    amount = balance / 14116;
                }
                
                connect.executeUpdate("update deposit set depositmoney = depositmoney + "+amount+" where accountnumber = '"+id+"'");

                connect.executeUpdate("update customer set balance = balance - "+balance+" where accountnumber = '"+ senderaccnum.ElementAt(combobox.SelectedIndex) + "'");

                MessageBox.Show("Deposit Money Success!");
                Window qrcode = new QRCode(employee);
                qrcode.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Only family can do deposit!");
            }
        }
    }
}
