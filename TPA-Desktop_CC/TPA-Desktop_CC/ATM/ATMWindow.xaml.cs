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
using TPA_Desktop_CC.ATM;
using TPA_Desktop_CC.Teller;

namespace TPA_Desktop_CC
{
    /// <summary>
    /// Interaction logic for ATMWindow.xaml
    /// </summary>
    /// 

    public partial class ATMWindow : Window
    {
        Customer customer;

        public ATMWindow(Customer cust)
        {
            this.customer = cust;
            InitializeComponent();
        }

        private void tfmoney(object sender, RoutedEventArgs e)
        {
            Window tm = new ATMTransfer(customer);
            tm.Show();
            this.Close();
        }

        private void dpmoney(object sender, RoutedEventArgs e)
        {
            Window dm = new ATMDeposit(customer);
            dm.Show();
            this.Close();
        }

        private void wmoney(object sender, RoutedEventArgs e)
        {
            Window wm = new ATMWithdrawMoney(customer);
            wm.Show();
            this.Close();
        }

        private void payments(object sender, RoutedEventArgs e)
        {
            Window pm = new ATMPayments(customer);
            pm.Show();
            this.Close();
        }

        private void checkrequest(object sender, RoutedEventArgs e)
        {

        }

        private void checktransactions(object sender, RoutedEventArgs e)
        {

        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window nextwindow = new InputAccNum();
            nextwindow.Show();
            this.Close();
        }
    }
}
