using QRCoder;
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

namespace TPA_Desktop_CC.CustomerService
{
    /// <summary>
    /// Interaction logic for CSQRCode.xaml
    /// </summary>
    public partial class CSQRCode : Window
    {
        Employee employee;
        Customer customer;
        CSQueue csq;
        public CSQRCode(Employee emp, Customer cust)
        {
            this.csq = CSQueue.getInstance();
            this.employee = emp;
            this.customer = cust;
            InitializeComponent();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(csq.uniquequeue, QRCodeGenerator.ECCLevel.H);
            XamlQRCode qrCode = new XamlQRCode(qrCodeData);
            DrawingImage qrCodeAsXaml = qrCode.GetGraphic(20);
            qrcode.Source = qrCodeAsXaml;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window a = new CSWindow(employee);
            a.Show();
            this.Close();
        }

        private void rate(object sender, RoutedEventArgs e)
        {
            Window rate = new CSRate(employee);
            rate.Show();
            this.Close();
        }
    }
}
