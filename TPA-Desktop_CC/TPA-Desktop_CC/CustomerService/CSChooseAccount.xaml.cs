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
    /// Interaction logic for CSChooseAccount.xaml
    /// </summary>
    public partial class CSChooseAccount : Window
    {
        Employee employee;
        public CSChooseAccount(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
        }

        private void individualacc(object sender, RoutedEventArgs e)
        {
            Window a = new CSIndividualAcc(employee);
            a.Show();
            this.Close();
        }

        private void businessacc(object sender, RoutedEventArgs e)
        {
            new CSBusinessAcc(employee).Show();
            this.Close();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window a = new CSWindow(employee);
            a.Show();
            this.Close();
        }

        private void depositacc(object sender, RoutedEventArgs e)
        {
            Window a = new CSDepositAcc(employee);
            a.Show();
            this.Close();
        }

        private void savingacc(object sender, RoutedEventArgs e)
        {
            Window a = new CSSavingAcc(employee);
            a.Show();
            this.Close();
        }
    }
}
