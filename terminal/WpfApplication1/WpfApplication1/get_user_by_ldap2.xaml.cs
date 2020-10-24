using req_class_namespace;
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
using System.Text.RegularExpressions;
using System.Configuration;
using System.Windows.Media.Effects;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для get_user_by_ldap.xaml
    /// </summary>
    public partial class get_user_by_ldap2 : Window
    {
        public User user;
        public get_user_by_ldap2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            //user.GetADUser(textbox.Text);
           
        }



        private void button2_Copy5_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "1";
        }

        private void kbd_2_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "2";
        }

        private void kbd_3_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "3";
        }

        private void kbd_4_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "4";
        }

        private void kbd_5_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "5";
        }

        private void kbd_6_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "6";
        }

        private void kbd_7_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "7";
        }

        private void kbd_8_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "8";
        }

        private void kbd_9_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "9";
        }

        private void kbd_del_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "")
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
        private void comboBox_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void kbd_0_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "0";
        }

        private void find_button_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("600[0-9]{5}");
            MatchCollection matchCollection = regex.Matches(textBox.Text);
            if (matchCollection.Count == 0)
            {
               // popup_window popup_Window = new popup_window("Ошибка", ConfigurationManager.AppSettings["incorrect_LDAP"], "", "Назад", Visibility.Hidden, Visibility.Visible);
                //popup_Window.ShowDialog();
            }
            else {
                user = new User();
                try
                {
                    user.GetADUserByLdap(textBox.Text);
                    if (user.ldap == 0)
                    {
                       popup_window no_user_found = new popup_window("Я не смог найти\n"+textBox.Text,"", "", "Ввести еще раз", Visibility.Hidden, "bad_search");
                       no_user_found.ShowDialog();
                    }
                    else
                    {
                        ldap_search confirm_User = new ldap_search(user);
                        confirm_User.ShowDialog();
                        if (confirm_User.DialogResult == true)
                        {
                            DialogResult = true;
                        }
                        else {
                            DialogResult = false;
                        }
                    }
                }
                catch
                {
                   popup_window no_ad_connection = new popup_window("Отсутствует подключение к сети", "Ошибка Active Directory", "", "Продолжить", Visibility.Hidden, "no_connection");
                   no_ad_connection.ShowDialog();
                    DialogResult = false;

                    foreach (Window w in Application.Current.Windows)
                    {
                        if (w != Application.Current.MainWindow)
                        {
                            w.Close();
                        }
                    }
                }
            }
        }

        private void btn_return_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void Window_Deactivated(object sender, EventArgs e)
        {
            BlurEffect blurEffect = new BlurEffect();
            blurEffect.Radius = 50;
            Style window_style = new Style();
            window_style.TargetType = this.GetType();
            window_style.Setters.Add(new Setter { Property = Control.EffectProperty, Value = blurEffect });
            this.Style = window_style;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            BlurEffect blurEffect = new BlurEffect();
            blurEffect.Radius = 0;
            Style window_style = new Style();
            window_style.TargetType = this.GetType();
            window_style.Setters.Add(new Setter { Property = Control.EffectProperty, Value = blurEffect });
            this.Style = window_style;

        }

        private void Window_Activated_1(object sender, EventArgs e)
        {

        }

        private void textBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if(textBox.Text.Length > 8)
            {
                textBox.Text = textBox.Text.Substring(0, 8);
            }
        }
    }
}
