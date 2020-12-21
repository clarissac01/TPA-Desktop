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
    /// Interaction logic for CSInputIndividualLoan.xaml
    /// </summary>
    public partial class CSInputIndividualLoan : Window
    {
        Employee employee;
        ConnectDatabase connect;
        List<string> lists = new List<string>();
        public CSInputIndividualLoan(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            lists.Add("House Renovation");
            lists.Add("Wedding");
            lists.Add("Pay Debt");
            lists.Add("Holiday");
            combobox.ItemsSource = lists;
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            if (accnumtxt.Text == "")
            {
                MessageBox.Show("Account Number must be inputted!");
                accnumtxt.Text = "";
                amountxt.Text = "";
                combobox.SelectedIndex = -1;
                return;
            }
            if(amountxt.Text == "")
            {
                MessageBox.Show("Amount must not be empty!");
                amountxt.Text = "";
                combobox.SelectedIndex = -1;
                accnumtxt.Text = "";
                return;
            }
            if(combobox.SelectedIndex == -1)
            {
                MessageBox.Show("Must choose loan reason!");
                amountxt.Text = "";
                combobox.SelectedIndex = -1;
                accnumtxt.Text = "";
                return;
            }
            if(Int32.Parse(amountxt.Text.ToString()) < 10000000 || Int32.Parse(amountxt.Text.ToString()) > 100000000){
                MessageBox.Show("Amount must be between 10000000 and 100000000!");
                amountxt.Text = "";
                combobox.SelectedIndex = -1;
                accnumtxt.Text = "";
                return;
            }
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select sum(amount) as 'Loan' from guaranteedocument where accountnumber = '"+accnumtxt.Text.ToString()+"'");
            DataRow data = dt.Rows[0];
            if(Int32.Parse(data["Loan"].ToString()) < Int32.Parse(amountxt.Text.ToString()))
            {
                MessageBox.Show("Loan not accepted!");
                return;
            }
            connect.executeQuery("insert into loanrequest values ('" + accnumtxt.Text.ToString() + "', 'Individual', '"+combobox.SelectedValue.ToString()+"'," + Int32.Parse(amountxt.Text.ToString()) + ", 'Pending')");
            connect.executeQuery("insert into financenotif values ('Customer Service', '" + employee.id + "', 'Individual Loan Request'," + Int32.Parse(amountxt.Text.ToString()) + ")");
            MessageBox.Show("Request submitted!");
            Window cswindow = new CSWindow(employee);
            cswindow.Show();
            this.Close();
        }
    }
}
