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
    /// Interaction logic for ManagerAccResignationRequest.xaml
    /// </summary>
    public partial class ManagerAccResignationRequest : Window
    {
        Employee employee, rcv;
        ConnectDatabase connect;
        DataTable dt;
        public ManagerAccResignationRequest(Employee emp, Employee rcv)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            this.rcv = rcv;
            InitializeComponent();
            employeename.Content = rcv.name;
            DataTable dt2 = connect.executeQuery("select resignationletter from resign where employeeid = '" + rcv.id + "'");
            DataRow dr = dt2.Rows[0];
            lettertxt.Content = dr["resignationletter"].ToString();
            loaddata();
        }
        public void loaddata()
        {
            dt = new DataTable();
            dt = connect.executeQuery("select rating as 'Rating', (select sum(violationscore) from violation where employeeid = r.employeeid) as 'Violation Score' from  resign r, employee where status = 'Pending' and r.employeeid = employee.id and id = '" + rcv.id+"'");
            
            datagrid.Visibility = Visibility.Visible;
            datagrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window a = new Manager.ManagerHE(employee);
            a.Show();
            this.Close();
        }

        private void accept(object sender, RoutedEventArgs e)
        {
            connect.executeUpdate("update resign set status ='Accepted' where employeeid = '" + rcv.id + "'");
            MessageBox.Show("Done!");
            Window a = new Manager.ManagerWindow(employee);
            a.Show();
            this.Close();
        }
    }
}
