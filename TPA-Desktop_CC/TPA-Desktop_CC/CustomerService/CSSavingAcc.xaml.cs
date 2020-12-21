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
    /// Interaction logic for CSSavingAcc.xaml
    /// </summary>
    public partial class CSSavingAcc : Window
    {
        Employee employee;
        ConnectDatabase connect;
        public CSSavingAcc(Employee emp)
        {
            this.employee = emp;
            this.connect = ConnectDatabase.getInstance();
            InitializeComponent();
        }

        private void submitbtn(object sender, RoutedEventArgs e)
        {
            if(accnumtxt.Text == "")
            {
                MessageBox.Show("Account number must be inputted!");
                accnumtxt.Text = "";
                amountxt.Text = "";
                return;
            }
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select * from customer where accountnumber = '" + accnumtxt.Text + "'");
            if (dt.Rows.Count == 0) {
                MessageBox.Show("User must be registered in this bank!");
                accnumtxt.Text = "";
                amountxt.Text = "";
                return;
            }
            DataTable dt2 = new DataTable();
            dt2 = connect.executeQuery("select * from saving where accountnumber = '" + accnumtxt.Text.ToString() + "'");
            if (dt2.Rows.Count > 0)
            {
                MessageBox.Show("User has already registered saving account!");
                accnumtxt.Text = "";
                amountxt.Text = "";
                return;
            }
            connect.executeUpdate("insert into saving values('" + accnumtxt.Text + "','SA+cast ((select count(*)+1 from saving) as varchar)'," + amountxt.Text + ",current_Date)");
            MessageBox.Show("Success!");
            Window a = new CSWindow(employee);
            a.Show();
            this.Close();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window a = new CSChooseAccount(employee);
            a.Show();
            this.Close();
        }
    }
}
