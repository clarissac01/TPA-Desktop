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
    /// Interaction logic for CSOthers.xaml
    /// </summary>
    public partial class CSOthers : Window
    {
        Employee employee;
        public CSOthers(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new CSWindow(employee);
            back.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window ri = new CSReportItem(employee);
            ri.Show();
            this.Close();
        }
    }
}
