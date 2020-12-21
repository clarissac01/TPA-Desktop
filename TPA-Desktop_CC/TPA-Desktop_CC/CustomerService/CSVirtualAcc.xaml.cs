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

namespace TPA_Desktop_CC.CustomerService
{
    /// <summary>
    /// Interaction logic for CSVirtualAcc.xaml
    /// </summary>
    public partial class CSVirtualAcc : Window
    {
        ConnectDatabase connect;
        Employee employee;
        public CSVirtualAcc(Employee employee)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = employee;
            InitializeComponent();
        }

        private void nextbtn(object sender, RoutedEventArgs e)
        {
            if (clientxt.Text == "")
            {
                MessageBox.Show("Client Account Must Not Be Empty!");
                return;
            }
            if (receivertxt.Text == "")
            {
                MessageBox.Show("Receiver Account Must Not Be Empty!");
                return;
            }
            if (amountxt.Text == "")
            {
                MessageBox.Show("Amount Must Not Be Empty!");
                return;
            }
            if (durationtxt.Text == "")
            {
                MessageBox.Show("Duration Must Not Be Empty!");
                return;
            }
            string virtualacc = Guid.NewGuid().ToString("N").Substring(0, 8);
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt1 = connect.executeQuery("select * from customer where accountnumber = '" + clientxt.Text + "'");
            if (dt1.Rows.Count == 0)
            {
                MessageBox.Show("This client is not registered in this bank!");
                return;
            }
            dt2 = connect.executeQuery("select * from businesscard where businessaccount = '"+receivertxt.Text+"'");
            if (dt2.Rows.Count == 0)
            {
                MessageBox.Show("This business account is not from this bank!");
                return;
            }
            int duration = Int32.Parse(durationtxt.Text.ToString());
            connect.executeUpdate("insert into virtualaccount values ( '"+clientxt.Text+"', '"+receivertxt.Text+"', '"+virtualacc+"', "+amountxt.Text+", 'Not Paid', current_Date + interval "+duration+" month)");
            MessageBox.Show("Success Creating Virtual Account!\nGenerated virtual account:" + virtualacc + "");
            new CSWindow(employee).Show();
            this.Close();
        }

        private void backbtn(object sender, RoutedEventArgs e)
        {
            new CSChooseAccount(employee).Show();
            this.Close();
        }
    }
}
