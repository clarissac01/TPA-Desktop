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
    /// Interaction logic for HRMCandidateEmployee.xaml
    /// </summary>
    public partial class HRMCandidateEmployee : Window
    {
        Employee employee;
        ConnectDatabase connect;
        int tellercount = 4;
        int cscount = 4;
        int hrmcount = 4;
        int smcount = 4;
        int financecount = 4;
        int managercount = 1;
        List<string> candidateid = new List<string>();
        List<string> candidatedivision = new List<string>();
        List<string> candidatename = new List<string>();
        public HRMCandidateEmployee(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            deleteallbtn.Visibility = Visibility.Hidden;
            notxt.Visibility = Visibility.Hidden;
            datagrid.Visibility = Visibility.Hidden;
            countposition();
            loaddata();
        }

        private void countposition()
        {
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select division, count(id) as 'Current' from employee where status = 'Active' group by division");
            DataRow data;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = dt.Rows[i];
                if (data["division"].Equals("Customer Service"))
                {
                    cscount = 4 - Int32.Parse(data["Current"].ToString());
                }
                else if (data["division"].Equals("Teller"))
                {
                    tellercount = 4 - Int32.Parse(data["Current"].ToString());
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
            if(tellercount == 0 && smcount == 0 && managercount == 0 && financecount == 0 && cscount == 0 && hrmcount == 0)
            {
                addbtn.Visibility = Visibility.Hidden;
            }
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
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow data = dt.Rows[i];
                    candidateid.Add(data["ID"].ToString());
                    candidatedivision.Add(data["Division"].ToString());
                    candidatename.Add(data["Name"].ToString());
                }

                datagrid.Visibility = Visibility.Visible;
                deleteallbtn.Visibility = Visibility.Visible;
                datagrid.ItemsSource = dt.DefaultView;
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window a = new HRMRecruitment(employee);
            a.Show();
            this.Close();
        }

        private void addnew(object sender, RoutedEventArgs e)
        {
            Window a = new HRMRecruitmentWindow(employee);
            a.Show();
            this.Close();
        }

        private void deleteall(object sender, RoutedEventArgs e)
        {
            connect.executeUpdate("delete from candidate");
            MessageBox.Show("Success Delete All Candidate Employee!");
            Window a = new HRMRecruitment(employee);
            a.Show();
            this.Close();
        }

        private void selectitem(object sender, SelectionChangedEventArgs e)
        {
            Window a = new HRMCurrentEmployee(employee, candidateid.ElementAt(datagrid.SelectedIndex), candidatedivision.ElementAt(datagrid.SelectedIndex), candidatename.ElementAt(datagrid.SelectedIndex));
            a.Show();
            this.Close();
        }
    }
}
