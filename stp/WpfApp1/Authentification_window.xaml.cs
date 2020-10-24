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
using System.Data.Sql;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using req_class_namespace;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Authentification_window.xaml
    /// </summary>
    public partial class Authentification_window : Window
    {
        public UserPrincipal user;
        Constants constants = new Constants();
        public string stp_ldap = "";
        public Authentification_window()
        {
            InitializeComponent();
            using (SqlConnection sqlConnection = new SqlConnection(constants.db_connection_string))
            {
                
                string sql_query = "select window from windows where stp_ldap = 0";
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(sql_query, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        windows_cb.Items.Add(reader.GetString(0));
                    }
                    reader.Close();
                    sqlConnection.Close();
                }
                else
                {
                    MessageBox.Show("Нет свободных окон!", "Equery - Ошибка");
                    login_bt.IsEnabled = false;
                }
            }
            if (windows_cb.SelectedIndex == -1)
            {
                login_bt.IsEnabled = false;
            }
            else
            {
                login_bt.IsEnabled = true;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login_bt.IsEnabled = true;
            List<object> col = new List<object>();
            foreach (object obj in windows_cb.Items) {
                col.Add(obj);
            }
            foreach (object obj in col) {
                windows_cb.Items.Remove(obj);
            }

            using (SqlConnection sqlConnection = new SqlConnection(constants.db_connection_string))
            {
                string sql_query = "select window from windows where stp_ldap = 0";
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(sql_query, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        windows_cb.Items.Add(reader.GetString(0));
                    }


                }
                else
                {
                    MessageBox.Show("Нет свободных окон!", "Equery - Ошибка");
                    login_bt.IsEnabled = false;
                }
                reader.Close();
                sqlConnection.Close();
            }
        }

        private void windows_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (windows_cb.SelectedIndex == -1)
            {
                login_bt.IsEnabled = false;
            }
            else {
                login_bt.IsEnabled = true;
            }
        }

        private void login_bt_Click(object sender, RoutedEventArgs e)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "RU1000"))
            {// validate the credentials
                try
                {
                    bool isValid = pc.ValidateCredentials(LDAP_tb.Text, password_tb.Password, ContextOptions.Negotiate);
                    if (isValid)
                    {
                        user = UserPrincipal.FindByIdentity(pc, LDAP_tb.Text);

                        if (user != null)
                        {
                            bool auth = false;
                            var groups = user.GetGroups();
                            foreach (object g in groups)
                            {
                                if (g.ToString().ToLower() == "l1-st-co")
                                {
                                    DialogResult = true;
                                    stp_ldap = LDAP_tb.Text;
                                    auth = true;
                                }
                            }
                            if (!auth)
                            {
                                MessageBox.Show("У пользователя нет доступа к приложению Equery.", "Equery - Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                DialogResult = false;
                            }

                        }


                    }
                    else
                    {
                        MessageBox.Show("Ошибка авторизации: неверный данные учетной записи", "Equery - Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                catch {
                    MessageBox.Show("Ошибка авторизации: служба Active Directory недоступна.", "Equery - Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }









        }

    }
}
