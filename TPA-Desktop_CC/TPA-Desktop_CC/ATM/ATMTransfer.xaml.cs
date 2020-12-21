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

namespace TPA_Desktop_CC
{
    /// <summary>
    /// Interaction logic for ATMTransfer.xaml
    /// </summary>
    public partial class ATMTransfer : Window
    {
        Customer customer;
        public ATMTransfer(Customer cust)
        {
            this.customer = cust;
            InitializeComponent();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window atm = new ATMWindow(customer);
            atm.Show();
            this.Close();
        }

        private void tftova(object sender, RoutedEventArgs e)
        {
            Window va = new ATMtftoVA(customer);
            va.Show();
            this.Close();
        }

        private void tftora(object sender, RoutedEventArgs e)
        {
            Window ra = new ATMtftoRA(customer);
            ra.Show();
            this.Close();
        }
    }
}
