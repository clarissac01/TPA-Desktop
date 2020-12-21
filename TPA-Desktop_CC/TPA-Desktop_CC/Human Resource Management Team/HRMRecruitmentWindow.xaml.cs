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
    /// Interaction logic for HRMRecruitmentWindow.xaml
    /// </summary>
    public partial class HRMRecruitmentWindow : Window
    {
        Employee employee;
        ConnectDatabase connect;
        int tellercount = 4;
        int cscount = 4;
        int hrmcount = 4;
        int smcount = 4;
        int financecount = 4;
        int managercount = 1;
        List<string> lists = new List<string>();
        public HRMRecruitmentWindow(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            countposition();
        }

        private void countposition()
        {
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select division, count(id) as 'Current' from employee where status = 'Active' group by division");
            DataRow data;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = dt.Rows[i];
                if (data["division"].Equals("Teller"))
                {
                    tellercount = 4 - Int32.Parse(data["Current"].ToString());
                }
                else if (data["division"].Equals("Customer Service"))
                {
                    cscount = 4 - Int32.Parse(data["Current"].ToString());
                }
                else if (data["division"].Equals("Human Resource"))
                {
                    hrmcount = 4 - Int32.Parse(data["Current"].ToString());
                }
                else if (data["division"].Equals("Finance"))
                {
                    financecount = 4 - Int32.Parse(data["Current"].ToString());
                }
                else if (data["division"].Equals("Security & Maintenance"))
                {
                    smcount = 4 - Int32.Parse(data["Current"].ToString());
                }
                else
                {
                    managercount = 1 - Int32.Parse(data["Current"].ToString());
                }
            }
            if (tellercount > 0)
            {
                lists.Add("Teller");
            }
            if (cscount > 0)
            {
                lists.Add("Customer Service");
            }
            if (smcount > 0)
            {
                lists.Add("Security & Maintenance");
            }
            if (hrmcount > 0)
            {
                lists.Add("Human Resource");
            }
            if (financecount > 0)
            {
                lists.Add("Finance");
            }
            if (managercount > 0)
            {
                lists.Add("Manager");
            }
            combobox.ItemsSource = lists;
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            if (nametxt.Text.Equals(""))
            {
                MessageBox.Show("Name Must Not Be Empty!");
                return;
            }
            if (combobox.SelectedIndex == -1)
            {
                MessageBox.Show("Division Must Be Selected!");
                return;
            }
            DataTable datatable = new DataTable();
            datatable = connect.executeQuery("select * from candidate order by id desc");
            if (datatable.Rows.Count != 0)
            {
                DataRow datarow = datatable.Rows[0];
                connect.executeUpdate("insert into candidate values ('"+(Int32.Parse(datarow["id"].ToString())+1)+"','"+nametxt.Text+"','"+combobox.SelectedValue.ToString()+"')");
            }
            else
            {
                connect.executeUpdate("insert into candidate values ('"+(datatable.Rows.Count+1)+"','"+nametxt.Text+"','"+combobox.SelectedValue.ToString()+"')");
            }
            MessageBox.Show("Success!");
            Window a = new HRMRecruitment(employee);
            a.Show();
            this.Close();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window a = new HRMRecruitment(employee);
            a.Show();
            this.Close();
        }
    }
}
