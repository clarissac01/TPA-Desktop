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

namespace TPA_Desktop_CC.Teller
{
    /// <summary>
    /// Interaction logic for TellerOthers.xaml
    /// </summary>
    public partial class TellerOthers : Window
    {
        Employee employee;
        public TellerOthers(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new TellerWindow(employee);
            back.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window tr = new TellerReportItem(employee);
            tr.Show();
            this.Close();
        }
    }
}
