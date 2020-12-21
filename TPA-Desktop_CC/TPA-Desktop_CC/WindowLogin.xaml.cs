using MySql.Data.MySqlClient;
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

namespace TPA_Desktop_CC
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        private ConnectDatabase connect;
        public WindowLogin()
        {
            this.connect = ConnectDatabase.getInstance();
            InitializeComponent();
            connect.executeUpdate("update deposit set enddate = (enddate + time) where (enddate - current_date) = 0 and aro = 0");
            connect.executeUpdate("update virtualaccount set status = 'Expired' where (enddate - current_date) < 0 and status = 'Not Paid'");
            connect.executeUpdate("delete from virtualaccount where status = 'Paid'");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(username.Text == "")
            {
                MessageBox.Show("USERNAME MUST NOT BE EMPTY!");
                return;
            }
            if(password.Password == "")
            {
                MessageBox.Show("PASSWORD MUST NOT BE EMPTY!");
                return;
            }

            string id = username.Text;
            string pass = password.Password;

            
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select * from employee where id = '"+id+ "' and password = '" + pass + "' and status = 'Active' limit 1");

            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid Username/Password!");
                return;
            }
            else
            {
                DataRow data = dt.Rows[0];
                Employee emp = new Employee(data["id"].ToString(), data["name"].ToString(), data["password"].ToString(), Int32.Parse(data["salary"].ToString()), float.Parse(data["rating"].ToString()), Int32.Parse(data["ratecount"].ToString()));
                MessageBox.Show("Success!");
                if (id[0] == 'T')
                {
                    Window tellerwindow = new TellerWindow(emp);
                    tellerwindow.Show();
                    this.Close();
                }
                else if(id[0] == 'C')
                {
                    Window cswindow = new CustomerService.CSWindow(emp);
                    cswindow.Show();
                    this.Close();
                }else if (id[0] == 'S')
                {
                    Window swindow = new Security_and_Maintenance_Team.SMWindow(emp);
                    swindow.Show();
                    this.Close();
                }else if (id[0] == 'M')
                {
                    Window mwindow = new Manager.ManagerWindow(emp);
                    mwindow.Show();
                    this.Close();
                }else if (id[0] == 'H')
                {
                    Window hwindow = new Human_Resource_Management_Team.HRMWindow(emp);
                    hwindow.Show();
                    this.Close();
                }else if (id[0] == 'F')
                {
                    Window fwindow = new Finance.FinanceWindow(emp);
                    fwindow.Show();
                    this.Close();
                }
            }

        }

        private void others_Click(object sender, RoutedEventArgs e)
        {
            Window others = new Others();
            others.Show();
            this.Close();
        }
    }
}
