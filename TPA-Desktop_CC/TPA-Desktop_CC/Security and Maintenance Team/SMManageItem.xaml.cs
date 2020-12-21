using MySql.Data.MySqlClient;
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

namespace TPA_Desktop_CC.Security_and_Maintenance_Team
{
    /// <summary>
    /// Interaction logic for SMManageItem.xaml
    /// </summary>
    public partial class SMManageItem : Window
    {
        Employee employee;
        Item item;
        ConnectDatabase connect;
        public SMManageItem(Employee emp, Item item)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            this.item = item;
            InitializeComponent();
            itemnametxt.Content = item.itemname;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int cost = Int32.Parse(costtxt.Text);
            if (cost < 0)
            {
                MessageBox.Show("Invalid Cost!");
                return;
            }
            else
            {
                connect.executeUpdate("insert into banktransaction values ('"+item.itemid+"', 'Repair Cost', "+cost+",'Security & Maintenance Team', current_Date)");
                connect.executeQuery("insert into financenotif values ('Security & Maintenance', '" + employee.id + "', 'Repair Cost'," + Int32.Parse(costtxt.Text.ToString()) + ")");
                connect.executeUpdate("update item set itemstatus = 'OK' where itemid = '"+item.itemid+"'");

                connect.executeUpdate("delete from schedule where itemid = '" + item.itemid + "'");
                
                MessageBox.Show("Success!");
                Window main = new SMWindow(employee);
                main.Show();
                this.Close();
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window a = new SMHandleItems(employee);
            a.Show();
            this.Close();
        }
    }
}
