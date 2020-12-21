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

namespace TPA_Desktop_CC.Human_Resource_Management_Team
{
    /// <summary>
    /// Interaction logic for HRMWindow.xaml
    /// </summary>
    public partial class HRMWindow : Window
    {
        Employee employee;
        public HRMWindow(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
            hellotxt.Content = "Hello, " + emp.name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new WindowLogin();
            back.Show();
            this.Close();
        }

        private void manage(object sender, RoutedEventArgs e)
        {
            Window manage = new HRMManageEmployee(employee);
            manage.Show();
            this.Close();
        }

        private void handle(object sender, RoutedEventArgs e)
        {
            Window handle = new HRMHandleEmployee(employee);
            handle.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window a = new HRMOthers(employee);
            a.Show();
            this.Close();
        }
    }
}
