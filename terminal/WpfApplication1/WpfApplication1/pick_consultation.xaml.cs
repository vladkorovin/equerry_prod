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

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для pick_consultation.xaml
    /// </summary>
    public partial class pick_consultation : Window
    {
        public bool instance;
        public bool need_creation = false;
        public pick_consultation()
        {
            InitializeComponent();            
        }

        private void instant_consulation_Click(object sender, RoutedEventArgs e)
        {
            popup_window warning = new popup_window("Срочная консультация подразумевает возможные финансовые и прочие риски","","Упс, отменить", "Я понимаю",Visibility.Visible, "warning");
            warning.ShowDialog();
            if (warning.DialogResult == false) {
                instance = true;
                need_creation = true;
                DialogResult = true;
            }
        }

        private void i_can_wait_Click(object sender, RoutedEventArgs e)
        {
            instance = false;
            need_creation = true;
            DialogResult = true;

        }

        private void btn_return_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
