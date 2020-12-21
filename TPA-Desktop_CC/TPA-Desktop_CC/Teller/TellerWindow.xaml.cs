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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TPA_Desktop_CC.Teller;

namespace TPA_Desktop_CC
{
    /// <summary>
    /// Interaction logic for TellerWindow.xaml
    /// </summary>
    public partial class TellerWindow : Window
    {
        Employee employee;
        public TellerWindow(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
            hellotxt.Content = "Hello, " + emp.name;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Window nextwindow = new FindCustomer("depositmoney", employee);
            nextwindow.Show();
            this.Close();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Window nextwindow = new FindCustomer("transfermoney", employee);
            nextwindow.Show();
            this.Close();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Window nextwindow = new Payments(employee);
            nextwindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window loginwindow = new WindowLogin();
            loginwindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window nextwindow = new FindCustomer("withdrawmoney", employee);
            nextwindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window tp = new TellerOthers(employee);
            tp.Show();
            this.Close();
        }
    }
}
