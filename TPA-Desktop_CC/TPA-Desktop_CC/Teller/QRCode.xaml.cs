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
using TPA_Desktop_CC.Teller;

namespace TPA_Desktop_CC
{
    /// <summary>
    /// Interaction logic for QRCode.xaml
    /// </summary>
    public partial class QRCode : Window
    {
        Employee employee;
        TellerQueue tq;
        public QRCode(Employee emp)
        {
            this.tq = TellerQueue.getInstance();
            this.employee = emp;
            InitializeComponent();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(tq.uniquequeue, QRCodeGenerator.ECCLevel.H);
            XamlQRCode qrCode = new XamlQRCode(qrCodeData);
            DrawingImage qrCodeAsXaml = qrCode.GetGraphic(20);
            qrcode.Source = qrCodeAsXaml;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window tellerwindow = new TellerWindow(employee);
            tellerwindow.Show();
            this.Close();
        }

        private void rate(object sender, RoutedEventArgs e)
        {
            Window rate = new TellerRate(employee);
            rate.Show();
            this.Close();
        }
    }

}
