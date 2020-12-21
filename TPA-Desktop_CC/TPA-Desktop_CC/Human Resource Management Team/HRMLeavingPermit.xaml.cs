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

namespace TPA_Desktop_CC.Human_Resource_Management_Team
{
    /// <summary>
    /// Interaction logic for HRMLeavingPermit.xaml
    /// </summary>
    public partial class HRMLeavingPermit : Window
    {
        Employee employee;
        ConnectDatabase connect;
        DataTable dt;
        DataTable dt2;
        public HRMLeavingPermit(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            notxt.Visibility = Visibility.Hidden;
            datagrid.Visibility = Visibility.Hidden;
            loaddata();
        }
        public void loaddata()
        {
            dt = new DataTable();
            dt2 = new DataTable();
            dt = connect.executeQuery("select name as 'Name', division as 'Division', type as 'Leaving Type' from employee, leavingpermit where employee.id = leavingpermit.employeeid and leavingpermit.status = 'Pending'");
            if (dt.Rows.Count != 0)
            {
                datagrid.Visibility = Visibility.Visible;
            }
            else
            {
                notxt.Visibility = Visibility.Visible;
            }
            dt2 = connect.executeQuery("select employee.id as 'id' from employee, leavingpermit where employee.id = leavingpermit.employeeid and leavingpermit.status = 'Pending'");
            datagrid.ItemsSource = dt.DefaultView;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window a = new HRMHandleEmployee(employee);
            a.Show();
            this.Close();
        }

        private void selectitem(object sender, SelectionChangedEventArgs e)
        {
            if (!datagrid.SelectedValue.Equals(""))
            {
                DataRow data = dt2.Rows[datagrid.SelectedIndex];
                MessageBoxResult result = MessageBox.Show("Accept this request?", "Are you sure?", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MessageBox.Show("Success!");
                        connect.executeUpdate("update leavingpermit set status ='Accepted' where employeeid ='"+data["id"].ToString()+"'");
                        Window a = new HRMHandleEmployee(employee);
                        a.Show();
                        this.Close();
                        break;
                    case MessageBoxResult.No:
                        MessageBox.Show("Done!");
                        connect.executeUpdate("update leavingpermit set status ='Rejected' where employeeid ='"+data["id"].ToString()+"'");
                        Window b = new HRMHandleEmployee(employee);
                        b.Show();
                        this.Close();
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
        }

    }
}
