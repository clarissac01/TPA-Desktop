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

namespace TPA_Desktop_CC.Manager
{
    /// <summary>
    /// Interaction logic for ManagerExpensesAndRevenueReportTranscript.xaml
    /// </summary>
    public partial class ManagerExpensesAndRevenueReportTranscript : Window
    {
        Employee employee;
        ConnectDatabase connect;
        public ManagerExpensesAndRevenueReportTranscript(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            loaddata();
        }

        private void loaddata()
        {
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select transactiontype as 'Transaction Type', amount as 'Amount', transactiondate as 'Transaction Date' from banktransaction");
            datagrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window a = new Manager.ManagerWindow(employee);
            a.Show();
            this.Close();
        }
    }
}
