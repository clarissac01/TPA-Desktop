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
    /// Interaction logic for ManagerHandleFiring.xaml
    /// </summary>
    public partial class ManagerHandleFiring : Window
    {
        Employee employee;
        ConnectDatabase connect;
        DataTable dt;
        DataTable dt2;
        public ManagerHandleFiring(Employee emp)
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
            dt = connect.executeQuery("select name as 'Name', division as 'Division', salary as 'Salary', rating as 'Rating' from employee where id not in ('M001') and employee.status = 'Active'");
            dt2 = connect.executeQuery("select * from employee where id not in ('M001') and employee.status = 'Active'");
            datagrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window a = new Manager.ManagerHE(employee);
            a.Show();
            this.Close();
        }

        private void selectitem(object sender, SelectionChangedEventArgs e)
        {
            if (!datagrid.SelectedValue.Equals(""))
            {
                DataRow data = dt2.Rows[datagrid.SelectedIndex];
                Employee viewe = new Employee(data["id"].ToString(), data["name"].ToString(), data["password"].ToString(), Int32.Parse(data["salary"].ToString()), float.Parse(data["rating"].ToString()), Int32.Parse(data["ratecount"].ToString()));
                Window a = new Manager.ManagerHandleEmployee(employee, viewe, "request");
                a.Show();
                this.Close();
            }
        }
    }
}
