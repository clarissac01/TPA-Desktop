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
    /// Interaction logic for CSChooseLoans.xaml
    /// </summary>
    public partial class CSChooseLoans : Window
    {
        Employee employee;
        public CSChooseLoans(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
        }

        private void individual(object sender, RoutedEventArgs e)
        {
            Window a = new CSIndividualLoans(employee);
            a.Show();
            this.Close();
        }

        private void business(object sender, RoutedEventArgs e)
        {

        }

        private void bacl(object sender, RoutedEventArgs e)
        {
            Window a = new CSWindow(employee);
            a.Show();
            this.Close();
        }
    }
}
