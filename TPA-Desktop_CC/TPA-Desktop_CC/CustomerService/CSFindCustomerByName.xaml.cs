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
    /// Interaction logic for CSFindCustomerByName.xaml
    /// </summary>
    public partial class CSFindCustomerByName : Window
    {
        Employee employee;
        DataRow data;
        List<string> listnames = new List<string>();
        DataTable dt;
        ConnectDatabase connect;
        public CSFindCustomerByName(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            listbox.Visibility = Visibility.Hidden;
            nextbutton.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new CSFindCustomer(employee);
            back.Show();
            this.Close();
        }

        private void tonextwindow(object sender, RoutedEventArgs e)
        {
            Customer cust = new Customer(data["accountnumber"].ToString(), data["pin"].ToString(), data["name"].ToString(), data["identitycard"].ToString(), data["familycard"].ToString(), Int32.Parse(data["balance"].ToString()), data["type"].ToString());
            Window next = new CSCheckTransaction(employee, cust);
            next.Show();
            this.Close();
        }

        private void searchButton(object sender, RoutedEventArgs e)
        {
            listnames.Clear();
            listbox.ItemsSource = "";

            string name = nametxt.Text;

            dt = new DataTable();
            dt = connect.executeQuery("select * from customer where name like '"+name+"%'");

            if (dt.Rows.Count == 0)
            {
                listbox.Visibility = Visibility.Hidden;
                label.Content = "Invalid Name!";
                return;
            }
            else
            {
                label.Content = "";
                int size = dt.Rows.Count;
                for (int i = 0; i < size; i++)
                {
                    data = dt.Rows[i];
                    listnames.Add(data["name"].ToString());
                }

                listbox.ItemsSource = listnames;
                listbox.Visibility = Visibility.Visible;
            }
        }

        private void selectfromlistbox(object sender, MouseButtonEventArgs e)
        {
            data = dt.Rows[listbox.SelectedIndex];
            nametxt.Text = data["name"].ToString();
            nextbutton.Visibility = Visibility.Visible;
        }

    }
}
