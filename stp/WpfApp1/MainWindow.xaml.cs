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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;
using req_class_namespace;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        db_request in_work;
        List<db_request> query;
        Constants Constants;
        Authentification_window authentification_Window;
       
        int stp_ldap;
        string sql_query;
        Thread thread;
        public MainWindow()
        {
            Constants = new Constants();
            InitializeComponent();
            authentification_Window = new Authentification_window();
            authentification_Window.ShowDialog();
            if (authentification_Window.stp_ldap == "")
            {
                Application.Current.Shutdown();
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(Constants.db_connection_string))
                {
                    stp_ldap = Int32.Parse(authentification_Window.stp_ldap);
                    Title = "Equery - " + authentification_Window.user.DisplayName + " (" + authentification_Window.LDAP_tb.Text + "); " + "Окно №" + authentification_Window.windows_cb.SelectedItem;
                    connection.Open();
                    sql_query = "update windows set stp_ldap = @stp_ldap where window = @window";
                    SqlCommand command = new SqlCommand(sql_query, connection);
                    command.Parameters.AddWithValue("@stp_ldap", Int32.Parse(authentification_Window.LDAP_tb.Text).ToString());
                    command.Parameters.AddWithValue("@window", authentification_Window.windows_cb.SelectedItem);
                    command.ExecuteNonQuery();
                    current_req_tb.Text = "";
                    next_req_tb.Text = "";

                    connection.Close();
                }
                thread = new Thread(() => update_info());
                thread.Start();
            }
        }

        public void update_info() {
            while (true) {
                query = new List<db_request>();
                using (SqlConnection connection = new SqlConnection(Constants.db_connection_string))
                {
                    connection.Open();                    
                    db_request current_req_iter = new db_request();
                    string sql_query = "select * from requests where stp_ldap=@stp_ldap and status1 = N'Из отложенных' order by [priority] desc, creation_date asc";
                    SqlCommand command123 = new SqlCommand(sql_query, connection);
                    command123.Parameters.AddWithValue("@stp_ldap", stp_ldap);
                    //command123.Parameters.AddWithValue("@status", "Из отложенных");
                    SqlDataReader reader123 = command123.ExecuteReader();
                    if (reader123.HasRows)
                    {
                        while (reader123.Read())
                        {
                            current_req_iter = new db_request();
                            current_req_iter.request_number = reader123.GetString(0);                            
                            current_req_iter.request_id = reader123.GetString(9);
                            current_req_iter.contact = reader123.GetString(1);
                            current_req_iter.status = reader123.GetString(2);
                            current_req_iter.creation_date = reader123.GetDateTime(3);
                            current_req_iter.solution_date = reader123.GetDateTime(4);
                            current_req_iter.priority = reader123.GetInt32(5);
                            current_req_iter.stp_ldap = reader123.GetInt32(6);
                            current_req_iter.flag = reader123.GetBoolean(7);
                            current_req_iter.window = reader123.GetInt32(8);
                            query.Add(current_req_iter);
                            
                        }
                        //string res = "";
                        //foreach (db_request req in query) {
                        //    res += req.request_number + "\n";
                        //}
                        //MessageBox.Show(res);
                    }
                    reader123.Close();

                    string sql_query1 = "select * from requests where stp_ldap=0 order by [priority] desc, creation_date asc";
                    SqlCommand command1 = new SqlCommand(sql_query1, connection);
                    SqlDataReader reader1 = command1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            current_req_iter = new db_request();
                            current_req_iter.request_number = reader1.GetString(0);
                            current_req_iter.request_id = reader1.GetString(9);
                            current_req_iter.contact = reader1.GetString(1);
                            current_req_iter.status = reader1.GetString(2);
                            current_req_iter.creation_date = reader1.GetDateTime(3);
                            current_req_iter.solution_date = reader1.GetDateTime(4);
                            current_req_iter.priority = reader1.GetInt32(5);
                            current_req_iter.stp_ldap = reader1.GetInt32(6);
                            current_req_iter.flag = reader1.GetBoolean(7);
                            current_req_iter.window = reader1.GetInt32(8);
                            query.Add(current_req_iter);
                        }
                        
                    }
                    reader1.Close();

                    string sql_query2 = "select * from requests where stp_ldap = @stp_ldap and status1 = N'В работе'";
                        SqlCommand command2 = new SqlCommand(sql_query2, connection);
                        command2.Parameters.AddWithValue("@stp_ldap", stp_ldap);
                        //command2.Parameters.AddWithValue("@status", "В работе");
                        SqlDataReader reader2 = command2.ExecuteReader();
                        
                        if (reader2.HasRows)
                        {
                        in_work = new db_request();
                        Thread.BeginCriticalRegion();
                            reader2.Read();
                            in_work.request_number = reader2.GetString(0);
                            in_work.request_id = reader2.GetString(9);
                            in_work.contact = reader2.GetString(1);
                            in_work.status = reader2.GetString(2);
                            in_work.creation_date = reader2.GetDateTime(3);
                            in_work.solution_date = reader2.GetDateTime(4);
                            in_work.priority = reader2.GetInt32(5);
                            in_work.stp_ldap = reader2.GetInt32(6);
                            in_work.flag = reader2.GetBoolean(7);
                            in_work.window = reader2.GetInt32(8);
                            Application.Current.Dispatcher.Invoke(() => current_req_tb.Text = reader2.GetString(0));
                        Application.Current.Dispatcher.Invoke(() => solve_bt_Copy.IsEnabled = false);
                        Application.Current.Dispatcher.Invoke(() => solve_bt.IsEnabled = true);
                        Application.Current.Dispatcher.Invoke(() => open_bt.IsEnabled = true);
                        Application.Current.Dispatcher.Invoke(() => postpone_bt.IsEnabled = true);

                        Thread.EndCriticalRegion();
                        }
                        else {
                            Thread.BeginCriticalRegion();
                        Application.Current.Dispatcher.Invoke(() => solve_bt.IsEnabled = false);
                        Application.Current.Dispatcher.Invoke(() => open_bt.IsEnabled = false);
                        Application.Current.Dispatcher.Invoke(() => postpone_bt.IsEnabled = false);
                        Application.Current.Dispatcher.Invoke(()=>current_req_tb.Text="");
                        Application.Current.Dispatcher.Invoke(() => solve_bt_Copy.IsEnabled = true);
                            Thread.EndCriticalRegion();
                        }
                        reader2.Close();

                        string sql_query3 = "select * from requests where stp_ldap = @stp_ldap and status1 = N'Отложено'";
                        SqlCommand command3 = new SqlCommand(sql_query3, connection);
                        command3.Parameters.AddWithValue("@stp_ldap", stp_ldap);
                        

                        SqlDataReader reader3 = command3.ExecuteReader();
                        if (reader3.HasRows)
                        {
                            Thread.BeginCriticalRegion();
                            Application.Current.Dispatcher.Invoke(() => postponed_tb.Text = "");
                            while (reader3.Read())
                            {
                                Application.Current.Dispatcher.Invoke(() => postponed_tb.Text += reader3.GetString(0)+"\n");
                            }
                            Thread.EndCriticalRegion();
                        }
                        else {
                            Thread.BeginCriticalRegion();
                            Application.Current.Dispatcher.Invoke(() => postponed_tb.Text = "");
                            Thread.EndCriticalRegion();

                        }
                        reader3.Close();
                        connection.Close();


                    
                }
                    //connection.Close();

                    Thread.BeginCriticalRegion();
                if (query.Count != 0)
                {
                    Application.Current.Dispatcher.Invoke(() => next_req_tb.Text = query[0].request_number);
                    Application.Current.Dispatcher.Invoke(() => query_tb.Text = "");
                    foreach (db_request req in query)
                    {
                        Application.Current.Dispatcher.Invoke(() => query_tb.Text += req.request_number + "\n");
                    }
                }
                else {
                    Thread.BeginCriticalRegion();
                    Application.Current.Dispatcher.Invoke(() => query_tb.Text = "");
                    Application.Current.Dispatcher.Invoke(() => next_req_tb.Text = "");
                    Application.Current.Dispatcher.Invoke(() => solve_bt_Copy.IsEnabled = false);
                    Thread.EndCriticalRegion();
                }
                    Thread.EndCriticalRegion();               
               
                    Thread.Sleep(500);

                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
            using (SqlConnection connection = new SqlConnection(Constants.db_connection_string))
            {
                connection.Open();
                sql_query = "update windows set stp_ldap = 0 where stp_ldap = @stp_ldap";
                SqlCommand command = new SqlCommand(sql_query, connection);
                command.Parameters.AddWithValue("@stp_ldap", stp_ldap);
                command.ExecuteNonQuery();
                connection.Close();
            }
                thread.Abort();
            }
           catch { }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void postponed_tb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://itsm-test/0/Nui/ViewModule.aspx#CardModuleV2/CasePage/edit/"+in_work.request_id);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Constants.db_connection_string)) {
                connection.Open();
                string sql_query = "update requests set status1 = N'Отложено' where request_number = @req_number"; ;
                SqlCommand command = new SqlCommand(sql_query, connection);
                command.Parameters.AddWithValue("@req_number", current_req_tb.Text);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void solve_bt_Copy_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Constants.db_connection_string))
            {
                connection.Open();
                string sql_query = "update requests set status1 = N'В работе', stp_ldap = @stp_ldap, window = @window where request_number = @req_number"; ;
                SqlCommand command = new SqlCommand(sql_query, connection);
                command.Parameters.AddWithValue("@req_number", next_req_tb.Text);
                command.Parameters.AddWithValue("@stp_ldap", stp_ldap);
                command.Parameters.AddWithValue("@window", authentification_Window.windows_cb.SelectedItem);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Constants.db_connection_string))
            {
                connection.Open();
                string sql_query = "update requests set status1 = N'Решен', solution_date = @sol_date where request_number = @req_number"; ;
                SqlCommand command = new SqlCommand(sql_query, connection);
                command.Parameters.AddWithValue("@req_number", in_work.request_number);
                command.Parameters.AddWithValue("@sol_date", DateTime.Now);                
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
