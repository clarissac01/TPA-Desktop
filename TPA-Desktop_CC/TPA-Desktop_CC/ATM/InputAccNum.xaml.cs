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
    /// Interaction logic for InputAccNum.xaml
    /// </summary>
    public partial class InputAccNum : Window
    {
        DataTable dt;
        List<string> listaccnumbers = new List<string>();
        ConnectDatabase connect;
        public InputAccNum()
        {
            this.connect = ConnectDatabase.getInstance();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(acctxt.Text == "")
            {
                label.Content = "Account Number must be filled!";
                return;
            }
            if(pintxt.Password == "")
            {
                label.Content = "PIN must be filled!";
                return;
            }

            string accnum = acctxt.Text;
            DataTable dt2 = new DataTable();
            dt = new DataTable();
            dt2 = new DataTable();
            dt = connect.executeQuery("select * from customer where accountnumber = '"+accnum+"' and pin = '"+ pintxt.Password.ToString() + "' limit 1");
            dt2 = connect.executeQuery("select * from customer c join saving s on s.accountnumber = c.accountnumber where c.accountnumber = '"+accnum+"' and c.pin = '"+ pintxt.Password.ToString() + "' limit 1");
            int count = 0;
            if (dt.Rows.Count == 0)
            {
                count++;
                label.Content = "Invalid User!";
                return;
            }
            else
            {
                DataRow data = dt.Rows[0];
                label.Content = "";
                Customer cust = new Customer(data["accountnumber"].ToString(), data["pin"].ToString(), data["name"].ToString(), data["identitycard"].ToString(), data["familycard"].ToString(), Int32.Parse(data["balance"].ToString()), data["type"].ToString());
                Window atm = new ATMWindow(cust);
                atm.Show();
                this.Close();
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window a = new Others();
            a.Show();
            this.Close();
        }
    }
}
