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
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;
using req_class_namespace;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для ldap_search.xaml
    /// </summary>
    public partial class ldap_search : Window
    {
        public ldap_search(User user)
        {
            InitializeComponent();
            fio_tb.Text = user.fio;
            title_tb.Text = user.title;
            ldap_tb.Text = user.ldap.ToString();

        }

        public void bt_click()
        {
          //  MessageBox.Show("lul");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

        }


    }
}


