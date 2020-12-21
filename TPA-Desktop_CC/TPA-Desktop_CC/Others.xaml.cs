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
using TPA_Desktop_CC.Queueing_Machine;

namespace TPA_Desktop_CC
{
    /// <summary>
    /// Interaction logic for Others.xaml
    /// </summary>
    public partial class Others : Window
    {
        public Others()
        {
            InitializeComponent();
        }

        private void Buttonback_Click(object sender, RoutedEventArgs e)
        {
            Window newwindow = new WindowLogin();
            newwindow.Show();
            this.Close();
        }

        private void Buttonqueue_Click(object sender, RoutedEventArgs e)
        {
            Window qm = new QMWindow();
            qm.Show();
            this.Close();
        }

        private void Buttonatm_Click(object sender, RoutedEventArgs e)
        {
            Window input = new InputAccNum();
            input.Show();
            this.Close();
        }
    }
}
