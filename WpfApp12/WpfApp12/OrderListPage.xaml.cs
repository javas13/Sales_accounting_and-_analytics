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
    /// Логика взаимодействия для OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page
    {
        public OrderListPage()
        {
            InitializeComponent();
            if (App.currentUser.role_id != 2)
            {
                var p = from ord in App.db.Orders where ord.user_id == App.currentUser.id select ord;
                orderlistbox.ItemsSource = p.ToList();
            }
            else
            {
                orderlistbox.ItemsSource = App.db.Orders.ToList();
            }
            
            kolvo.Text = App.db.Orders.Count().ToString();    
        }

        private void poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (poisktxt.Text != "Найти")
            //{

              
            //    orderlistbox.ItemsSource = .ToList();
            //}
        }

        private void poisktxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (poisktxt.Text == "Найти")
            {
                poisktxt.Text = "";
                poisktxt.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF145069");

            }
        }

        private void poisktxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (poisktxt.Text == "")
            {
                poisktxt.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Gray");
                poisktxt.Text = "Найти";

            }
        }
    }
}
