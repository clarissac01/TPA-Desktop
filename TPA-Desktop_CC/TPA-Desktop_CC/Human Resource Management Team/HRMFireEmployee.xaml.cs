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

namespace TPA_Desktop_CC.Human_Resource_Management_Team
{
    /// <summary>
    /// Interaction logic for HRMFireEmployee.xaml
    /// </summary>
    public partial class HRMFireEmployee : Window
    {
        Employee employee;
        Employee emp2;
        ConnectDatabase connect;
        DataTable dt;
        int score = 0;
        public HRMFireEmployee(Employee emp, Employee emp2)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            this.emp2 = emp2;
            InitializeComponent();
            employeename.Content = emp2.name;
            datagrid.Visibility = Visibility.Hidden;
            notxt.Visibility = Visibility.Hidden;
            scoretxt.Visibility = Visibility.Hidden;
            loaddata();
        }

        public void loaddata()
        {
            dt = new DataTable();
            dt = connect.executeQuery("select name as 'Violation Name', violationtype as 'Violation Type', violationscore as 'Violation Score' from violation where employeeid = '" + emp2.id + "'");
            if (dt.Rows.Count == 0)
            {
                notxt.Visibility = Visibility.Visible;
                datagrid.Visibility = Visibility.Hidden;
            }
            else
            {
                datagrid.Visibility = Visibility.Visible;
                datagrid.ItemsSource = dt.DefaultView;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow data = dt.Rows[i];
                    score += Int32.Parse(data["Violation Score"].ToString());
                    scoretxt.Content = score;
                    scoretxt.Visibility = Visibility.Visible;
                }
            }
        }

        private void fire(object sender, RoutedEventArgs e)
        {
                DataTable dt3 = new DataTable();
                dt3 = connect.executeQuery("select * from fire where employeeid = '" + emp2.id + "'");
                if (dt3.Rows.Count == 0)
                {
                    connect.executeUpdate("insert into fire values ('" + emp2.id + "', 'Pending', 'Manager')");
                }
                else
                {
                    DataTable dt4 = new DataTable();
                    dt4 = connect.executeQuery("select * from fire where employeeid = '" + emp2.id + "' and status = 'Pending' and acceptedby = 'HRM'");
                    if (dt4.Rows.Count != 0)
                    {
                        connect.executeQuery("update fire set status ='Accepted' where employeeid = '" + emp2.id + "' and acceptedby = 'HRM'");
                        connect.executeQuery("update employee set status = 'Inactive' where id = '" + emp2.id + "'");
                    }
                    else
                    {
                        MessageBox.Show("Waiting for Manager Approval!");
                        return;
                    }
                    MessageBox.Show("Done Accepted Fire Request!");
                    Window b = new HRMWindow(employee);
                    b.Show();
                    this.Close();
                    return;
                }
            MessageBox.Show("Success Firing Request!");
            Window a = new HRMWindow(employee);
            a.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window a = new HRMViewEmployee(employee);
            a.Show();
            this.Close();
        }

        private void insertviolation(object sender, RoutedEventArgs e)
        {
            Window a = new HRMViolation(employee, emp2);
            a.Show();
            this.Close();
        }
    }
}
