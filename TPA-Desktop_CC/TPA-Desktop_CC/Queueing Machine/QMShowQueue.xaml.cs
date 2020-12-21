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
    /// Interaction logic for QMShowQueue.xaml
    /// </summary>
    public partial class QMShowQueue : Window
    {
        DataTable dt;
        DataTable dt2;
        DataRow data1;
        DataRow data2;
        TellerQueue tq;
        CSQueue csq;

        ConnectDatabase connect;
        public QMShowQueue()
        {
            tq = TellerQueue.getInstance();
            csq = CSQueue.getInstance();
            this.connect = ConnectDatabase.getInstance();
            InitializeComponent();
            tellerqueue.Content = "";
            csqueue.Content = "";
            init();
        }

        public void init()
        {
            tq.erase();
            csq.erase();
            if(tq.queueno == "")
            {
                dt = new DataTable();
                dt = connect.executeQuery("select * from queue where division = 'Teller' and status in ('Not Done') limit 1");
                if (dt.Rows.Count != 0)
                {
                    data1 = dt.Rows[0];
                    tq.setValue(data1["queueno"].ToString(), data1["uniquequeue"].ToString());
                    tellerqueue.Content = tq.queueno.ToString();
                }
            }
            if(csq.queueno == "")
            {
                dt2 = new DataTable();
                dt2 = connect.executeQuery("select * from queue where division = 'Customer Service' and status in ('Not Done') limit 1");
                if (dt2.Rows.Count != 0)
                {
                    data2 = dt2.Rows[0];
                    csq.setValue(data2["queueno"].ToString(), data2["uniquequeue"].ToString());
                    csqueue.Content = csq.queueno.ToString();
                }
            }


        }

        private void tellerdelete(object sender, RoutedEventArgs e)
        {
            if(tellerqueue.Content.Equals(""))
            {
                MessageBox.Show("There is nothing to delete!");
                return;
            }
            connect.executeUpdate("update queue set status = 'Cancelled' where queueno = '"+data1["queueno"].ToString()+"'");
            DataTable dt3 = new DataTable();
            DataRow data3;
            dt3 = connect.executeQuery("select * from queue where division = 'Teller' and status in ('Not Done') limit 1");
            if (dt3.Rows.Count != 0)
            {
                data3 = dt3.Rows[0];
                tq.setValue(data3["queueno"].ToString(), data3["uniquequeue"].ToString());
            }
            tq.erase();
            MessageBox.Show("Success!");
            tellerqueue.Content = "";
            csqueue.Content = "";
            init();
        }

        private void csdelete(object sender, RoutedEventArgs e)
        {
            if (csqueue.Content.Equals(""))
            {
                MessageBox.Show("There is nothing to delete!");
                return;
            }
            connect.executeUpdate("update queue set status = 'Cancelled' where queueno = '" + data2["queueno"].ToString() + "'");
            DataTable dt3 = new DataTable();
            DataRow data3;
            dt3 = connect.executeQuery("select * from queue where division = 'Customer Service' and status in ('Not Done') limit 1");
            if (dt3.Rows.Count != 0)
            {
                data3 = dt3.Rows[0];
                tq.setValue(data3["queueno"].ToString(), data3["uniquequeue"].ToString());
            }
            csq.erase();
            MessageBox.Show("Success!");
            tellerqueue.Content = "";
            csqueue.Content = "";
            init();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window back = new QMWindow();
            back.Show();
            this.Close();
        }

        private void tellernext(object sender, RoutedEventArgs e)
        {
            if (tellerqueue.Content.Equals(""))
            {
                MessageBox.Show("Queue is empty!");
                return;
            }
            connect.executeUpdate("update queue set status = 'Done' where division = 'Teller' and status in ('Not Done') limit 1");
            tq.erase();
            MessageBox.Show("Done");
            tellerqueue.Content = "";
            csqueue.Content = "";
            init();
        }

        private void csnext(object sender, RoutedEventArgs e)
        {
            if (csqueue.Content.Equals(""))
            {
                MessageBox.Show("Queue is empty!");
                return;
            }
            connect.executeUpdate("update queue set status = 'Done' where division = 'Customer Service' and status in ('Not Done') limit 1");
            csq.erase();
            MessageBox.Show("Done");
            tellerqueue.Content = "";
            csqueue.Content = "";
            init();
        }
    }
}
