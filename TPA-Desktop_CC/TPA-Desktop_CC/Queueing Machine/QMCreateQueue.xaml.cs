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

namespace TPA_Desktop_CC.Queueing_Machine
{
    /// <summary>
    /// Interaction logic for QMCreateQueue.xaml
    /// </summary>
    public partial class QMCreateQueue : Window
    {
        public QMCreateQueue()
        {
            InitializeComponent();
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            Window back = new QMWindow();
            back.Show();
            this.Close();
        }

        private void teller(object sender, RoutedEventArgs e)
        {
            Window a = new QMGenerateQueue("Teller");
            a.Show();
            this.Close();
        }

        private void customerservice(object sender, RoutedEventArgs e)
        {
            Window b = new QMGenerateQueue("Customer Service");
            b.Show();
            this.Close();
        }
    }
}
