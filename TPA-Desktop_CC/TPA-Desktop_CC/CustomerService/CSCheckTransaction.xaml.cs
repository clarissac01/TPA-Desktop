using MySql.Data.MySqlClient;
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

namespace TPA_Desktop_CC.CustomerService
{
    /// <summary>
    /// Interaction logic for CSCheckTransaction.xaml
    /// </summary>
    public partial class CSCheckTransaction : Window
    {
        Employee employee;
        Customer customer;
        List<string> items = new List<string>();
        ConnectDatabase connect;
        public CSCheckTransaction(Employee emp, Customer cust)
        {
            this.connect = ConnectDatabase.getInstance();
            this.employee = emp;
            this.customer = cust;
            InitializeComponent();
            int a = DateTime.Today.Month;
            int b = DateTime.Today.AddMonths(-1).Month;
            int c = DateTime.Today.AddMonths(-2).Month;

            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();

            month1.Header = mfi.GetMonthName(a).ToString();
            month2.Header = mfi.GetMonthName(b).ToString();
            month3.Header = mfi.GetMonthName(c).ToString();

        }
            
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new CSWindow(employee);
            back.Show();
            this.Close();
        }

        void list1items()
        {
            DataTable dt;
            DataRow data;

            dt = new DataTable();
            dt = connect.executeQuery("SELECT * FROM transaction WHERE month(date) = month(CURRENT_DATE) and (senderaccnum = '"+ customer.accountnumber+ "' or receiver = '" + customer.accountnumber + "')");
            
            if (dt.Rows.Count == 0)
            {
                items.Add("There is no transactions in this month!");
            }
            else
            {
                int size = dt.Rows.Count;
                for (int i = 0; i < size; i++)
                {
                    data = dt.Rows[i];
                    if (data["receiver"].ToString() == customer.accountnumber)
                    {
                        if(data["transactiontype"].ToString()!="Payments")
                            items.Add("\n" + data["transactiontype"].ToString()+"\n"+"To: "+data["receiver"].ToString()+"\n"+"Amount: +"+data["amount"].ToString() + "\n");
                        else
                            items.Add("\n" + data["transactiontype"].ToString()+": "+data["note"].ToString()+"\n"+"To: "+data["receiver"].ToString()+"\n"+"Amount: +"+data["amount"].ToString() + "\n");

                    }
                    else
                    {
                        if(data["transactiontype"].ToString()!="Payments")
                            items.Add("\n" + data["transactiontype"].ToString()+"\n"+"To: "+data["receiver"].ToString()+"\n"+"Amount: -"+data["amount"].ToString() + "\n");
                        else
                            items.Add("\n" + data["transactiontype"].ToString()+": "+data["note"].ToString()+"\n"+"To: "+data["receiver"].ToString()+"\n"+"Amount: -"+data["amount"].ToString() + "\n");
                    }
                }

            }
            listbox1.ItemsSource = items;
        }

        void list2items()
        {
            DataTable dt;
            DataRow data;

            dt = new DataTable();
            dt = connect.executeQuery("SELECT * FROM transaction WHERE month(date) = MONTH(CURRENT_DATE - INTERVAL 1 MONTH) and (senderaccnum = '"+customer.accountnumber+ "' or receiver = '" + customer.accountnumber + "')");

            if (dt.Rows.Count == 0)
            {
                items.Add("There is no transactions in this month!");
            }
            else
            {
                int size = dt.Rows.Count;
                for (int i = 0; i < size; i++)
                {
                    data = dt.Rows[i];
                    if (data["receiver"].ToString() == customer.accountnumber)
                    {
                        if (data["transactiontype"].ToString() != "Payments")
                            items.Add("\n" + data["transactiontype"].ToString() + "\n" + "To: " + data["receiver"].ToString() + "\n" + "Amount: +" + data["amount"].ToString() + "\n");
                        else
                            items.Add("\n" + data["transactiontype"].ToString() + ": " + data["note"].ToString() + "\n" + "To: " + data["receiver"].ToString() + "\n" + "Amount: +" + data["amount"].ToString() + "\n");

                    }
                    else
                    {
                        if (data["transactiontype"].ToString() != "Payments")
                            items.Add("\n" + data["transactiontype"].ToString() + "\n" + "To: " + data["receiver"].ToString() + "\n" + "Amount: -" + data["amount"].ToString() + "\n");
                        else
                            items.Add("\n" + data["transactiontype"].ToString() + ": " + data["note"].ToString() + "\n" + "To: " + data["receiver"].ToString() + "\n" + "Amount: -" + data["amount"].ToString() + "\n");
                    }
                }
            }
            listbox2.ItemsSource = items;
        }

        void list3items()
        {
            DataTable dt;
            DataRow data;

            dt = new DataTable();
            dt = connect.executeQuery("SELECT * FROM transaction WHERE month(date) = MONTH(CURRENT_DATE - INTERVAL 2 MONTH) and (senderaccnum = '"+ customer.accountnumber + "' or receiver = '" + customer.accountnumber + "')");
            
            if (dt.Rows.Count == 0)
            {
                items.Add("There is no transactions in this month!");
            }
            else
            {
                int size = dt.Rows.Count;
                for (int i = 0; i < size; i++)
                {
                    data = dt.Rows[i];
                    if (data["receiver"].ToString() == customer.accountnumber)
                    {
                        if (data["transactiontype"].ToString() != "Payments")
                            items.Add("\n" + data["transactiontype"].ToString() + "\n" + "To: " + data["receiver"].ToString() + "\n" + "Amount: +" + data["amount"].ToString() + "\n");
                        else
                            items.Add("\n" + data["transactiontype"].ToString() + ": " + data["note"].ToString() + "\n" + "To: " + data["receiver"].ToString() + "\n" + "Amount: +" + data["amount"].ToString() + "\n");

                    }
                    else
                    {
                        if (data["transactiontype"].ToString() != "Payments")
                            items.Add("\n" + data["transactiontype"].ToString() + "\n" + "To: " + data["receiver"].ToString() + "\n" + "Amount: -" + data["amount"].ToString() + "\n");
                        else
                            items.Add("\n" + data["transactiontype"].ToString() + ": " + data["note"].ToString() + "\n" + "To: " + data["receiver"].ToString() + "\n" + "Amount: -" + data["amount"].ToString() + "\n");
                    }
                }

            }
            listbox3.ItemsSource = items;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (month1.IsSelected)
            {
                items.Clear();
                list1items();
            }else if (month2.IsSelected)
            {
                items.Clear();
                list2items();
            }
            else
            {
                items.Clear();
                list3items();
            }
}

        private void done(object sender, RoutedEventArgs e)
        {
            Window a = new CSQRCode(employee, customer);
            a.Show();
            this.Close();
        }
    }
}
