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

namespace TPA_Desktop_CC.Human_Resource_Management_Team
{
    /// <summary>
    /// Interaction logic for HRMViolation.xaml
    /// </summary>
    public partial class HRMViolation : Window
    {
        Employee employee;
        Employee emp2;
        ConnectDatabase connect;
        public HRMViolation(Employee emp, Employee emp2)
        {
            this.employee = emp;
            this.emp2 = emp2;
            this.connect = ConnectDatabase.getInstance();
            InitializeComponent();
            List<string> lists = new List<string>();
            lists.Add("Small");
            lists.Add("Medium");
            lists.Add("High");
            combobox.ItemsSource = lists;
            employeename.Content = emp2.name;
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            if(nametxt.Text == "")
            {
                MessageBox.Show("You Must Input Violation Name!");
                return;
            }
            if(combobox.SelectedIndex == -1)
            {
                MessageBox.Show("You Must Select Violation Type!");
                return;
            }
            string violationtype = "";
            int violationscore = 0;
            if (combobox.SelectedIndex == 0)
            {
                violationtype = "Small";
                violationscore = 1;
            }else if(combobox.SelectedIndex == 1)
            {
                violationtype = "Medium";
                violationscore = 2;
            }
            else
            {
                violationtype = "High";
                violationscore = 3;
            }
            connect.executeUpdate("insert into violation values ('" + nametxt.Text.ToString() + "','" + violationtype + "'," + violationscore + ",'" + emp2.id + "')");
            MessageBox.Show("Done Insert Violation");
            Window a = new HRMWindow(employee);
            a.Show();
            this.Close();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window a = new HRMFireEmployee(employee, emp2);
            a.Show();
            this.Close();
        }
    }
}
