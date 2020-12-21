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
    /// Interaction logic for PinConfirmationATM.xaml
    /// </summary>
    public partial class PinConfirmationATM : Window
    {
        Customer sendercust;
        Customer receiver;
        string virtualacc = "";
        string action = "";
        int amount;
        DataTable dt2;
        ConnectDatabase connect = ConnectDatabase.getInstance();

        public PinConfirmationATM(Customer sdr, Customer rcvr, int amount, string action)
        {
            this.sendercust = sdr;
            this.receiver = rcvr;
            this.amount = amount;
            this.action = action;
            InitializeComponent();
        }

        public PinConfirmationATM(Customer sdr, string virtualacc, int amount, string action)
        {
            this.sendercust = sdr;
            this.virtualacc = virtualacc;
            this.amount = amount;
            this.action = action;
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (pintxt.Password == "")
            {
                MessageBox.Show("PIN must be inputted!");
                return;
            }
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select * from customer where accountnumber = '"+ sendercust.accountnumber + "' and pin = '" + pintxt.Password.ToString() + "' limit 1");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Your PIN is incorrect!");
                return;
            }
            if (sendercust.balance - amount <= 50000 && sendercust.type.ToString() != "Student")
            {
                MessageBox.Show("The Balance left in your account must be more than or equals 50000!");
                return;
            }
            if (sendercust.balance - amount <= 1000 && sendercust.type.ToString() == "Student")
            {
                MessageBox.Show("The Balance left in your account must be more than or equals 1000!");
                return;
            }

            DataTable dt2 = new DataTable();
            dt2 = connect.executeQuery("select sum(amount) as Total from transaction where transactiontype in ('Transfer Money','Payments','Deposit Money') and senderaccnum = '" + sendercust.accountnumber + "' and date = current_date");
            DataRow data = dt2.Rows[0];
            //if (long.Parse(data["Total"].ToString()) + amount > 2000000 && sendercust.type == "Bronze")
            //{
            //    MessageBox.Show("You have achieved the limit of transfer money today!");
            //    Window a = new ATMWindow(sendercust);
            //    a.Show();
            //    this.Close();
            //    return;
            //}
            //if (long.Parse(data["Total"].ToString()) + amount > 3000000 && sendercust.type == "Silver")
            //{
            //    MessageBox.Show("You have achieved the limit of transfer money today!");
            //    Window a = new ATMWindow(sendercust);
            //    a.Show();
            //    this.Close();
            //    return;
            //}
            //if (long.Parse(data["Total"].ToString()) + amount > 5000000 && sendercust.type == "Gold")
            //{
            //    MessageBox.Show("You have achieved the limit of transfer money today!");
            //    Window a = new ATMWindow(sendercust);
            //    a.Show();
            //    this.Close();
            //    return;
            //}
            //if (long.Parse(data["Total"].ToString()) + amount > 7000000 && sendercust.type == "Black")
            //{
            //    MessageBox.Show("You have achieved the limit of transfer money today!");
            //    Window a = new ATMWindow(sendercust);
            //    a.Show();
            //    this.Close();
            //    return;
            //}
            //if (long.Parse(data["Total"].ToString()) +amount > 500000 && sendercust.type == "Student")
            //{
            //    MessageBox.Show("You have achieved the limit of transfer money today!");
            //    Window a = new ATMWindow(sendercust);
            //    a.Show();
            //    this.Close();
            //    return;
            //}

            if (action == "regularacc")
            {
                connect.executeUpdate("update customer set balance = balance - '" + amount + "' where accountnumber = '" + sendercust.accountnumber + "'");
                connect.executeUpdate("update customer set balance = balance + '" + amount + "' where accountnumber = '" + receiver.accountnumber + "'");
                connect.executeUpdate("insert into transaction values('"+ sendercust.name + "','" + sendercust.accountnumber + "', 'Transfer Money', "+amount+ ", '" + receiver.accountnumber + "', '', current_date)");
                
                MessageBox.Show("Success Transfer!");
                Window atm = new ATMWindow(sendercust);
                atm.Show();
                this.Close();
            }
            else if (action == "virtualacc")
            {
                
                connect.executeUpdate("update customer set balance = balance - "+amount+" where accountnumber = '"+ sendercust.accountnumber + "'");

                connect.executeUpdate("insert into transaction values('"+ sendercust.name + "','"+ sendercust.accountnumber + "', 'Transfer Money', "+amount+", '"+ virtualacc + "', '', current_date)");

                connect.executeUpdate("update virtualaccount set status = 'Paid' where virtualaccount = '" + virtualacc + "'");
                MessageBox.Show("Success Transfer!");
                Window atm = new ATMWindow(sendercust);
                atm.Show();
                this.Close();
            }
            else if (action == "deposit")
            {
                dt2 = new DataTable();
                dt2 = connect.executeQuery("select * from deposit where accountnumber = '"+receiver.accountnumber+"' and enddate - current_date > 0");

                int size = dt2.Rows.Count;

                if (size == 0)
                {
                    MessageBox.Show("This user has no deposit account or deposit account has expired!");
                    return;
                }
                connect.executeUpdate("update customer set balance = balance - "+amount+" where accountnumber = '"+sendercust.accountnumber+"'");
                Double balance = 0;
                DataRow dtrow = dt2.Rows[0];
                if ((dtrow["currency"].ToString()).Equals("IDR"))
                {
                    balance = amount;
                }
                else if ((dtrow["currency"].ToString()).Equals("IDR"))
                {
                    balance = amount / 10638;
                }
                else
                {
                    balance = amount / 14116;
                }
                connect.executeUpdate("update deposit set depositmoney = depositmoney + "+balance+" where accountnumber = '"+receiver.accountnumber+"'");
                connect.executeUpdate("insert into transaction values('"+ sendercust.name + "','"+ sendercust.accountnumber + "', 'Deposit Money', "+amount+", '"+ receiver.accountnumber + "', '', current_Date)");

                MessageBox.Show("Deposit Money Success!");
                Window atm = new ATMWindow(sendercust);
                atm.Show();
                this.Close();
            }
        }

        private void CANCEL(object sender, RoutedEventArgs e)
        {
            Window a = new ATMWindow(sendercust);
            a.Show();
            this.Close();
        }
    }
}
