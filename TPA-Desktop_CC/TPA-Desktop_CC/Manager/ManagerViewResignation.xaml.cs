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
    /// Interaction logic for ManagerViewResignation.xaml
    /// </summary>
    public partial class ManagerViewResignation : Window
    {
        Employee employee;
        ConnectDatabase connect;
        DataTable dt;
        DataTable dt2;
        public ManagerViewResignation(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            loaddata();
        }
        public void loaddata()
        {
            dt = new DataTable();
            dt2 = new DataTable();
            dt = connect.executeQuery("select employee.name as 'Name', division as 'Division', rating as 'Rating', (select sum(violationscore) from violation where employeeid = r.employeeid) as 'Violation Score' from resign r, employee where r.status = 'Pending' and r.employeeid = employee.id");
            dt2 = connect.executeQuery("select employee.id as 'id', employee.name as 'name', employee.password as 'password', employee.salary as 'salary', employee.rating as 'rating', employee.ratecount as 'ratecount' from resign, employee where resign.status = 'Pending' and resign.employeeid = employee.id");
            if(dt.Rows.Count == 0)
            {
                datagrid.Visibility = Visibility.Hidden;
            }
            datagrid.ItemsSource = dt.DefaultView;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window a = new ManagerHE(employee);
            a.Show();
            this.Close();
        }
        private void selectitem(object sender, SelectionChangedEventArgs e)
        {
            if (!datagrid.SelectedValue.Equals(""))
            {
                DataRow data = dt2.Rows[datagrid.SelectedIndex];
                Employee viewe = new Employee(data["id"].ToString(), data["name"].ToString(), data["password"].ToString(), Int32.Parse(data["salary"].ToString()), float.Parse(data["rating"].ToString()), Int32.Parse(data["ratecount"].ToString()));
                Window a = new Manager.ManagerAccResignationRequest(employee, viewe);
                a.Show();
                this.Close();
            }
        }
    }
}
