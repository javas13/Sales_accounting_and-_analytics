using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// Логика взаимодействия для OrderAddPage.xaml
    /// </summary>
    public partial class OrderAddPage : Page
    {
        ObservableCollection<ProductOrd> selectedProductsList = new ObservableCollection<ProductOrd>();
        int count = 0;
        public OrderAddPage()
        {
            InitializeComponent();
            var prodFromBd = from prodP in App.db.Product_point where prodP.point_id == App.currentPoint.id select prodP;
            productListbox.ItemsSource = prodFromBd.ToList();
            productListbox2.ItemsSource = selectedProductsList;
            productListbox.SetValue(
            ScrollViewer.HorizontalScrollBarVisibilityProperty,
            ScrollBarVisibility.Disabled);
            productListbox2.SetValue(
            ScrollViewer.HorizontalScrollBarVisibilityProperty,
            ScrollBarVisibility.Disabled);
            HourCmb.ItemsSource = TimeList.HourList.ToList();
            MinuteCmb.ItemsSource = TimeList.MinuteList.ToList();
            
            OnClickCommand = new ActionCommand(x =>
            {
                
                var currentItem = x as ProductOrd;
                selectedProductsList.Remove(currentItem);
                count = count - 1;
                productListbox2.ItemsSource = selectedProductsList;
                if (count == 0)
                {
                    dateStack.Visibility = Visibility.Hidden;
                }


            });
            PlusCommand = new ActionCommand(x =>
            {
                
                
                ProductOrd p = x as ProductOrd;
                p.Count = p.Count + 1;
                if (p.count == 10)
                {
                    foreach (var rectangle in App.FindVisualChildren<Button>(this))
                    {
                        if (rectangle.Name == "d")
                        {
                            rectangle.Width = 20;
                            rectangle.Height = 20;
                            rectangle.Margin = new Thickness(2, 0, 0, 0);

                        }
                    }
                }
                //productListbox2.ItemsSource = selectedProductsList.ToList();
            });
            MinusCommand = new ActionCommand(x =>
            {
                
                var p = x as ProductOrd;
                
                if (p.Count > 1)
                {
                    p.Count = p.Count - 1;
                    if (p.count == 9)
                    {
                        foreach (var rectangle in App.FindVisualChildren<Button>(this))
                        {
                            if (rectangle.Name == "d")
                            {
                                rectangle.Width = 25;
                                rectangle.Height = 25;
                                rectangle.Margin = new Thickness(7, 0, 0, 0);


                            }
                        } 
                    }
               
                }
                
            });


        }

        private void Logintxtbox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Findtxtbox.Text == "Найти")
            {
                Findtxtbox.Text = "";
                Findtxtbox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF145069");

            }
        }

        private void Findtxtbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Findtxtbox.Text == "")
            {
                Findtxtbox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Gray");
                Findtxtbox.Text = "Найти";

            }
        }

        private void Findtxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Findtxtbox.Text != "Найти")
            {

                var resultOfFind = from product in App.db.Product_point where product.Product.name.Contains(Findtxtbox.Text) select product;
                productListbox.ItemsSource = resultOfFind.ToList();
            }

        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (count == 0)
            {   
                

                if (productListbox.SelectedItem == null)
                {
                    MessageBox.Show("Элемент не выбран!");
                }
                else
                {
                    dateStack.Visibility = Visibility.Visible;    
                    DateTime currentTime = DateTime.Now;
                    datepic.SelectedDate = currentTime;
                    var pHour = (from hor in TimeList.HourList where hor.Name == currentTime.ToString("HH") select hor).FirstOrDefault();
                    var pMinute = (from min in TimeList.MinuteList where min.Name == currentTime.ToString("mm") select min).FirstOrDefault();
                    HourCmb.SelectedItem = pHour;
                    MinuteCmb.SelectedItem = pMinute;                  
                    var selPr = productListbox.SelectedItem as Product_point;
                    var p = (from prod in selectedProductsList where selPr.id == prod.ID select prod).Count();
                    if (p == 0)
                    {
                        count = count + 1;
                        var newProd = new ProductOrd
                        {
                            Name = selPr.Product.name,
                            ID = selPr.product_id,
                     
                            Price = Convert.ToInt32(selPr.price)

                        };
                        selectedProductsList.Add(newProd);
                        productListbox2.ItemsSource = selectedProductsList.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Этот элемент уже выбран!");
                    }



                }
            }
            else if (count > 0)
            {
                if (productListbox.SelectedItem == null)
                {
                    MessageBox.Show("Элемент не выбран!");
                }
                else
                {
                    
                    var selPr = productListbox.SelectedItem as Product_point;
                    var p = (from prod in selectedProductsList where selPr.Product.id == prod.ID select prod).Count();
                    if (p == 0)
                    {
                        count = count + 1;
                        var newProd = new ProductOrd
                        {
                            Name = selPr.Product.name,
                            ID = selPr.Product.id,
                        
                            Price = Convert.ToInt32(selPr.price)

                        };
                        selectedProductsList.Add(newProd);
                        productListbox2.ItemsSource = selectedProductsList.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Этот элемент уже выбран!");
                    }
                }

            }
        }
            public ICommand OnClickCommand { get; set; }
        public ICommand PlusCommand { get; set; }
        public ICommand MinusCommand { get; set; }
        public class ActionCommand : ICommand
        {
            private readonly Action<object> Action;
            private readonly Predicate<object> Predicate;

            public ActionCommand(Action<object> action) : this(action, x => true)
            {

            }
            public ActionCommand(Action<object> action, Predicate<object> predicate)
            {
                Action = action;
                Predicate = predicate;
            }

            public bool CanExecute(object parameter)
            {
                return Predicate(parameter);
            }
            public void Execute(object parameter)
            {
                Action(parameter);
            }

            //These lines are here to tie into WPF-s Can execute changed pipeline. Don't worry about it.
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    CommandManager.RequerySuggested += value;
                }
                remove
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        private void countProductTxt_TextInput(object sender, TextCompositionEventArgs e)
        {
            var p = sender as TextBlock;
            foreach (var rectangle in App.FindVisualChildren<Rectangle>(this))
            {
                if (rectangle.Name == "closeBtn")
                {
                    if (p.Text == "10")
                    {
                        rectangle.Height = 15;
                        rectangle.Width = 15;
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var pHour = HourCmb.SelectedItem as HourCustom;
            var pMinute = MinuteCmb.SelectedItem as MinuteCustom;
            var FinalDate = datetimetxt.Text + " " + pHour.Name + ":" + pMinute.Name;
            DateTime Closetime = DateTime.ParseExact(FinalDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            //sydatxt.Text = Closetime.ToString("dd.MM.yyyy HH:mm");
            Order order1 = new Order()
            {
                date = Closetime,
                point_id = App.currentPoint.id,
                user_id = App.currentUser.id,
            };
            App.db.Orders.Add(order1);
            foreach (var p in selectedProductsList)
            {
                var prodCountSale = (from prod in App.db.Products where prod.id == p.ID select prod).FirstOrDefault();               
                var prodPointQuest = (from prodPoint in App.db.Product_point where  prodPoint.product_id == p.ID select prodPoint).FirstOrDefault();
             
                Order_product ordnw = new Order_product()
                {
                   
                    order_id = order1.id,
                    price = p.Price,
                    amount = p.Count,
                    product_id = p.ID,
                    
                    
                };
                App.db.Order_product.Add(ordnw);
                
            }
            App.db.SaveChanges();
            MessageBox.Show("Успешное сохранение!");
            NavigationService.Navigate(new OrderAddPage());
           
        }
    }
    }


