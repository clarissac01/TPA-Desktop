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
    /// Interaction logic for CSBusinessAcc.xaml
    /// </summary>
    public partial class CSBusinessAcc : Window
    {
        ConnectDatabase connect;
        Employee employee;
        List<string> lists = new List<string>();
        public CSBusinessAcc(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            lists.Add("Business");
            lists.Add("Petty");
            lists.Add("Deposit");
            lists.Add("Reward");
            combobox.ItemsSource = lists;
            combobox.SelectedIndex = 0;
            limitlabel.Visibility = Visibility.Hidden;
            limittxt.Visibility = Visibility.Hidden;
        }

        private void backbtn(object sender, RoutedEventArgs e)
        {
            new CSChooseAccount(employee).Show();
            this.Close();
        }

        private void nextbtn(object sender, RoutedEventArgs e)
        {
            if (idcardtxt.Text == "")
            {
                MessageBox.Show("Identity Card must not be empty!");
                idcardtxt.Text = "";
                return;
            }
            if (combobox.SelectedIndex == -1)
            {
                MessageBox.Show("Account Type must be chosed!");
                idcardtxt.Text = "";
                return;
            }
            if (amountxt.Text == "")
            {
                MessageBox.Show("Amount must be inputted!");
                idcardtxt.Text = "";
                return;
            }
            if(combobox.SelectedIndex==3 && limittxt.Text == "")
            {
                MessageBox.Show("Limit must be inputted!");
                return;
            }
            else if(combobox.SelectedIndex == 3 && limittxt.Text != "")
            {
                if(long.Parse(limittxt.Text.ToString()) > 100000000)
                {
                    MessageBox.Show("You have reached the limit of reward card!");
                    return;
                }
            }
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            dt = connect.executeQuery("select * from customer where accountnumber = '"+idcardtxt.Text.ToString()+"'");
            dt2 = connect.executeQuery("select * from customer where year(current_date) - year(membersince) >= 2 and accountnumber = '"+idcardtxt.Text.ToString()+"'");
            dt3 = connect.executeQuery("SELECT count(*)/(select ( (CURRENT_DATE-membersince) / 30) from customer where accountnumber = '"+ idcardtxt.Text.ToString() + "') as average FROM deposit where accountnumber = '" + idcardtxt.Text.ToString()+"'");
            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("This user is not registered in this bank!");
                return;
            }
            if (dt2.Rows.Count == 0)
            {
                MessageBox.Show("This user must have a couple years of using their individual account!");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("This user did not do any transaction!");
                return;
            }
            else
            {
                //DataRow dtrow = dt3.Rows[0];
                //if (Int32.Parse(dtrow["average"].ToString()) < 10)
                //{
                //    MessageBox.Show("This user did not reach the target of minimum 10 transactions per month!");
                //    return;
                //}
            }
            DataRow data = dt.Rows[0];
            string id = data["accountnumber"].ToString();
            if(long.Parse(data["balance"].ToString()) < 50000000)
            {
                MessageBox.Show("This user balance did not contain at least 50000000 in the last 6 months!");
                return;
            }
            long limit = 0;
            if (combobox.SelectedIndex == 0)
            {
                limit = 100000000;
                id += "B";
            }else if (combobox.SelectedIndex == 1)
            {
                limit = 10000000;
                id += "P";
            }else if (combobox.SelectedIndex == 2)
            {
                limit = 0;
                id += "D";
            }
            else
            {
                limit = Int32.Parse(limittxt.Text.ToString());
                id += "R";
            }
            connect.executeUpdate("insert into businesscard values ('" + id + "','" + combobox.SelectedValue + "', '" + data["accountnumber"].ToString() + "'," + amountxt.Text + ", " + limit + ")");
            MessageBox.Show("Success!");
            new CSWindow(employee).Show();
            this.Close();
        }

        private void OnMyComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combobox.SelectedIndex == 3)
            {
                limitlabel.Visibility = Visibility.Visible;
                limittxt.Visibility = Visibility.Visible;
            }
            else
            {
                limitlabel.Visibility = Visibility.Hidden;
                limittxt.Visibility = Visibility.Hidden;
            }
        }

    }
}
