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

namespace МагазинчикУДома
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string pas1 = "";
        private void CheckClicl(object sender, RoutedEventArgs e)
        {
            if (ch.IsChecked == true)
            {
                pasText.Text = pasBoz.Password;
                pasBoz.Visibility = Visibility.Collapsed;
                pasText.Visibility = Visibility.Visible;
            }
            else
            {
                pasBoz.Password = pasText.Text;
                pasBoz.Visibility = Visibility.Visible;
                pasText.Visibility = Visibility.Collapsed;
            }
        }

        public int s = 0;
        private void Next(object sender, RoutedEventArgs e)
        {
            if(ch.IsChecked == true)
            {
                pas1 = pasText.Text;
            }
            else
            {
                pas1 = pasBoz.Password;
            }
            if(log.Text.Trim() != "" && pas1.Trim() != "")
            {
                var Us = App.DB.user.Where(p => p.login == log.Text && p.password == pas1).FirstOrDefault();
                if (Us != null)
                {
                    App.usi = Us;
                    Wi2 wi2 = new Wi2();
                    wi2.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("ПОльзоватл не найден");
                    s += 1;

                }
            }
            else
            {
                MessageBox.Show("Не заполнены поля");
                s += 1;
            }
            if(s == 3)
            {
                capch();
                Nex.IsEnabled = false;

            }
        }

        public void capch()
        {
            capchaN.Text = Capcha.NewCapcha();
            capchaN.Visibility = Visibility.Visible;
            Mucapcha.Visibility = Visibility.Visible;
            ButtomCapcha.Visibility = Visibility.Visible;
           
        }

        private void CapchaClick(object sender, RoutedEventArgs e)
        {
            if (capchaN.Text == Mucapcha.Text)
            {
                capchaN.Visibility = Visibility.Hidden;
                Mucapcha.Visibility = Visibility.Hidden;
                ButtomCapcha.Visibility = Visibility.Hidden;
                Nex.IsEnabled = true;
                s = 0;
            }
            else
            {
                MessageBox.Show("Ошибка ввода капчи");
                capchaN.Text = Capcha.NewCapcha();

            }
        }
    }
}
