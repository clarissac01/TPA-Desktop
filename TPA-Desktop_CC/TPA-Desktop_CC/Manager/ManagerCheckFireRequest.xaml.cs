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
using System.Data;

namespace TPA_Desktop_CC.Manager
{
    /// <summary>
    /// Interaction logic for ManagerCheckFireRequest.xaml
    /// </summary>
    public partial class ManagerCheckFireRequest : Window
    {
        Employee employee;
        ConnectDatabase connect;
        public ManagerCheckFireRequest(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            loaddata();
        }

        private void loaddata()
        {
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select employee.name as 'Name', employee.division as 'Division', fire.status as 'Firing Status' from employee, fire where employee.id = fire.employeeid and acceptedby = 'HRM'");
            if (dt.Rows.Count == 0)
            {
                datagrid.Visibility = Visibility.Hidden;
            }
            datagrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window a = new ManagerCheckRequest(employee);
            a.Show();
            this.Close();
        }
    }
}
