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
    /// Interaction logic for Payments.xaml
    /// </summary>
    public partial class Payments : Window
    {
        Employee employee;
        List<string> sendernames = new List<string>();
        List<string> senderaccnum = new List<string>();
        List<string> types = new List<string>();
        DataTable dt;
        DataRow data;
        ConnectDatabase connect;
        public Payments(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
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

            types.Add("Electric Bill");
            types.Add("Phone Bill");
            types.Add("Voucher");
            types.Add("E-Commerce");
            types.Add("Credit Card");
            types.Add("Tickets");
            types.Add("Others");

            typebox.ItemsSource = types;
        }

        private void done(object sender, RoutedEventArgs e)
        {
            if (amountxt.Text == "")
            {
                MessageBox.Show("Must Input Nominal!");
                return;
            }
            if (rcvtxt.Text == "")
            {
                MessageBox.Show("Must Input Account Number!");
                return;
            }
            int balance = Int32.Parse(amountxt.Text.ToString());
            
            string receiver = rcvtxt.Text.ToString();

            string note = typebox.SelectedValue.ToString();
            
            if (combobox.SelectedIndex < 0)
            {
                connect.executeUpdate("insert into transaction values('"+ combobox.Text + "','', 'Payments', "+balance+", '"+receiver+"', '"+note+"', current_date)");
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
                //if (Int32.Parse(data["Total"].ToString()) + balance > 2000000 && sendercust.type == "Bronze")
                //{
                //    MessageBox.Show("You have achieved the limit of transfer money today!");
                //    Window a = new TellerWindow(employee);
                //    a.Show();
                //    this.Close();
                //    return;
                //}
                //if (Int32.Parse(data["Total"].ToString()) + balance > 3000000 && sendercust.type == "Silver")
                //{
                //    MessageBox.Show("You have achieved the limit of transfer money today!");
                //    Window a = new TellerWindow(employee);
                //    a.Show();
                //    this.Close();
                //    return;
                //}
                //if (Int32.Parse(data["Total"].ToString()) + balance > 5000000 && sendercust.type == "Gold")
                //{
                //    MessageBox.Show("You have achieved the limit of transfer money today!");
                //    Window a = new TellerWindow(employee);
                //    a.Show();
                //    this.Close();
                //    return;
                //}
                //if (Int32.Parse(data["Total"].ToString()) + balance > 7000000 && sendercust.type == "Black")
                //{
                //    MessageBox.Show("You have achieved the limit of transfer money today!");
                //    Window a = new TellerWindow(employee);
                //    a.Show();
                //    this.Close();
                //    return;
                //}
                //if (Int32.Parse(data["Total"].ToString()) + balance > 500000 && sendercust.type == "Student")
                //{
                //    MessageBox.Show("You have achieved the limit of transfer money today!");
                //    Window a = new TellerWindow(employee);
                //    a.Show();
                //    this.Close();
                //    return;
                //}

                string id = senderaccnum.ElementAt(combobox.SelectedIndex);
                connect.executeUpdate("update customer set balance = balance - "+balance+" where accountnumber = '"+id+"'");
                connect.executeUpdate("insert into transaction values('"+combobox.Text+"','"+ senderaccnum.ElementAt(combobox.SelectedIndex) + "', 'Payments', "+balance+", '"+receiver+"', '"+note+"', current_date)");
            }


            MessageBox.Show("Success!");
            Window qrcode = new QRCode(employee);
            qrcode.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window tellerwindow = new TellerWindow(employee);
            tellerwindow.Show();
            this.Close();
        }
    }
}
