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
    /// Interaction logic for ManagerViewReport.xaml
    /// </summary>
    public partial class ManagerViewReport : Window
    {
        Employee employee;
        ConnectDatabase connect;
        int transfermoney;
        int depositmoney;
        int otherpayments;
        int withdrawmoney;
        public ManagerViewReport(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            loaddbdata();
            LoadLineChartData();
        }

        private void loaddbdata() {
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select transactiontype, sum(amount) from transaction where month(Date) = month(current_date) group by transactiontype"); ;
            DataRow data;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                data = dt.Rows[i];
                if(data["transactiontype"].ToString().Equals("Deposit Money"))
                {
                    depositmoney = Int32.Parse(data["sum(amount)"].ToString());
                }
                else if (data["transactiontype"].ToString().Equals("Transfer Money"))
                {
                    transfermoney = Int32.Parse(data["sum(amount)"].ToString());
                }
                else if (data["transactiontype"].ToString().Equals("Payments"))
                {
                    otherpayments = Int32.Parse(data["sum(amount)"].ToString());
                }
                else if (data["transactiontype"].ToString().Equals("Withdraw Money"))
                {
                    withdrawmoney = Int32.Parse(data["sum(amount)"].ToString());
                }
            }
        }

        private void LoadLineChartData()
        {
            ((LineSeries)linechart.Series[0]).ItemsSource = new KeyValuePair<string, int>[] {
                new KeyValuePair<string, int>("Transfer Money", transfermoney),
                new KeyValuePair<string, int>("Deposit Money", depositmoney),
                new KeyValuePair<string, int>("Withdraw Money", withdrawmoney),
                new KeyValuePair<string, int>("Other Payments", otherpayments)
            };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window b = new ManagerTransactionReportTranscript(employee);
            b.Show();
            this.Close();
        }

        private void backbutton(object sender, RoutedEventArgs e)
        {
            Window a = new ManagerWindow(employee);
            a.Show();
            this.Close();
        }
    }
}
