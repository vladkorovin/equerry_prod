using req_class_namespace;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;



namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для pick_req.xaml
    /// </summary>
    
    
    public partial class pick_req : Window
    {
        public ObservableCollection<req_class> Reqs = new ObservableCollection<req_class>();
        public pick_req(List<req_class> reqs, User user)
        {
            InitializeComponent();
            ldap_tb.Text = user.ldap.ToString();
            fio_tb.Text = user.fio;
            title_tb.Text = user.title;
            this.user = user;

            foreach (req_class req in reqs)
            {
                Reqs.Add(req);
            }

            req_list.ItemsSource = Reqs;



        }

        public User user;

        private void ldap_tb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void req_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          popup_window popup_Window = new popup_window(Reqs[req_list.SelectedIndex].CaseNumber, Reqs[req_list.SelectedIndex].Description, "Нет, это не та заявка", "Да, все верно", Visibility.Visible, "warning");
          popup_Window.ShowDialog();
        if (popup_Window.DialogResult == false)
         {
                if (Reqs[req_list.SelectedIndex].GroupName == "L1-ST-CO")
                {
                    db_request db_Request = new db_request(Reqs[req_list.SelectedIndex], 50, true);
                    db_Request.AddToDB();

                    if (!db_Request.change_status && !db_Request.need_creation)
                    {
                        popup_window allready = new popup_window("Заявка " + Reqs[req_list.SelectedIndex].CaseNumber + " уже есть в очереди", "Статус заявки ты можешь отследить на электронном табло. Скоро тебе помогут.", "Выбрать другую\nзаявку", "Продолжить", Visibility.Visible, "warning");
                        allready.ShowDialog();
                        if(allready.DialogResult == false)
                        {
                            foreach (Window w in Application.Current.Windows)
                            {
                                if (w != Application.Current.MainWindow)
                                {
                                    w.Close();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!db_Request.need_creation && db_Request.change_status)
                        {
                            popup_window stat = new popup_window("Спасибо, " + user.fio.Split(' ')[0] + "!" + "\n" + Reqs[req_list.SelectedIndex].CaseNumber.Substring(3), "Твоя заявка возвращена в очередь. Статус заявки ты можешь отследить на электронном табло", "", "Завершить работу", Visibility.Hidden, "done");
                            stat.ShowDialog();
                            foreach (Window w in Application.Current.Windows)
                            {
                                if (w != Application.Current.MainWindow)
                                {
                                    w.Close();
                                }
                            }
                        }
                        else
                        {
                            popup_window done = new popup_window("Спасибо, " + user.fio.Split(' ')[0] + "!" + "\n" + Reqs[req_list.SelectedIndex].CaseNumber.Substring(3), "Статус заявки ты можешь отследить на электронном табло", "", "Завершить работу", Visibility.Hidden, "done");
                            done.ShowDialog();

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
                else
                {
                    popup_window wrong_group = new popup_window("Твоей заявкой занимается другая группа технической поддержки", "Мы можем проконсультировать тебя по статусу и возможным вариантам ускорения ее решения", "Нет, не нужна\nконсультация", "Да, нужна\nконсультация", Visibility.Visible, "warning");
                    wrong_group.ShowDialog();
                    if (wrong_group.DialogResult == false)
                    {
                       req_class req = new req_class("Корпоративные сервисы", "Рабочее место", "Консультация", user.ldap.ToString(), "Консультация", "Требуется консультация", 50);

                        Thread thread = new Thread(() => {
                            req.create_req(req.pr);
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                foreach (Window w in Application.Current.Windows)
                                {
                                    if (w != Application.Current.MainWindow)
                                    {
                                        w.Close();
                                    }
                                }
                            });
                        });
                        thread.Start();
                        popup_window loading = new popup_window("Создаем заявку...", "", "", "", Visibility.Hidden, "seraching");
                        loading.ShowDialog();
                        popup_window done = new popup_window("Спасибо, " + user.fio.Split(' ')[0] + "!" + "\n" + req.CaseNumber.Substring(3), "Статус заявки ты можешь отследить на электронном табло", "", "Завершить работу", Visibility.Hidden, "done");
                        done.ShowDialog();

                        foreach (Window w in Application.Current.Windows)
                        {
                            if (w != Application.Current.MainWindow)
                            {
                                w.Close();
                            }
                        }

                    }
                    else
                    {
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

       }

        private void btn_return_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
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

        private void Window_Deactivated(object sender, EventArgs e)
        {
                BlurEffect blurEffect = new BlurEffect();
                blurEffect.Radius = 50;
                Style window_style = new Style();
                window_style.TargetType = this.GetType();
            window_style.Setters.Add(new Setter { Property = Control.EffectProperty, Value = blurEffect });
                this.Style = window_style;
            
        }
    }

    public class req
    {
        public string one { get; set; }
        public string two { get; set; }
    }






    public class VisualHelper
    {       
            public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
            {
                if (depObj != null)
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                        if (child != null && child is T)
                        {
                            yield return (T)child;
                        }

                        foreach (T childOfChild in FindVisualChildren<T>(child))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }


  
    }

