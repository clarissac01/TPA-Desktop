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

namespace TPA_Desktop_CC
{
    /// <summary>
    /// Interaction logic for FindCustomer.xaml
    /// </summary>
    public partial class FindCustomer : Window
    {
        string action;
        Employee employee;
        public FindCustomer(string nextaction, Employee emp)
        {
            this.action = nextaction;
            this.employee = emp;
            InitializeComponent();
            if (nextaction.Equals("depositmoney"))
            {
                actiontxt.Content = "Deposit Money";
            }
            else if (nextaction.Equals("transfermoney"))
            {
                actiontxt.Content = "Transfer Money";
            }
            else
            {
                actiontxt.Content = "Withdraw Money";
            }
        }

        private void ByName_Button(object sender, RoutedEventArgs e)
        {
            Window nextwindow = new FindCustomerByName(employee, action);
            nextwindow.Show();
            this.Close();
        }

        private void ByAccountName_Button(object sender, RoutedEventArgs e)
        {
            Window nextwindow = new FindCustomerByAccountNum(employee, action);
            nextwindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window next = new TellerWindow(employee);
            next.Show();
            this.Close();
        }
    }
}
