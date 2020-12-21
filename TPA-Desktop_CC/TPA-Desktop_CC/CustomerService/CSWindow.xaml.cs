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

namespace TPA_Desktop_CC.CustomerService
{
    /// <summary>
    /// Interaction logic for CSWindow.xaml
    /// </summary>
    public partial class CSWindow : Window
    {
        Employee employee;
        public CSWindow(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
            hellotxt.Content = "Hello, " + emp.name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window next = new WindowLogin();
            next.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window next = new CSFindCustomer(employee);
            next.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window a = new CSOthers(employee);
            a.Show();
            this.Close();
        }

        private void handlemoneyloans(object sender, RoutedEventArgs e)
        {
            Window a = new CSChooseLoans(employee);
            a.Show();
            this.Close();
        }

        private void createaccount(object sender, RoutedEventArgs e)
        {
            Window cschooseacc = new CSChooseAccount(employee);
            cschooseacc.Show();
            this.Close();
        }

        private void createvirtualacc(object sender, RoutedEventArgs e)
        {
            new CSVirtualAcc(employee).Show();
            this.Close();
        }
    }
}
