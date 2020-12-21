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
    /// Interaction logic for ManagerCheckRequest.xaml
    /// </summary>
    public partial class ManagerCheckRequest : Window
    {
        Employee employee;
        public ManagerCheckRequest(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
        }

        private void firingreq(object sender, RoutedEventArgs e)
        {
            Window a = new ManagerCheckFireRequest(employee);
            a.Show();
            this.Close();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window a = new ManagerWindow(employee);
            a.Show();
            this.Close();
        }
    }
}
