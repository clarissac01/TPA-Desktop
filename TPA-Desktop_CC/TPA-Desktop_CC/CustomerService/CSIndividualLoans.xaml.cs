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
    /// Interaction logic for CSIndividualLoans.xaml
    /// </summary>
    public partial class CSIndividualLoans : Window
    {
        Employee employee;
        ConnectDatabase connect;
        List<string> lists = new List<string>();
        public CSIndividualLoans(Employee emp)
        {
            this.employee = emp;
            this.connect = ConnectDatabase.getInstance();
            InitializeComponent();
            lists.Add("Land Title Deed");
            lists.Add("Vehicle License");
            lists.Add("Personal Bills");
            lists.Add("Income Slip");
            combobox.ItemsSource = lists;
        }

        private void bacl(object sender, RoutedEventArgs e)
        {
            Window a = new CSChooseLoans(employee);
            a.Show();
            this.Close();
        }

        private void again(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select * from customer where accountnumber = '" + accnumtxt.Text + "'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid Customer!");
                return;
            }
            else
            {
                if (combobox.SelectedIndex == -1)
                {
                    MessageBox.Show("You must choose document type!");
                    return;
                }
                if (amountxt.Text == "")
                {
                    MessageBox.Show("You must input the amount!");
                    return;
                }
                connect.executeUpdate("insert into guaranteedocument values ('"+combobox.SelectedValue.ToString()+"',"+Int32.Parse(amountxt.Text.ToString())+",'"+accnumtxt.Text+"')");
            }
            MessageBox.Show("Success");
            accnumtxt.Text = "";
            combobox.SelectedIndex = -1;
            amountxt.Text = "";
        }

        private void done(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select * from customer where accountnumber = '" + accnumtxt.Text + "'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid Customer!");
                return;
            }
            else
            {
                if (combobox.SelectedIndex == -1)
                {
                    MessageBox.Show("You must choose document type!");
                    return;
                }
                if (amountxt.Text == "")
                {
                    MessageBox.Show("You must input the amount!");
                    return;
                }
                connect.executeUpdate("insert into guaranteedocument values ('" + combobox.SelectedValue.ToString() + "'," + Int32.Parse(amountxt.Text.ToString()) + ",'" + accnumtxt.Text + "')");
            }
            MessageBox.Show("Success");
            Window a = new CSInputIndividualLoan(employee);
            a.Show();
            this.Close();
        }
    }
}
