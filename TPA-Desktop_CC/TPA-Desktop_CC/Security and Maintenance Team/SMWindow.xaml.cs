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

namespace TPA_Desktop_CC.Security_and_Maintenance_Team
{
    /// <summary>
    /// Interaction logic for SMWindow.xaml
    /// </summary>
    public partial class SMWindow : Window
    {
        Employee employee;
        public SMWindow(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
            hellotxt.Content = "Hello, " + emp.name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window login = new WindowLogin();
            login.Show();
            this.Close();
        }

        private void vsbutton(object sender, RoutedEventArgs e)
        {
            Window vs = new SMViewSchedule(employee);
            vs.Show();
            this.Close();
        }

        private void reportbutton(object sender, RoutedEventArgs e)
        {
            Window ri = new SMReportItem(employee);
            ri.Show();
            this.Close();
        }

        private void handlebutton(object sender, RoutedEventArgs e)
        {
            Window hi = new SMHandleItems(employee);
            hi.Show();
            this.Close();
        }
    }
}
