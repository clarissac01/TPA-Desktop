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
    /// Interaction logic for HRMManageEmployee.xaml
    /// </summary>
    public partial class HRMManageEmployee : Window
    {
        Employee employee;
        public HRMManageEmployee(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
        }

        private void recruitment(object sender, RoutedEventArgs e)
        {
            Window a = new HRMRecruitment(employee);
            a.Show();
            this.Close();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window a = new HRMWindow(employee);
            a.Show();
            this.Close();
        }

        private void viewemployee(object sender, RoutedEventArgs e)
        {
            Window viewemployee = new HRMViewEmployee(employee);
            viewemployee.Show();
            this.Close();
        }
    }
}
