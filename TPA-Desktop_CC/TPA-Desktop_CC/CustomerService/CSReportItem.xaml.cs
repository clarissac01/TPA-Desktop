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
    /// Interaction logic for CSReportItem.xaml
    /// </summary>
    public partial class CSReportItem : Window
    {
        Employee employee;
        ConnectDatabase connect;
        public CSReportItem(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            string itemid = itemtxt.Text;

            DataTable dt = new DataTable();
            dt = connect.executeQuery("select * from item where employee = '" + employee.id + "' and itemid = '" + itemid + "' limit 1");

            if (dt.Rows.Count == 0)
            {
                label.Content = "Invalid item!";
                return;
            }
            else
            {
                DataRow data;
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

                    connect.executeUpdate("insert into schedule values ('" + itemid + "', 'Teller " + data["itemname"].ToString() + "', CURRENT_DATE + (SELECT((COUNT(*) + 1) / 3) + 1 from item where itemstatus = 'Broken'),'Not Fixed')");

                    connect.executeUpdate("update item set itemstatus = 'Broken' where itemid = '" + itemid + "'");

                    Window back = new CSWindow(employee);
                    back.Show();
                    this.Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new CSOthers(employee);
            back.Show();
            this.Close();
        }
    }
}
