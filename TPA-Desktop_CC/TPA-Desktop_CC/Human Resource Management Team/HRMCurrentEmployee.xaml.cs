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
    /// Interaction logic for HRMCurrentEmployee.xaml
    /// </summary>
    public partial class HRMCurrentEmployee : Window
    {
        Employee employee;
        string id = "";
        string division = "";
        ConnectDatabase connect;
        int tellercount = 4;
        int cscount = 4;
        int hrmcount = 4;
        int smcount = 4;
        int financecount = 4;
        int managercount = 1;
        List<string> lists = new List<string>();
        public HRMCurrentEmployee(Employee emp, string id, string division, string name)
        {
            this.employee = emp;
            this.id = id;
            this.division = division;
            this.connect = ConnectDatabase.getInstance();
            InitializeComponent();
            countposition();
            combobox.SelectedValue = division;
            cenametxt.Content = name;
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

        private void update(object sender, RoutedEventArgs e)
        {
            if (combobox.SelectedValue.Equals(division))
            {
                MessageBox.Show("You cannot update to the same division!");
                return;
            }
            else
            {
                connect.executeUpdate("update candidate set division = '"+combobox.SelectedValue+"' where id = '"+id+"'");
                MessageBox.Show("Success Update Division!");
                Window back = new HRMCandidateEmployee(employee);
                back.Show();
                this.Close();
            }
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            connect.executeUpdate("delete from candidate where id = '"+id+"'");
            MessageBox.Show("Success Deleting Candidate Employee!");
            Window back = new HRMCandidateEmployee(employee);
            back.Show();
            this.Close();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window back = new HRMCandidateEmployee(employee);
            back.Show();
            this.Close();
        }

    }
}
