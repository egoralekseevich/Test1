using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Windows.Threading;


namespace TimeEllipse
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowInTaskbar = false;
            Autorun(true, Assembly.GetExecutingAssembly().Location);
          
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private bool Autorun(bool set,string path)
        {
            const string name = "run";
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFWARE\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if(set)
                {
                    key.SetValue(name, path);
                }
                else
                {
                    key.DeleteValue(name);
                    key.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            webbrowser SI = new webbrowser();

            SI.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }
    }
}

