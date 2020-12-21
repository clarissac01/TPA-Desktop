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

namespace TPA_Desktop_CC.CustomerService
{
    /// <summary>
    /// Interaction logic for CSIndividualAcc.xaml
    /// </summary>
    public partial class CSIndividualAcc : Window
    {
        Employee employee;
        ConnectDatabase connect;
        List<string> lists = new List<string>();
        public CSIndividualAcc(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            dobpicker.DisplayDateEnd = DateTime.Now;
            lists.Add("Bronze");
            lists.Add("Silver");
            lists.Add("Gold");
            lists.Add("Black");
            lists.Add("Student");
            combobox.ItemsSource = lists;
        }

        private void backbtn(object sender, RoutedEventArgs e)
        {
            Window a = new CSChooseAccount(employee);
            a.Show();
            this.Close();
        }

        private void nextbtn(object sender, RoutedEventArgs e)
        {
            if(idcardtxt.Text == "")
            {
                MessageBox.Show("Identity Card must not be empty!");
                idcardtxt.Text = "";
                nametxt.Text = "";
                fcardtxt.Text = "";
                dobpicker.SelectedDate = new DateTime(2001, 08, 26);
                return;
            }
            if(fcardtxt.Text == "")
            {
                MessageBox.Show("Family Card must not be empty!");
                idcardtxt.Text = "";
                nametxt.Text = "";
                fcardtxt.Text = "";
                dobpicker.SelectedDate = new DateTime(2001, 08, 26);
                return;
            }
            if(nametxt.Text == "")
            {
                MessageBox.Show("Name must not be empty!");
                idcardtxt.Text = "";
                nametxt.Text = "";
                fcardtxt.Text = "";
                dobpicker.SelectedDate = new DateTime(2001, 08, 26);
                return;
            }
            if(combobox.SelectedIndex == -1)
            {
                MessageBox.Show("Combo Box must be chosen!");
                idcardtxt.Text = "";
                nametxt.Text = "";
                fcardtxt.Text = "";
                dobpicker.SelectedDate = new DateTime(2001, 08, 26);
                return;
            }
            if(amountxt.Text == "")
            {
                MessageBox.Show("Amount must be inputted!");
                idcardtxt.Text = "";
                nametxt.Text = "";
                fcardtxt.Text = "";
                dobpicker.SelectedDate = new DateTime(2001, 08, 26);
                return;
            }
            if (DateTime.Now.Year - DateTime.Parse(dobpicker.SelectedDate.Value.ToString()).Year > 15)
            {
                if(combobox.SelectedValue.ToString() == "Student")
                {
                    MessageBox.Show("You cannot make student acc!");
                    return;
                }
            }
            if(combobox.SelectedValue.ToString() != "Student")
            {
                if (Int32.Parse(amountxt.Text.ToString()) < 50000)
                {
                    MessageBox.Show("Minimal amount of bronze account is 50000!");
                    return;
                }
            }
            else if (combobox.SelectedValue.ToString() == "Student")
            {
                if (Int32.Parse(amountxt.Text.ToString()) < 5000)
                {
                    MessageBox.Show("Minimal amount of bronze account is 5000!");
                    return;
                }
            }
            
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select * from customer where identitycard = '" + idcardtxt.Text.ToString() + "'");
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("User has already registered!");
                idcardtxt.Text = "";
                nametxt.Text = "";
                fcardtxt.Text = "";
                dobpicker.SelectedDate = new DateTime(2001, 08, 26);
                return;
            }
            DataTable dt2 = new DataTable();
            dt2 = connect.executeQuery("select * from customer where familycard = '" + fcardtxt.Text.ToString() + "' and age > 15");
            if (dt2.Rows.Count == 0)
            {
                MessageBox.Show("User must have a guardian registered in this bank!");
                return;
            }
            connect.executeUpdate("insert into customer values ('(select cast(accountnumber as int) + 1 from customer order by accountnumber desc limit 1)', " +
                "'" + combobox.SelectedValue.ToString() + "','123456','" + nametxt.Text.ToString() + ",'" + 
                idcardtxt.Text.ToString() + "','"+fcardtxt.Text.ToString()+"', "+ (DateTime.Now.Year - DateTime.Parse(dobpicker.SelectedDate.Value.ToString()).Year) + 
                ","+amountxt.Text+", current_date )");
            MessageBox.Show("Success!");
            Window a = new CSWindow(employee);
            a.Show();
            this.Close();
        }
    }
}
