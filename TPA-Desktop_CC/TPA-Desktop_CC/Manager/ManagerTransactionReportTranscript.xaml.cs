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
    /// Interaction logic for ManagerTransactionReportTranscript.xaml
    /// </summary>
    public partial class ManagerTransactionReportTranscript : Window
    {
        Employee employee;
        ConnectDatabase connect;

        public ManagerTransactionReportTranscript(Employee emp)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            init();
        }

        public void init()
        {
            DataTable dt = new DataTable();
            dt = connect.executeQuery("select transactiontype as 'Transaction Type', amount as 'Amount', date as 'Transaction Date' from transaction");
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
