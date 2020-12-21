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
    /// Interaction logic for SMViewSchedule.xaml
    /// </summary>
    public partial class SMViewSchedule : Window
    {
        Employee employee;
        List<string> itemsnote = new List<string>();
        DataTable dt;
        DataRow data;
        ConnectDatabase connect;
        public SMViewSchedule(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            initlistview();
        }

        void initlistview()
        {
            itemsnote.Clear();
            listbox.ItemsSource = "";
            
            dt = new DataTable();
            dt = connect.executeQuery("select * from schedule");

            if (dt.Rows.Count == 0)
            {
                itemsnote.Add("There is nothing on the list!");
                return;
            }
            else
            {

                DataTable datatable = new DataTable();
                datatable = connect.executeQuery("select * from schedule where schedule <= current_date");
                if(datatable.Rows.Count != 0)
                {
                    connect.executeUpdate("update schedule set schedule = schedule + 1");
                }

                int size = dt.Rows.Count;
                
                for (int i = 0; i < size; i++)
                {
                    data = dt.Rows[i];
                    string date = Convert.ToDateTime(data["schedule"]).ToString("dd-MMMM-yyyy");
                    if (data["itemname"].ToString().Length > 15)
                    {
                        itemsnote.Add("\n" + data["itemname"] + "\t   " + date + "\n" + data["repairstatus"]+"\n");
                    }
                    else
                    {
                        itemsnote.Add("\n" + data["itemname"] + "\t\t   " + date + "\n" + data["repairstatus"]+"\n");
                    }
                }
            }
            listbox.ItemsSource = itemsnote;
        }
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new SMWindow(employee);
            back.Show();
            this.Close();
        }
    }
}
