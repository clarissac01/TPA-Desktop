using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ManagerViewFireRequest.xaml
    /// </summary>
    public partial class ManagerViewFireRequest : Window
    {
        Employee employee;
        ConnectDatabase connect;
        DataTable dt;
        DataTable dt2;
        public ManagerViewFireRequest(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            datagrid.Visibility = Visibility.Hidden;
            loaddata();
        }
        public void loaddata()
        {
            dt = new DataTable();
            dt2 = new DataTable();
            dt = connect.executeQuery("select employee.name as 'Name', division as 'Division', rating as 'Rating', (select sum(violation.violationscore) from violation where employeeid = f.employeeid) as 'Violation Score' from fire f, employee where f.employeeid = employee.id and f.status = 'Pending' and f.acceptedby = 'Manager'");
            datagrid.ItemsSource = dt.DefaultView;
            dt2 = connect.executeQuery("select employee.id as 'id', employee.name as 'name', employee.password as 'password', employee.salary as 'salary', employee.rating as 'rating', employee.ratecount as 'ratecount' from fire, employee where fire.employeeid = employee.id and fire.status = 'Pending' and fire.acceptedby = 'Manager'");
            if (dt.Rows.Count == 0)
            {
                datagrid.Visibility = Visibility.Hidden;
            }
            else
            {
                datagrid.Visibility = Visibility.Visible;
            }
            datagrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new Manager.ManagerHE(employee);
            back.Show();
            this.Close();
        }

        private void selectitem(object sender, SelectionChangedEventArgs e)
        {
            DataRow data = dt2.Rows[datagrid.SelectedIndex];
            Employee viewe = new Employee(data["id"].ToString(), data["name"].ToString(), data["password"].ToString(), Int32.Parse(data["salary"].ToString()), float.Parse(data["rating"].ToString()), Int32.Parse(data["ratecount"].ToString()));
            Window a = new Manager.ManagerHandleEmployee(employee, viewe, "fire");
            a.Show();
            this.Close();
        }

    }
}
