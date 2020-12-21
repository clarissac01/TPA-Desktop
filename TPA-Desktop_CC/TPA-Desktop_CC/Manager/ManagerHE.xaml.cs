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
    /// Interaction logic for ManagerHE.xaml
    /// </summary>
    public partial class ManagerHE : Window
    {
        Employee employee;
        public ManagerHE(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
        }


        private void back(object sender, RoutedEventArgs e)
        {
            Window a = new Manager.ManagerWindow(employee);
            a.Show();
            this.Close();
        }

        private void viewall(object sender, RoutedEventArgs e)
        {
            Window b = new Manager.ManagerHandleFiring(employee);
            b.Show();
            this.Close();
        }

        private void viewreq(object sender, RoutedEventArgs e)
        {
            Window c = new Manager.ManagerViewFireRequest(employee);
            c.Show();
            this.Close();
        }

        private void resignation(object sender, RoutedEventArgs e)
        {
            Window d = new ManagerViewResignation(employee);
            d.Show();
            this.Close();
        }
    }
}
