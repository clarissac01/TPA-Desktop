using QRCoder;
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

namespace TPA_Desktop_CC.Queueing_Machine
{
    /// <summary>
    /// Interaction logic for QMGenerateQueue.xaml
    /// </summary>
    public partial class QMGenerateQueue : Window
    {
        ConnectDatabase connect;
        string action;
        public QMGenerateQueue(string action)
        {
            this.connect = ConnectDatabase.getInstance();
            this.action = action;
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            InitializeComponent();
            label.Content = action;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(GuidString, QRCodeGenerator.ECCLevel.H);
            XamlQRCode qrCode = new XamlQRCode(qrCodeData);
            DrawingImage qrCodeAsXaml = qrCode.GetGraphic(20);
            qrcode.Source = qrCodeAsXaml;
            if(action.Equals("Teller"))
            {
                DataTable dt = new DataTable();
                dt = connect.executeQuery("select * from queue where division = 'Teller'");
                connect.executeUpdate("insert into queue values ('A" + (dt.Rows.Count + 1).ToString() + "', '" + GuidString + "', 'Teller', 'Not Done')");
                queueno.Content = 'A' + (dt.Rows.Count + 1).ToString();
            }
            else
            {
                DataTable dt = new DataTable();
                dt = connect.executeQuery("select * from queue where division = 'Customer Service'");
                connect.executeUpdate("insert into queue values ('B" + (dt.Rows.Count + 1).ToString() + "', '" + GuidString + "', 'Customer Service', 'Not Done')");
                queueno.Content = 'B' + (dt.Rows.Count + 1).ToString();

            }
        }

        private void done(object sender, RoutedEventArgs e)
        {
            Window back = new QMWindow();
            back.Show();
            this.Close();
        }
    }
}
