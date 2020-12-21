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

namespace TPA_Desktop_CC.Human_Resource_Management_Team
{
    /// <summary>
    /// Interaction logic for HRMRecruitment.xaml
    /// </summary>
    public partial class HRMRecruitment : Window
    {
        Employee employee;
        public HRMRecruitment(Employee emp)
        {
            this.employee = emp;
            InitializeComponent();
        }

        private void availableposition(object sender, RoutedEventArgs e)
        {
            Window next = new HRMAvailablePositions(employee);
            next.Show();
            this.Close();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window back = new HRMManageEmployee(employee);
            back.Show();
            this.Close();
        }

        private void candidateemp(object sender, RoutedEventArgs e)
        {
            Window a = new HRMCandidateEmployee(employee);
            a.Show();
            this.Close();
        }
    }
}
