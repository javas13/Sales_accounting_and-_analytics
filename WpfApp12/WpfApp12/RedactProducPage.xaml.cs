using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для RedactProducPage.xaml
    /// </summary>
    public partial class RedactProducPage : Page
    {
        //Если значение 0, то будет редактирование, если 1 будет добавление
        int redactMode = 0;
        Point selectedPnt;
        ObservableCollection<MyProdPoint> myProdPoints = new ObservableCollection<MyProdPoint>();
        public RedactProducPage()
        {
            InitializeComponent();
            TypeCmb.ItemsSource = App.db.Types.ToList();
            PointCmb.ItemsSource = App.db.Points.ToList();
            ProductNameTxt.Text = App.redatctProd.name;
            
            foreach(var p in App.redatctProd.Product_point)
            {
               MyProdPoint myProd = new MyProdPoint()
               {
                   Price = Convert.ToInt32(p.price),
                   Product = p.Product,
                   Point = p.Point
               };
                myProdPoints.Add(myProd);
            }
            NadoLst.ItemsSource = myProdPoints;
            TypeCmb.SelectedItem = App.redatctProd.Type;
          
        }

        private void NadoLst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(NadoLst.SelectedItem != null)
            {

                var p = NadoLst.SelectedItem as MyProdPoint;
                selectedPnt = p.point;
                PriceProdTxt.Text = p.Price.ToString();
                PointCmb.SelectedItem = p.Point;

            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(myProdPoints.Count() == App.db.Points.Count())
            {
                MessageBox.Show("Вы уже добавили товар на все предприятия, которые у вас есть!");
            }
            else
            {
                redactMode = 1;
                PriceProdTxt.Text = "";
                PointCmb.SelectedItem = null;
                OtmenaBtn.Visibility = Visibility.Visible;
                NadoLst.Visibility = Visibility.Collapsed;
                addBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(redactMode == 0)
            {
                if (PointCmb.SelectedItem == null || PriceProdTxt.Text.Length < 1)
                {
                    MessageBox.Show("Сначала введите все данные!");
                }
                else
                {
                    var slctPoint = PointCmb.SelectedItem as Point;
                    var p1 = from prodP in myProdPoints where prodP.Point.id == slctPoint.id select prodP.Point;
                    if (p1.Count() == 0)
                    {
                        if (selectedPnt == slctPoint)
                        {

                        }
                        var p2 = NadoLst.SelectedItem as MyProdPoint;
                        var p3 = (from x in myProdPoints where x.Point.id == p2.Point.id select x).FirstOrDefault();
                        p3.Price = Convert.ToInt32(PriceProdTxt.Text);
                        p3.Point = PointCmb.SelectedItem as Point;
                    }
                    else
                    {
                        MessageBox.Show("На этом предприятии уже продается данный продукт");
                    }
                }
            }
            else if(redactMode == 1)
            {

                if (PointCmb.SelectedItem == null || PriceProdTxt.Text.Length < 1)
                {
                    MessageBox.Show("Сначала введите все данные!");
                }
                else
                {
                    var slctPoint = PointCmb.SelectedItem as Point;
                    var p1 = from prodP in myProdPoints where prodP.Point.id == slctPoint.id select prodP.Point;
                    if (p1.Count() == 0)
                    {
                        MyProdPoint p = new MyProdPoint()
                        {
                            Point = PointCmb.SelectedItem as Point,
                            Price = Convert.ToInt32(PriceProdTxt.Text),
                            Product = App.redatctProd

                        };
                        myProdPoints.Add(p);
                        NadoLst.SelectedItem = p;
                        NadoLst.Visibility = Visibility.Visible;
                        addBtn.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("На этом предприятии уже продается данный продукт");
                    }
                }
            }
            else
            {
                MessageBox.Show("dada");
            }
          
           

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NadoLst.Visibility = Visibility.Visible;
            addBtn.Visibility = Visibility.Visible;
            OtmenaBtn.Visibility = Visibility.Collapsed;
            redactMode = 0;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
