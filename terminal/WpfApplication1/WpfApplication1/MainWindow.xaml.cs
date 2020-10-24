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
using System.Threading;
using System.Configuration;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharp.Deserializers;
using req_class_namespace;
using Newtonsoft.Json.Linq;
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;
using System.Windows.Controls.Primitives;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.AppRole;
using VaultSharp.V1.Commons;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
            TimerCallback tm = new TimerCallback(Reset);
            Timer timer = new Timer(tm, null, 0, Int32.Parse(ConfigurationManager.AppSettings["main_window_exit_button_timer"]));

           

        }
        public int click_count = 0;
        public popup_window done;
        public List<req_class> copy;

        public void Reset(object obj) {
            click_count = 0;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
                get_user_by_ldap2 get_User_By_Ldap = new get_user_by_ldap2();
                get_User_By_Ldap.ShowDialog();
            if (get_User_By_Ldap.DialogResult == true)
            {

                Thread thread = new Thread(() =>
                {
                    DateTime time = new DateTime();
                    time = DateTime.Now;
                    
                    Constants constants = new Constants();
                    var client = new RestClient(constants.info_url);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("x-api-key", constants.x_api_key);
                    request.AddHeader("Authorization", "Basic " + constants.authorization);
                    request.AddHeader("Content-Type", "application/json; charset=utf-8");
                    request.AddHeader("login", constants.login);
                    request.AddHeader("password", constants.password);                    
                    request.AddParameter("application/json; charset=utf-8", "{\n\t\"Action\":\"Info\",\n\t\"Email\":\"" + get_User_By_Ldap.user.mail + "\"\n}\n \n ", ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                         copy = new List<req_class>();
                    try
                    {


                        Root d = JsonConvert.DeserializeObject<Root>(response.Content);


                        foreach (req_class r in d.Result)
                        {
                            if (r.Status != "Закрыто")
                            {
                                copy.Add(r);
                            }
                        }
                    }
                    catch { }

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
                popup_window loading = new popup_window("Ищем твои заявки...", "", "", "", Visibility.Hidden, "seraching");
                loading.ShowDialog();
                if(copy.Count != 0)
                {
                    pick_req pick_Req = new pick_req(copy, get_User_By_Ldap.user);
                    pick_Req.ShowDialog();
                }
                else
                {
                    if (copy.Count == 0)
                    {
                        popup_window no_reqs = new popup_window("Я не смог найти твои заявки", "Все твои заявки закрыты. Ты можешь создать новую заявку при помощи этого терминала.", "", "Продолжить", Visibility.Hidden, "bad_search");
                        no_reqs.ShowDialog();

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

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            click_count++;
            if (click_count >= Int32.Parse(ConfigurationManager.AppSettings["main_window_exit_button_clicks"])) {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void create_req_button_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            BlurEffect blurEffect = new BlurEffect();
            blurEffect.Radius = 50;
            Style window_style = new Style();
            window_style.TargetType = Application.Current.MainWindow.GetType();
            window_style.Setters.Add(new Setter {Property = Control.EffectProperty, Value = blurEffect});
            this.Style = window_style;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            BlurEffect blurEffect = new BlurEffect();
            blurEffect.Radius = 0;
            Style window_style = new Style();
            window_style.TargetType = Application.Current.MainWindow.GetType();
            window_style.Setters.Add(new Setter { Property = Control.EffectProperty, Value = blurEffect });
            this.Style = window_style;           
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void consult_click(object sender, RoutedEventArgs e)
        {
            get_user_by_ldap2 get_User_By_Ldap = new get_user_by_ldap2();
            get_User_By_Ldap.ShowDialog();

            if (get_User_By_Ldap.DialogResult == true)
            {
                pick_consultation pick_Consultation = new pick_consultation();
                pick_Consultation.ShowDialog();
                req_class req;
                if (pick_Consultation.instance)
                {
                    req = new req_class("Корпоративные сервисы", "Рабочее место", "Консультация", get_User_By_Ldap.user.ldap.ToString(), "Срочная консультация", "Требуется срочная консультация. Создано при помощи терминала электронной очереди", 90);
                }
                else
                {
                    req = new req_class("Корпоративные сервисы", "Рабочее место", "Консультация", get_User_By_Ldap.user.ldap.ToString(), "Консультация", "Требуется консультация", 50);

                }
                if (pick_Consultation.DialogResult == true)
                { 
                    Thread thread = new Thread(() =>
                    {
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
                    done = new popup_window("Спасибо, " + get_User_By_Ldap.user.fio.Split(' ')[0] + "!" + "\n" + req.CaseNumber.Substring(3), "Статус заявки ты можешь отследить на электронном табло", "", "Завершить работу", Visibility.Hidden, "done");
                    done.ShowDialog();
                }
                foreach (Window w in Application.Current.Windows)
                {
                    if (w != Application.Current.MainWindow)
                    {
                        w.Close();
                    }
                }

            }

        }

        private void computer_Click(object sender, RoutedEventArgs e)
        {
            get_user_by_ldap2 get_User_By_Ldap = new get_user_by_ldap2();
            get_User_By_Ldap.ShowDialog();

            if (get_User_By_Ldap.DialogResult == true)
            {
                req_class req = new req_class("Корпоративные сервисы", "Рабочее место", "Проблемы с рабочим местом в ЦО", get_User_By_Ldap.user.ldap.ToString(), "Проблема с компьютером или ПО", "Проблема с компьютером или ПО. Создано при помощи терминала электронной очереди", 50);
                bool d = false;
                Thread thread = new Thread(()=> {
                    req.create_req(50);                    
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
                done = new popup_window("Спасибо, " + get_User_By_Ldap.user.fio.Split(' ')[0] + "!" + "\n" + req.CaseNumber.Substring(3), "Статус заявки ты можешь отследить на электронном табло", "", "Завершить работу", Visibility.Hidden, "done");
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

        private void phone_click(object sender, RoutedEventArgs e)
        {
            get_user_by_ldap2 get_User_By_Ldap = new get_user_by_ldap2();
            get_User_By_Ldap.ShowDialog();

            if (get_User_By_Ldap.DialogResult == true)
            {
                req_class req = new req_class("Корпоративные сервисы", "Мобильные устройства", "Ошибки корпоративного смартфона", get_User_By_Ldap.user.ldap.ToString(), "Проблема с корпоративным смартфоном", "Проблема с корпоративным смартфоном. Создано при помощи терминала электронной очереди", 50);
                bool d = false;
                Thread thread = new Thread(() => {
                    req.create_req(50);
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
                done = new popup_window("Спасибо, " + get_User_By_Ldap.user.fio.Split(' ')[0] + "!" + "\n" + req.CaseNumber.Substring(3), "Статус заявки ты можешь отследить на электронном табло", "", "Завершить работу", Visibility.Hidden, "done");
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

        private void equipment_Click(object sender, RoutedEventArgs e)
        {
            get_user_by_ldap2 get_User_By_Ldap = new get_user_by_ldap2();
            get_User_By_Ldap.ShowDialog();
        }

        private void vks_Click(object sender, RoutedEventArgs e)
        {
            get_user_by_ldap2 get_User_By_Ldap = new get_user_by_ldap2();
            get_User_By_Ldap.ShowDialog();

            if (get_User_By_Ldap.DialogResult == true)
            {
                req_class req = new req_class("Корпоративные сервисы", "Системы видеосвязи", "Видео конференц связь", get_User_By_Ldap.user.ldap.ToString(), "Требуется помощь с настройкой ВКС", "Требуется помощь с настройкой ВКС. Создано при помощи терминала электронной очереди", 90);
                bool d = false;
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
                done = new popup_window("Спасибо, " + get_User_By_Ldap.user.fio.Split(' ')[0] + "!" + "\n" + req.CaseNumber.Substring(3), "Статус заявки ты можешь отследить на электронном табло", "", "Завершить работу", Visibility.Hidden, "done");
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

        private void uz_Click(object sender, RoutedEventArgs e)
        {
            get_user_by_ldap2 get_User_By_Ldap = new get_user_by_ldap2();
            get_User_By_Ldap.ShowDialog();

            if (get_User_By_Ldap.DialogResult == true)
            {
                req_class req = new req_class("Корпоративные сервисы", "Рабочее место", "Проблемы с рабочим местом в ЦО", get_User_By_Ldap.user.ldap.ToString(), "Проблема с учетной записью", "Проблема с учетной записью. Создано при помощи терминала электронной очереди", 60);
                bool d = false;
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
                done = new popup_window("Спасибо, " + get_User_By_Ldap.user.fio.Split(' ')[0] + "!" + "\n" + req.CaseNumber.Substring(3), "Статус заявки ты можешь отследить на электронном табло", "", "Завершить работу", Visibility.Hidden, "done");
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
}
