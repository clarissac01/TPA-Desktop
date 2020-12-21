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
    public partial class CSDepositAcc : Window
    {
        Employee employee;
        ConnectDatabase connect;
        List<string> list = new List<string>();
        List<string> list2 = new List<string>();
        public CSDepositAcc(Employee emp)
        {
            this.employee = emp;
            this.connect = ConnectDatabase.getInstance();
            InitializeComponent();
            list.Add("IDR");
            list.Add("SGD");
            list.Add("USD");
            combobox.ItemsSource = list;
            combobox.SelectedIndex = 0;
            list2.Add("3 months");
            list2.Add("6 months");
            list2.Add("12 months");
            combobox_time.ItemsSource = list2;
            combobox_time.SelectedIndex = -1;
            checkbox.IsChecked = false;
        }

        private void submitbtn(object sender, RoutedEventArgs e)
        {
            if (accnumtxt.Text == "")
            {
                MessageBox.Show("Account number must be inputted!");
                accnumtxt.Text = "";
                amountxt.Text = "";
                checkbox.IsChecked = false;
                return;
            }
            if (amountxt.Text == "")
            {
                MessageBox.Show("Amount must not be empty!");
                accnumtxt.Text = "";
                amountxt.Text = "";
                checkbox.IsChecked = false;
                return;
            }
            if (combobox_time.SelectedIndex == -1)
            {
                MessageBox.Show("Time must be selected!");
                accnumtxt.Text = "";
                amountxt.Text = "";
                checkbox.IsChecked = false;
                return;
            }
            else if (Int32.Parse(amountxt.Text) < 1000000 && combobox.SelectedValue.ToString().Equals("IDR"))
            {
                MessageBox.Show("Deposit amount must be minimal IDR 1000000!");
                accnumtxt.Text = "";
                amountxt.Text = "";
                checkbox.IsChecked = false;
                return;
            }
            else if (Int32.Parse(amountxt.Text) < 94 && combobox.SelectedValue.ToString().Equals("SGD"))
            {
                MessageBox.Show("Deposit amount must be minimal SGD 94!");
                accnumtxt.Text = "";
                amountxt.Text = "";
                checkbox.IsChecked = false;
                return;
            }
            else if(Int32.Parse(amountxt.Text) < 70 && combobox.SelectedValue.ToString().Equals("USD"))
            {
                MessageBox.Show("Deposit amount must be minimal USD 70!");
                accnumtxt.Text = "";
                amountxt.Text = "";
                checkbox.IsChecked = false;
                return;
            }
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select * from customer where accountnumber = '" + accnumtxt.Text + "'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("User must be registered in this bank!");
                accnumtxt.Text = "";
                amountxt.Text = "";
                checkbox.IsChecked = false;
                return;
            }
            DataTable dt2 = new DataTable();
            dt2 = connect.executeQuery("select * from deposit where accountnumber = '" + accnumtxt.Text.ToString() + "'");
            if (dt2.Rows.Count != 0)
            {
                MessageBox.Show("User has already registered deposit account!");
                accnumtxt.Text = "";
                amountxt.Text = "";
                checkbox.IsChecked = false;
                return;
            }
            int time = 0;
            if(combobox_time.SelectedIndex == 0)
            {
                time = 3;
            }
            else if (combobox_time.SelectedIndex == 1)
            {
                time = 6;
            }
            else
            {
                time = 12;
            }
            int aro = 0;
            if(checkbox.IsChecked == true)
            {
                aro = 0;
            }
            else
            {
                aro = 1;
            }
            connect.executeUpdate("insert into deposit values('" + accnumtxt.Text + "'," + amountxt.Text + ",'"+combobox.SelectedValue+"', current_date, current_Date + interval "+time+" month, "+time+", "+aro+")");
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
