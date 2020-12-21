using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TPA_Desktop_CC.Manager
{
    /// <summary>
    /// Interaction logic for ManagerViewExpensesAndRevenueReport.xaml
    /// </summary>
    public partial class ManagerViewExpensesAndRevenueReport : Window
    {
        Employee employee;
        ConnectDatabase connect;
        int administrationfee;
        int repaircost;
        public ManagerViewExpensesAndRevenueReport(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            loaddbdata();
            init();
        }
        private void loaddbdata()
        {
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select transactiontype, sum(amount) from banktransaction where month(transactionDate) = month(current_date) group by transactiontype"); ;
            DataRow data;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = dt.Rows[i];
                if (data["transactiontype"].ToString().Equals("Administration Fee"))
                {
                    administrationfee = Int32.Parse(data["sum(amount)"].ToString());
                }
                else if (data["transactiontype"].ToString().Equals("Repair Cost"))
                {
                    repaircost = Int32.Parse(data["sum(amount)"].ToString());
                }
                else if (data["transactiontype"].ToString().Equals("Credit Fee"))
                {
                    //otherpayments = Int32.Parse(data["sum(amount)"].ToString());
                }
                else if (data["transactiontype"].ToString().Equals("HOC Fee"))
                {
                    //withdrawmoney = Int32.Parse(data["sum(amount)"].ToString());
                }
            }
        }

        public void init()
        {
            ((ColumnSeries)columnbar.Series[0]).ItemsSource =
                new KeyValuePair<string, int>[]{
                new KeyValuePair<string,int>("Administration Fee", 0),
                new KeyValuePair<string,int>("Repair Cost", repaircost),
                new KeyValuePair<string,int>("Credit Fee", 0),
                new KeyValuePair<string,int>("HOC Fee", 0),
            };
        }

        private void backbutton(object sender, RoutedEventArgs e)
        {
            Window a = new Manager.ManagerWindow(employee);
            a.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window b = new Manager.ManagerExpensesAndRevenueReportTranscript(employee);
            b.Show();
            this.Close();
        }
    }
}
