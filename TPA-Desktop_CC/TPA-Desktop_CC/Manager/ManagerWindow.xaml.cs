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

namespace TPA_Desktop_CC.Manager
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        Employee employee;
        public ManagerWindow(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
            hellotxt.Content = "Hello, " + emp.name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window mvt = new Manager.ManagerViewReport(employee);
            mvt.Show();
            this.Close();
        }

        private void signout(object sender, RoutedEventArgs e)
        {
            Window signout = new WindowLogin();
            signout.Show();
            this.Close();
        }

        private void expenses(object sender, RoutedEventArgs e)
        {
            Window erw = new Manager.ManagerViewExpensesAndRevenueReport(employee);
            erw.Show();
            this.Close();
        }

        private void handleemployee(object sender, RoutedEventArgs e)
        {
            Window he = new Manager.ManagerHE(employee);
            he.Show();
            this.Close();
        }

        private void checkrequest(object sender, RoutedEventArgs e)
        {
            Window a = new ManagerCheckRequest(employee);
            a.Show();
            this.Close();
        }
    }
}
