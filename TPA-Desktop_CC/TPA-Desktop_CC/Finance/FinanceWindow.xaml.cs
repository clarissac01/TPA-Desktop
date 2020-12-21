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

namespace TPA_Desktop_CC.Finance
{
    /// <summary>
    /// Interaction logic for FinanceWindow.xaml
    /// </summary>
    public partial class FinanceWindow : Window
    {
        Employee employee;
        ConnectDatabase connect;
        List<string> lists = new List<string>();
        int notifcounts = 0;
        public FinanceWindow(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            hellotxt.Content = "Hello, " + emp.name;
            notifcircle.Visibility = Visibility.Hidden;
            notifcount.Visibility = Visibility.Hidden;
            listbox.Visibility = Visibility.Hidden;
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select * from financenotif");
            if (dt.Rows.Count > 0)
            {
                notifcount.Text = dt.Rows.Count.ToString();
                notifcount.Visibility = Visibility.Visible;
                notifcircle.Visibility = Visibility.Visible;
                notifcounts = dt.Rows.Count;
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow data = dt.Rows[i];
                    lists.Add(data["type"] + " from " + data["division"] + "\n" + data["amount"]);
                }
            }
            else
            {
                lists.Add("There is no notification currently!");
            }
            listbox.ItemsSource = lists;
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window a = new WindowLogin();
            a.Show();
            this.Close();
        }

        private void Notifbtn(object sender, RoutedEventArgs e)
        {
            if(listbox.Visibility == Visibility.Visible)
            {
                listbox.Visibility = Visibility.Hidden;
                if (notifcounts > 0)
                {
                    notifcounts = 0;
                    lists.Clear();
                    lists.Add("There is no notification currently!");
                    listbox.ItemsSource = lists;
                    connect.executeUpdate("delete from financenotif");
                    notifcount.Visibility = Visibility.Hidden;
                    notifcircle.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                listbox.Visibility = Visibility.Visible;
            }
        }
    }
}
