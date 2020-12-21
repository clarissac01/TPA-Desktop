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
    /// Interaction logic for TransferMoney.xaml
    /// </summary>
    public partial class TransferMoney : Window
    {
        Employee employee;
        Customer customer;
        List<string> sendernames = new List<string>();
        List<string> senderaccnum = new List<string>();
        DataTable dt;
        DataRow data;
        ConnectDatabase connect;

        public TransferMoney(Employee emp, Customer cust)
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
            }
            combobox.ItemsSource = sendernames;
        }

        

        private void done(object sender, RoutedEventArgs e)
        {
            if(nominaltxt.Text == "")
            {
                MessageBox.Show("Must Input Nominal!");
                return;
            }
            int balance = Int32.Parse(nominaltxt.Text.ToString());
            string id = customer.accountnumber;

            if (combobox.SelectedIndex<0)
            {
                string note = new TextRange(notetxt.Document.ContentStart, notetxt.Document.ContentEnd).Text;
                connect.executeUpdate("insert into transaction values('"+combobox.Text+"','', 'Transfer Money', "+balance+", '"+id+"', '"+note+"', current_Date)");
            }
            else
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
                string note = new TextRange(notetxt.Document.ContentStart, notetxt.Document.ContentEnd).Text;
                connect.executeUpdate("insert into transaction values('"+combobox.Text+"','" + senderaccnum.ElementAt(combobox.SelectedIndex) + "', 'Transfer Money', " + balance+", '" + id + "', '" + note+"', current_date)");
                connect.executeUpdate("update customer set balance = balance - " + balance + " where accountnumber = '" + senderaccnum.ElementAt(combobox.SelectedIndex) + "'");
            }
            connect.executeUpdate("update customer set balance = balance + " + balance + " where accountnumber = '" + id + "'");
            MessageBox.Show("Success Transfer to "+customer.name);
            Window qrcode = new QRCode(employee);
            qrcode.Show();
            this.Close();

        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window tellerwindow = new TellerWindow(employee);
            tellerwindow.Show();
            this.Close();
        }
    }
}
