using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для popup_window.xaml
    /// </summary>
    public partial class popup_window : Window
    {
        public popup_window(string LabelContent, string TextBoxContent, string left_button_content, string right_button_content, Visibility left_btn_visibility,string robot)
        {
            InitializeComponent();
            textbox_main.Text = LabelContent;
            textbox_secondary.Text = TextBoxContent;
            button.Content = left_button_content;
            confirm_button.Content = right_button_content;
            if (robot != "seraching")
            {
                if (left_btn_visibility == Visibility.Hidden)
                {
                    button.Visibility = left_btn_visibility;
                    confirm_button.HorizontalAlignment = HorizontalAlignment.Center;
                    confirm_button.Margin = new Thickness(264, 579, 264, 40);

                }
            }

            else
            {
                button.Visibility = Visibility.Hidden;
                confirm_button.Visibility = Visibility.Hidden;
                gf.Visibility = Visibility.Visible;
            }

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("/Resources/electronics_"+robot+".png", UriKind.Relative);
            bi3.EndInit();
            img.Stretch = Stretch.Fill;
            img.Source = bi3;
            this.Focus();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void confirm_button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            
        }

        private void textbox_secondary_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
