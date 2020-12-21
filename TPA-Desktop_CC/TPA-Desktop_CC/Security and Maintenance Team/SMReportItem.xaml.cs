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

namespace TPA_Desktop_CC.Security_and_Maintenance_Team
{
    /// <summary>
    /// Interaction logic for SMReportItem.xaml
    /// </summary>
    public partial class SMReportItem : Window
    {
        Employee employee;
        DataTable dt;
        DataRow data;
        ConnectDatabase connect;
        public SMReportItem(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new SMWindow(employee);
            back.Show();
            this.Close();
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            string itemid = itemtxt.Text;

            dt = new DataTable();
            dt = connect.executeQuery("select * from item where itemid = '"+itemid+"' limit 1");

            if (dt.Rows.Count == 0)
            {
                label.Content = "Invalid item!";
                return;
            }
            else
            {
                data = dt.Rows[0];
                string emp = data["employee"].ToString();
                if (data["itemstatus"].ToString() == "Broken")
                {
                    label.Content = "Item is already reported!";
                    return;
                }
                else
                {
                    MessageBox.Show("Success Reporting Item");

                    if (emp[0] == 'T')
                    {
                        connect.executeUpdate("insert into schedule values ('"+itemid+"', 'Teller "+ data["itemname"].ToString() + "', CURRENT_DATE + (SELECT((COUNT(*) + 1) / 3) + 1 from item where itemstatus = 'Broken'),'Not Fixed')");
                    }
                    else
                    {
                        connect.executeUpdate("insert into schedule values ('"+itemid+ "', '" + data["itemname"].ToString() + "', CURRENT_DATE + (SELECT((COUNT(*) + 1) / 3) + 1 from item where itemstatus = 'Broken'),'Not Fixed')");
                    }

                    connect.executeUpdate("update item set itemstatus = 'Broken' where itemid = '"+itemid+"'");

                    Window back = new SMWindow(employee);
                    back.Show();
                    this.Close();
                }
            }
        }
    }
}
