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

namespace TPA_Desktop_CC.CustomerService
{
    /// <summary>
    /// Interaction logic for CSFindCustomerByAccountNum.xaml
    /// </summary>
    public partial class CSFindCustomerByAccountNum : Window
    {
        Employee employee;
        DataTable dt;
        DataRow data;
        List<string> listaccnumbers = new List<string>();
        ConnectDatabase connect;
        public CSFindCustomerByAccountNum(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            nextbutton.Visibility = Visibility.Hidden;
            listbox.Visibility = Visibility.Hidden;
        }

        private void tonextwindow(object sender, RoutedEventArgs e)
        {
            Customer cust = new Customer(data["accountnumber"].ToString(), data["pin"].ToString(), data["name"].ToString(), data["identitycard"].ToString(), data["familycard"].ToString(), Int32.Parse(data["balance"].ToString()), data["type"].ToString());
            Window next = new CSCheckTransaction(employee, cust);
            next.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new CSFindCustomer(employee);
            back.Show();
            this.Close();
        }

        private void searchButton(object sender, RoutedEventArgs e)
        {
            listaccnumbers.Clear();
            listbox.ItemsSource = "";
            string accnum = accnumtxt.Text;

            dt = new DataTable();
            dt = connect.executeQuery("select * from customer where accountnumber like '"+accnum+"%'");
            if (dt.Rows.Count == 0)
            {
                listbox.Visibility = Visibility.Hidden;
                label.Content = "Invalid Account Number!";
                return;
            }
            else
            {
                label.Content = "";
                int size = dt.Rows.Count;
                for (int i = 0; i < size; i++)
                {
                    data = dt.Rows[i];
                    listaccnumbers.Add(data["accountnumber"].ToString());
                }

                listbox.ItemsSource = listaccnumbers;
                listbox.Visibility = Visibility.Visible;
            }
        }

        private void selectfromlistbox(object sender, MouseButtonEventArgs e)
        {
            data = dt.Rows[listbox.SelectedIndex];
            accnumtxt.Text = data["accountnumber"].ToString();
            nextbutton.Visibility = Visibility.Visible;
        }

    }
}
