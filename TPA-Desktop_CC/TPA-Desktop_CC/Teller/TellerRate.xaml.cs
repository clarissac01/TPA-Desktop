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

namespace TPA_Desktop_CC.Teller
{
    /// <summary>
    /// Interaction logic for TellerRate.xaml
    /// </summary>
    public partial class TellerRate : Window
    {
        Employee employee;
        int star = 0;
        ConnectDatabase connect;
        TellerQueue tq;
        public TellerRate(Employee emp)
        {
            this.tq = TellerQueue.getInstance();
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            InitializeComponent();
            employeename.Content = emp.name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DataTable dt = new DataTable();
            connect.executeUpdate("update queue set status = 'Done' where division = 'Teller' and status in ('Not Done') limit 1");
            dt = connect.executeQuery("select * from queue where division = 'Teller' and status in ('Not Done') limit 1");
            tq.erase();
            if (dt.Rows.Count == 1)
            {
                DataRow data = dt.Rows[0];
                tq.setValue(data["queueno"].ToString(), data["uniquequeue"].ToString());
            }

            connect.executeUpdate("update employee set rating = (((rating*ratecount) + " + float.Parse(star.ToString()) + ")/(ratecount+1)), ratecount = (ratecount + 1) where id = '" + employee.id + "'");
            MessageBox.Show("Thank You For Your Rating! ");
            Window twindow = new TellerWindow(employee);
            twindow.Show();
            this.Close();
        }

        private void clickstar5(object sender, RoutedEventArgs e)
        {
            this.star = 5;
            ControlTemplate ct = star5.Template;
            ControlTemplate ct1 = star4.Template;
            ControlTemplate ct2 = star3.Template;
            ControlTemplate ct3 = star2.Template;
            ControlTemplate ct4 = star1.Template;

            Image btnImage = (Image)ct.FindName("star5img", star5);
            Image btnImage1 = (Image)ct1.FindName("star4img", star4);
            Image btnImage2 = (Image)ct2.FindName("star3img", star3);
            Image btnImage3 = (Image)ct3.FindName("star2img", star2);
            Image btnImage4 = (Image)ct4.FindName("star1img", star1);
            btnImage.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage1.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage2.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage3.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage4.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
        }

        private void clickstar4(object sender, RoutedEventArgs e)
        {
            this.star = 4;
            ControlTemplate ct = star4.Template;
            ControlTemplate ct1 = star3.Template;
            ControlTemplate ct2 = star2.Template;
            ControlTemplate ct3 = star1.Template;
            ControlTemplate ct4 = star5.Template;

            Image btnImage = (Image)ct.FindName("star4img", star4);
            Image btnImage1 = (Image)ct1.FindName("star3img", star3);
            Image btnImage2 = (Image)ct2.FindName("star2img", star2);
            Image btnImage3 = (Image)ct3.FindName("star1img", star1);
            Image btnImage4 = (Image)ct4.FindName("star5img", star5);
            btnImage.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage1.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage2.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage3.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage4.Source = new BitmapImage(new Uri("star.png", UriKind.RelativeOrAbsolute));
        }

        private void clickstar3(object sender, RoutedEventArgs e)
        {
            this.star = 3;
            ControlTemplate ct = star3.Template;
            ControlTemplate ct1 = star2.Template;
            ControlTemplate ct2 = star1.Template;
            ControlTemplate ct3 = star4.Template;
            ControlTemplate ct4 = star5.Template;

            Image btnImage = (Image)ct.FindName("star3img", star3);
            Image btnImage1 = (Image)ct1.FindName("star2img", star2);
            Image btnImage2 = (Image)ct2.FindName("star1img", star1);
            Image btnImage3 = (Image)ct3.FindName("star4img", star4);
            Image btnImage4 = (Image)ct4.FindName("star5img", star5);
            btnImage.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage1.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage2.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage3.Source = new BitmapImage(new Uri("star.png", UriKind.RelativeOrAbsolute));
            btnImage4.Source = new BitmapImage(new Uri("star.png", UriKind.RelativeOrAbsolute));
        }

        private void clickstar1(object sender, RoutedEventArgs e)
        {
            this.star = 1;
            ControlTemplate ct = star1.Template;
            ControlTemplate ct1 = star2.Template;
            ControlTemplate ct2 = star3.Template;
            ControlTemplate ct3 = star4.Template;
            ControlTemplate ct4 = star5.Template;

            Image btnImage = (Image)ct.FindName("star1img", star1);
            Image btnImage1 = (Image)ct1.FindName("star2img", star2);
            Image btnImage2 = (Image)ct2.FindName("star3img", star3);
            Image btnImage3 = (Image)ct3.FindName("star4img", star4);
            Image btnImage4 = (Image)ct4.FindName("star5img", star5);
            btnImage.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage1.Source = new BitmapImage(new Uri("star.png", UriKind.RelativeOrAbsolute));
            btnImage2.Source = new BitmapImage(new Uri("star.png", UriKind.RelativeOrAbsolute));
            btnImage3.Source = new BitmapImage(new Uri("star.png", UriKind.RelativeOrAbsolute));
            btnImage4.Source = new BitmapImage(new Uri("star.png", UriKind.RelativeOrAbsolute));
        }

        private void clickstar2(object sender, RoutedEventArgs e)
        {
            this.star = 2;
            ControlTemplate ct = star2.Template;
            ControlTemplate ct1 = star1.Template;
            ControlTemplate ct2 = star3.Template;
            ControlTemplate ct3 = star4.Template;
            ControlTemplate ct4 = star5.Template;

            Image btnImage = (Image)ct.FindName("star2img", star2);
            Image btnImage1 = (Image)ct1.FindName("star1img", star1);
            Image btnImage2 = (Image)ct2.FindName("star3img", star3);
            Image btnImage3 = (Image)ct3.FindName("star4img", star4);
            Image btnImage4 = (Image)ct4.FindName("star5img", star5);
            btnImage.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage1.Source = new BitmapImage(new Uri("staryellow.png", UriKind.RelativeOrAbsolute));
            btnImage2.Source = new BitmapImage(new Uri("star.png", UriKind.RelativeOrAbsolute));
            btnImage3.Source = new BitmapImage(new Uri("star.png", UriKind.RelativeOrAbsolute));
            btnImage4.Source = new BitmapImage(new Uri("star.png", UriKind.RelativeOrAbsolute));
        }

    }
}
