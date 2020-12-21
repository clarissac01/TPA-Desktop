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
    /// Interaction logic for QMWindow.xaml
    /// </summary>
    public partial class QMWindow : Window
    {
        public QMWindow()
        {
            InitializeComponent();
        }

        private void createqueue(object sender, RoutedEventArgs e)
        {
            Window cq = new QMCreateQueue();
            cq.Show();
            this.Close();
        }

        private void showqueue(object sender, RoutedEventArgs e)
        {
            Window sq = new QMShowQueue();
            sq.Show();
            this.Close();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            Window others = new Others();
            others.Show();
            this.Close();
        }
    }
}
