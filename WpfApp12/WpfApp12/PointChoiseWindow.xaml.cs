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

namespace WpfApp12
{
    /// <summary>
    /// Логика взаимодействия для PointChoiseWindow.xaml
    /// </summary>
    public partial class PointChoiseWindow : Window
    {
        public PointChoiseWindow(LoginPage p)
        {
            InitializeComponent();
            pointLst.ItemsSource = App.db.Points.ToList();
            if (App.currentUser.role_id != 2)
            {
                statBtn.Visibility = Visibility.Collapsed;    
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginPage.PointChoiseMethod();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(pointLst.SelectedItem == null)
            {
                MessageBox.Show("Сначала выберите предприятие");
            }
            else
            {
                App.currentPoint = pointLst.SelectedItem as Point;
                this.Close();
                LoginPage.PointChoiseMethod();
            }
        }
    }
}
