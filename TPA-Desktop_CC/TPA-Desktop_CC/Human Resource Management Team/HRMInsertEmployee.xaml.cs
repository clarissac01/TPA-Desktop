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
    /// Interaction logic for HRMInsertEmployee.xaml
    /// </summary>
    public partial class HRMInsertEmployee : Window
    {
        Employee employee;
        ConnectDatabase connect;
        List<string> candidateid = new List<string>();
        List<string> candidatedivision = new List<string>();
        List<string> candidatename = new List<string>();
        public HRMInsertEmployee(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            notxt.Visibility = Visibility.Hidden;
            datagrid.Visibility = Visibility.Hidden;
            loaddata();
        }

        private void loaddata()
        {
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select id as 'ID', name as 'Name', division as 'Division' from candidate");
            if (dt.Rows.Count == 0)
            {
                notxt.Visibility = Visibility.Visible;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow data = dt.Rows[i];
                    candidateid.Add(data["ID"].ToString());
                    candidatedivision.Add(data["Division"].ToString());
                    candidatename.Add(data["Name"].ToString());
                }

                datagrid.Visibility = Visibility.Visible;
                datagrid.ItemsSource = dt.DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window a = new HRMRecruitment(employee);
            a.Show();
            this.Close();
        }

        private void selectitem(object sender, SelectionChangedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Recruit This Employee?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Employee Recruited!");
                    DataTable dt5 = new DataTable();
                    dt5 = connect.executeQuery("select * from employee where division = '" + candidatedivision.ElementAt(datagrid.SelectedIndex).ToString() + "'");
                    if (candidatedivision.ElementAt(datagrid.SelectedIndex).Equals("Teller"))
                    {
                        connect.executeUpdate("insert into employee values ('T00"+(dt5.Rows.Count+1)+"','"+candidatename.ElementAt(datagrid.SelectedIndex)+"','Teller','password',4000000,0,0,'Active')");
                    }
                    else if (candidatedivision.ElementAt(datagrid.SelectedIndex).Equals("Customer Service"))
                    {
                        connect.executeUpdate("insert into employee values ('CS00" + (dt5.Rows.Count + 1) + "','" + candidatename.ElementAt(datagrid.SelectedIndex) + "','Customer Service','password',5000000,0,0,'Active')");
                    }
                    else if (candidatedivision.ElementAt(datagrid.SelectedIndex).Equals("Human Resource"))
                    {
                        connect.executeUpdate("insert into employee values ('HRM00" + (dt5.Rows.Count + 1) + "','" + candidatename.ElementAt(datagrid.SelectedIndex) + "','Human Resource','password',6000000,0,0,'Active')");
                    }
                    else if (candidatedivision.ElementAt(datagrid.SelectedIndex).Equals("Security & Maintenance"))
                    {
                        connect.executeUpdate("insert into employee values ('SM00" + (dt5.Rows.Count + 1) + "','" + candidatename.ElementAt(datagrid.SelectedIndex) + "','Security & Maintenance','password',5500000,0,0,'Active')");
                    }
                    else if (candidatedivision.ElementAt(datagrid.SelectedIndex).Equals("Finance"))
                    {
                        connect.executeUpdate("insert into employee values ('F00" + (dt5.Rows.Count + 1) + "','" + candidatename.ElementAt(datagrid.SelectedIndex) + "','Finance','password',5000000,0,0,'Active')");
                    }
                    else if (candidatedivision.ElementAt(datagrid.SelectedIndex).Equals("Manager"))
                    {
                        connect.executeUpdate("insert into employee values ('M00" + (dt5.Rows.Count + 1) + "','" + candidatename.ElementAt(datagrid.SelectedIndex) + "','Manager','password',20000000,0,0,'Active')");
                    }
                    connect.executeUpdate("delete from candidate where id = '" + candidateid.ElementAt(datagrid.SelectedIndex) + "'");
                    Window a = new HRMManageEmployee(employee);
                    a.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
            
        }

    }
}
