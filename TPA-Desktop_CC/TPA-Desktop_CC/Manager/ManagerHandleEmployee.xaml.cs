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
    /// Interaction logic for ManagerHandleEmployee.xaml
    /// </summary>
    public partial class ManagerHandleEmployee : Window
    {
        Employee employee;
        Employee view;
        ConnectDatabase connect;
        DataTable dt;
        int score = 0;
        string action;
        public ManagerHandleEmployee(Employee emp, Employee view, string action)
        {
            this.action = action;
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            this.view = view;
            InitializeComponent();
            employeename.Content = view.name;
            datagrid.Visibility = Visibility.Hidden;
            notxt.Visibility = Visibility.Hidden;
            scoretxt.Visibility = Visibility.Hidden;
            loaddata();
        }

        public void loaddata()
        {
            dt = new DataTable();
            dt = connect.executeQuery("select name as 'Violation Name', violationtype as 'Violation Type', violationscore as 'Violation Score' from violation where employeeid = '" + view.id + "'");
            if(dt.Rows.Count == 0)
            {
                notxt.Visibility = Visibility.Visible;
                datagrid.Visibility = Visibility.Hidden;
            }
            else
            {
                datagrid.Visibility = Visibility.Visible;
                datagrid.ItemsSource = dt.DefaultView;
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow data = dt.Rows[i];
                    score += Int32.Parse( data["Violation Score"].ToString());
                    scoretxt.Content = score;
                    scoretxt.Visibility = Visibility.Visible;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window a = new Manager.ManagerHE(employee);
            a.Show();
            this.Close();
        }

        private void fire(object sender, RoutedEventArgs e)
        {
            if (action.Equals("request"))
            {
                DataTable dt3 = new DataTable();
                dt3 = connect.executeQuery("select * from fire where employeeid = '" + view.id + "' and acceptedby = 'Manager'");
                if (dt3.Rows.Count == 0)
                {
                    connect.executeUpdate("insert into fire values ('"+view.id+"', 'Pending', 'HRM')");
                }
                else
                {
                    DataTable dt4 = new DataTable();
                    dt4 = connect.executeQuery("select * from fire where employeeid = '" + view.id + "' and status = 'Accepted' and acceptedby = 'Manager'");
                    if (dt4.Rows.Count == 0)
                    {
                        connect.executeUpdate("update fire set status ='Accepted' where employeeid = '" + view.id + "' and acceptedby = 'Manager'");
                        connect.executeUpdate("update employee set status = 'Inactive' where id = '" + view.id + "'");
                        MessageBox.Show("Done Firing!");
                        Window b = new ManagerWindow(employee);
                        b.Show();
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("You have accepted this fire request!");
                        Window b = new ManagerWindow(employee);
                        b.Show();
                        this.Close();
                        return;
                    }
                }
            }
            else
            {
                connect.executeQuery("update fire set status ='Accepted' where employeeid = '" + view.id + "' and acceptedby = 'Manager'");
                connect.executeQuery("update employee set status ='Inactive' where id = '" + view.id + "'");
            }
            MessageBox.Show("Done!");
            Window a = new ManagerWindow(employee);
            a.Show();
            this.Close();
        }
    }
}
