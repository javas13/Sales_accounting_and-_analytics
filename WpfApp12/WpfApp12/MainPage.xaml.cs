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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            if(App.currentUser.role_id == 2)
            {
                StatButton.Visibility = Visibility.Visible;
            }
            secondFrame.Content = new BusinessControlPage();
            
          
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.currentUser = null;
            App.ProductForPies.Clear();
            NavigationService.Navigate(new LoginPage());
        }

        private void StatButton_Click(object sender, RoutedEventArgs e)
        {
            secondFrame.Content = new StatsPage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            secondFrame.Content = new OrderListPage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            secondFrame.Content = new OrderAddPage();
        }

        private void RedactButton_Click(object sender, RoutedEventArgs e)
        {
            secondFrame.Content = new BusinessControlPage();
        }
    }
}
