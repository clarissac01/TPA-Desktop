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
    /// Interaction logic for HRMAvailablePositions.xaml
    /// </summary>
    public partial class HRMAvailablePositions : Window
    {
        Employee employee;
        ConnectDatabase connect;
        public HRMAvailablePositions(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            tellercounttxt.Content = 4;
            cscounttxt.Content = 4;
            smcounttxt.Content = 4;
            financecounttxt.Content = 4;
            hrmcounttxt.Content = 4;
            managercounttxt.Content = 1;
            loaddata();
        }

        private void loaddata()
        {
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select division, count(id) as 'Current' from employee where status = 'Active' group by division");
            DataRow data;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                data = dt.Rows[i];
                if(data["division"].Equals("Customer Service"))
                {
                    cscounttxt.Content = 4 - Int32.Parse(data["Current"].ToString());
                }
                else if (data["division"].Equals("Teller"))
                {
                    tellercounttxt.Content = 4 - Int32.Parse(data["Current"].ToString());
                }else if(data["division"].Equals("Human Resource"))
                {
                    hrmcounttxt.Content = 4 - Int32.Parse(data["Current"].ToString());
                }else if (data["division"].Equals("Finance"))
                {
                    financecounttxt.Content = 4 - Int32.Parse(data["Current"].ToString());
                }else if(data["division"].Equals("Security & Maintenance"))
                {
                    smcounttxt.Content = 4 - Int32.Parse(data["Current"].ToString());
                }
                else
                {
                    managercounttxt.Content = 1 - Int32.Parse(data["Current"].ToString());
                }
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window a = new HRMRecruitment(employee);
            a.Show();
            this.Close();
        }

        private void insertemp(object sender, RoutedEventArgs e)
        {
            Window a = new HRMInsertEmployee(employee);
            a.Show();
            this.Close();
        }
    }
}
