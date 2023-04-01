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

namespace WpfApp12
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
       
        public LoginPage()
        {
            InitializeComponent();
            App.loginPage = this;

        }

        private void Logintxtbox_GotFocus(object sender, RoutedEventArgs e)
        {

            if (Logintxtbox.Text == "Логин")
            {
                Logintxtbox.Text = "";
                Logintxtbox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
        }

        private void Logintxtbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Logintxtbox.Text == "")
            {
                Logintxtbox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Gray");
                Logintxtbox.Text = "Логин";

            }
        }

       

      

        private void Grid_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textboxpass.Text == "Пароль")
            {
                textboxpass.Visibility = Visibility.Collapsed;
                passwordboxx.Focus();

            }
        }

        private void Grid_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordboxx.Password == "")
            {
                textboxpass.Visibility = Visibility.Visible;
            }
        }

        private void loginbutton122_Click(object sender, RoutedEventArgs e)
        {
            var p = (from Usr in App.db.Users where Usr.login == Logintxtbox.Text && Usr.password == passwordboxx.Password.ToString() select Usr).FirstOrDefault();
            if(p == null)
            {
                MessageBox.Show("Данные введены не верно, попробуйте еще раз!");

            }
            else
            {
                if (p.role_id == 1)
                {
                    MessageBox.Show("Удачного рабочего дня и побольше денег! ( ˘⌣˘)♡(˘⌣˘ )");
                    App.currentUser = p;
                    PointChoiseWindow pointChoiseWindow = new PointChoiseWindow(App.loginPage);
                    pointChoiseWindow.ShowDialog(); 
                    //NavigationService.Navigate(new MainPage());
                }
                else if (p.role_id == 2)
                {
                    MessageBox.Show("Добро пожаловать хозяин!");
                    App.currentUser = p;
                    PointChoiseWindow pointChoiseWindow = new PointChoiseWindow(App.loginPage);
                    pointChoiseWindow.ShowDialog();
                    //NavigationService.Navigate(new MainPage());
                }
            }
           

        }
        public static void PointChoiseMethod()
        {
             App.loginPage.NavigationService.Navigate(new MainPage());
        }
    }
}
