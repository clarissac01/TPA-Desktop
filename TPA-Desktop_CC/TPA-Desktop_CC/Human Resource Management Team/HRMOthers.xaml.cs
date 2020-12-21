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
    /// Interaction logic for HRMOthers.xaml
    /// </summary>
    public partial class HRMOthers : Window
    {
        Employee employee;
        public HRMOthers(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window home = new HRMWindow(employee);
            home.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window ri = new HRMReportItem(employee);
            ri.Show();
            this.Close();
        }
    }
}
