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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Windows.Shapes;

namespace WpfApp12
{
    /// <summary>
    /// Логика взаимодействия для PieChartPage.xaml
    /// </summary>
    public partial class PieChartPage : Page
    {
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
        public PieChartPage()
        {
            InitializeComponent();
            
            List<Point> points = new List<Point>();  
            Point poin = new Point()
            {
                name = "Все"
            };
            foreach (var point2 in App.db.Points)
            {
               points.Add(point2);
            }
            points.Insert(0,poin);
            storeCmb.ItemsSource = points;
            DateTime curdate = DateTime.Now;
            curdate = curdate.AddDays(-30);
            datepic.SelectedDate = curdate;
            curdate = curdate.AddDays(30);
            datepic2.SelectedDate = curdate;
           
            
            var p = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate select ordPoint;


            foreach (var prod in p)
            {

                var lquest = (from prodPie in App.ProductForPies where prodPie.ProductId.id == prod.product_id select prodPie).FirstOrDefault();
                if (lquest == null)
                {
                    ProductForPie productFor = new ProductForPie()
                    {
                        ProductId = prod.Product
                    };
                    App.ProductForPies.Add(productFor);
                }
            }
            foreach (var ln in p)
            {
                var ln1 = from prod3 in App.ProductForPies where prod3.ProductId.id == ln.product_id select prod3;
                foreach (var p6 in ln1)
                {
                    var g = ln1.FirstOrDefault();
                    var lk = Convert.ToInt32(ln.amount);
                    p6.Amount = p6.Amount + lk;
                }



            }           
            foreach (var p5 in App.ProductForPies)
            {
                SeriesCollection1.Add(new PieSeries() { Title = p5.ProductId.name, Values = new ChartValues<ObservableValue> { new ObservableValue(p5.Amount) }, DataLabels = true });
            }
            DataContext = this;
            


        }
        public SeriesCollection SeriesCollection1 { get; set; } = new SeriesCollection();

        private void storeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var choisenStore = storeCmb.SelectedItem as Point;
            //if (storeCmb.SelectedIndex == 0 && productCmb.SelectedIndex == 1)
            //{
            //    App.CategoryAmountForPies.Clear();
            //    App.ProductForPies.Clear();
            //    var p7 = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate select ordPoint;

            //    foreach (var prod in p7)
            //    {

            //        var lquest = (from prodPie in App.ProductForPies where prodPie.ProductId.id == prod.product_id select prodPie).FirstOrDefault();
            //        if (lquest == null)
            //        {
            //            ProductForPie productFor = new ProductForPie()
            //            {
            //                ProductId = prod.Product
            //            };
            //            App.ProductForPies.Add(productFor);
            //        }
            //    }
            //    foreach (var ln in p7)
            //    {
            //        var ln1 = from prod3 in App.ProductForPies where prod3.ProductId.id == ln.product_id select prod3;
            //        foreach (var p6 in ln1)
            //        {
            //            var g = ln1.FirstOrDefault();
            //            var lk = Convert.ToInt32(ln.amount);
            //            p6.Amount = p6.Amount + lk;
            //        }



            //    }
            //    SeriesCollection1.Clear();

            //    foreach (var p5 in App.ProductForPies)
            //    {
            //        SeriesCollection1.Add(new PieSeries() { Title = p5.ProductId.name, Values = new ChartValues<ObservableValue> { new ObservableValue(p5.Amount) }, DataLabels = true });
            //    }
            //    DataContext = this;
            //}
            //else if (storeCmb.SelectedIndex != 0 && productCmb.SelectedIndex == 1)
            //{
            //    App.CategoryAmountForPies.Clear();
            //    App.ProductForPies.Clear();
            //    var p = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate && ordPoint.Order.Point.id == choisenStore.id select ordPoint;

            //    foreach (var prod in p)
            //    {

            //        var lquest = (from prodPie in App.ProductForPies where prodPie.ProductId.id == prod.product_id select prodPie).FirstOrDefault();
            //        if (lquest == null)
            //        {
            //            ProductForPie productFor = new ProductForPie()
            //            {
            //                ProductId = prod.Product
            //            };
            //            App.ProductForPies.Add(productFor);
            //        }
            //    }
            //    foreach (var ln in p)
            //    {
            //        var ln1 = from prod3 in App.ProductForPies where prod3.ProductId.id == ln.product_id select prod3;
            //        foreach (var p6 in ln1)
            //        {
            //            var g = ln1.FirstOrDefault();
            //            var lk = Convert.ToInt32(ln.amount);
            //            p6.Amount = p6.Amount + lk;
            //        }



            //    }
            //    SeriesCollection1.Clear();

            //    foreach (var p5 in App.ProductForPies)
            //    {
            //        SeriesCollection1.Add(new PieSeries() { Title = p5.ProductId.name, Values = new ChartValues<ObservableValue> { new ObservableValue(p5.Amount) }, DataLabels = true });
            //    }
            //    DataContext = this;
            //}
            //else if (storeCmb.SelectedIndex == 0 && productCmb.SelectedIndex == 0)
            //{
            //    App.CategoryAmountForPies.Clear();
            //    App.ProductForPies.Clear();
            //    var p7 = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate select ordPoint;

            //    foreach (var prod in p7)
            //    {

            //        var lquest = (from prodPie in App.CategoryAmountForPies where prodPie.TypeId == prod.Product.Type select prodPie).FirstOrDefault();
            //        if (lquest == null)
            //        {
            //            CategoryAmountForPie productFor = new CategoryAmountForPie()
            //            {
            //                TypeId = prod.Product.Type
            //            };
            //            App.CategoryAmountForPies.Add(productFor);
            //        }
            //    }
            //    foreach (var ln in p7)
            //    {
            //        var ln1 = from prod3 in App.CategoryAmountForPies where prod3.TypeId.id == ln.Product.type_id select prod3;
            //        foreach (var p6 in ln1)
            //        {
            //            var g = ln1.FirstOrDefault();
            //            var lk = Convert.ToInt32(ln.amount);
            //            p6.Amount = p6.Amount + lk;
            //        }



            //    }
            //    SeriesCollection1.Clear();

            //    foreach (var p5 in App.CategoryAmountForPies)
            //    {
            //        SeriesCollection1.Add(new PieSeries() { Title = p5.TypeId.name, Values = new ChartValues<ObservableValue> { new ObservableValue(p5.Amount) }, DataLabels = true });
            //    }
            //    DataContext = this;
            //}
            //else if (storeCmb.SelectedIndex != 0 && productCmb.SelectedIndex == 0)
            //{
            //    App.CategoryAmountForPies.Clear();
            //    App.ProductForPies.Clear();
            //    var p7 = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate && ordPoint.Order.point_id == choisenStore.id select ordPoint;

            //    foreach (var prod in p7)
            //    {

            //        var lquest = (from prodPie in App.CategoryAmountForPies where prodPie.TypeId == prod.Product.Type select prodPie).FirstOrDefault();
            //        if (lquest == null)
            //        {
            //            CategoryAmountForPie productFor = new CategoryAmountForPie()
            //            {
            //                TypeId = prod.Product.Type
            //            };
            //            App.CategoryAmountForPies.Add(productFor);
            //        }
            //    }
            //    foreach (var ln in p7)
            //    {
            //        var ln1 = from prod3 in App.CategoryAmountForPies where prod3.TypeId.id == ln.Product.type_id select prod3;
            //        foreach (var p6 in ln1)
            //        {
            //            var g = ln1.FirstOrDefault();
            //            var lk = Convert.ToInt32(ln.amount);
            //            p6.Amount = p6.Amount + lk;
            //        }



            //    }
            //    SeriesCollection1.Clear();

            //    foreach (var p5 in App.CategoryAmountForPies)
            //    {
            //        SeriesCollection1.Add(new PieSeries() { Title = p5.TypeId.name, Values = new ChartValues<ObservableValue> { new ObservableValue(p5.Amount) }, DataLabels = true });
            //    }
            //    DataContext = this;
            //}
            SortPie();

        }

        private void productCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (count3 > 0)
            {
                SortPie();
            }
            else
            {
                count3 = count3 + 1;
            }
            
        }

        private void datepic2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (count1 > 3)
            {
                //var choisenStore = storeCmb.SelectedItem as Point;
                //if (storeCmb.SelectedIndex == 0 && productCmb.SelectedIndex == 1)
                //{
                //    App.ProductForPies.Clear();
                //    var p7 = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate select ordPoint;

                //    foreach (var prod in p7)
                //    {

                //        var lquest = (from prodPie in App.ProductForPies where prodPie.ProductId.id == prod.product_id select prodPie).FirstOrDefault();
                //        if (lquest == null)
                //        {
                //            ProductForPie productFor = new ProductForPie()
                //            {
                //                ProductId = prod.Product
                //            };
                //            App.ProductForPies.Add(productFor);
                //        }
                //    }
                //    foreach (var ln in p7)
                //    {
                //        var ln1 = from prod3 in App.ProductForPies where prod3.ProductId.id == ln.product_id select prod3;
                //        foreach (var p6 in ln1)
                //        {
                //            var g = ln1.FirstOrDefault();
                //            var lk = Convert.ToInt32(ln.amount);
                //            p6.Amount = p6.Amount + lk;
                //        }



                //    }
                //    SeriesCollection1.Clear();

                //    foreach (var p5 in App.ProductForPies)
                //    {
                //        SeriesCollection1.Add(new PieSeries() { Title = p5.ProductId.name, Values = new ChartValues<ObservableValue> { new ObservableValue(p5.Amount) }, DataLabels = true });
                //    }
                //    DataContext = this;
                //}
                //else if (storeCmb.SelectedIndex != 0 && productCmb.SelectedIndex == 1)
                //{
                //    App.ProductForPies.Clear();
                //    var p = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate && ordPoint.Order.Point.id == choisenStore.id select ordPoint;

                //    foreach (var prod in p)
                //    {

                //        var lquest = (from prodPie in App.ProductForPies where prodPie.ProductId.id == prod.product_id select prodPie).FirstOrDefault();
                //        if (lquest == null)
                //        {
                //            ProductForPie productFor = new ProductForPie()
                //            {
                //                ProductId = prod.Product
                //            };
                //            App.ProductForPies.Add(productFor);
                //        }
                //    }
                //    foreach (var ln in p)
                //    {
                //        var ln1 = from prod3 in App.ProductForPies where prod3.ProductId.id == ln.product_id select prod3;
                //        foreach (var p6 in ln1)
                //        {
                //            var g = ln1.FirstOrDefault();
                //            var lk = Convert.ToInt32(ln.amount);
                //            p6.Amount = p6.Amount + lk;
                //        }



                //    }
                //    SeriesCollection1.Clear();

                //    foreach (var p5 in App.ProductForPies)
                //    {
                //        SeriesCollection1.Add(new PieSeries() { Title = p5.ProductId.name, Values = new ChartValues<ObservableValue> { new ObservableValue(p5.Amount) }, DataLabels = true });
                //    }
                //    DataContext = this;
                //}
                SortPie();
            }
            else
            {
                count1 = count1 + 1;
            }
           
           
        }

        private void datepic_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if(count2 > 3)
            {
                //var choisenStore = storeCmb.SelectedItem as Point;
                //if (storeCmb.SelectedIndex == 0 && productCmb.SelectedIndex == 1)
                //{
                //    App.ProductForPies.Clear();
                //    var p7 = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate select ordPoint;

                //    foreach (var prod in p7)
                //    {

                //        var lquest = (from prodPie in App.ProductForPies where prodPie.ProductId.id == prod.product_id select prodPie).FirstOrDefault();
                //        if (lquest == null)
                //        {
                //            ProductForPie productFor = new ProductForPie()
                //            {
                //                ProductId = prod.Product
                //            };
                //            App.ProductForPies.Add(productFor);
                //        }
                //    }
                //    foreach (var ln in p7)
                //    {
                //        var ln1 = from prod3 in App.ProductForPies where prod3.ProductId.id == ln.product_id select prod3;
                //        foreach (var p6 in ln1)
                //        {
                //            var g = ln1.FirstOrDefault();
                //            var lk = Convert.ToInt32(ln.amount);
                //            p6.Amount = p6.Amount + lk;
                //        }



                //    }
                //    SeriesCollection1.Clear();

                //    foreach (var p5 in App.ProductForPies)
                //    {
                //        SeriesCollection1.Add(new PieSeries() { Title = p5.ProductId.name, Values = new ChartValues<ObservableValue> { new ObservableValue(p5.Amount) }, DataLabels = true });
                //    }
                //    DataContext = this;
                //}
                //else if (storeCmb.SelectedIndex != 0 && productCmb.SelectedIndex == 1)
                //{
                //    App.ProductForPies.Clear();
                //    var p = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate && ordPoint.Order.Point.id == choisenStore.id select ordPoint;

                //    foreach (var prod in p)
                //    {

                //        var lquest = (from prodPie in App.ProductForPies where prodPie.ProductId.id == prod.product_id select prodPie).FirstOrDefault();
                //        if (lquest == null)
                //        {
                //            ProductForPie productFor = new ProductForPie()
                //            {
                //                ProductId = prod.Product
                //            };
                //            App.ProductForPies.Add(productFor);
                //        }
                //    }
                //    foreach (var ln in p)
                //    {
                //        var ln1 = from prod3 in App.ProductForPies where prod3.ProductId.id == ln.product_id select prod3;
                //        foreach (var p6 in ln1)
                //        {
                //            var g = ln1.FirstOrDefault();
                //            var lk = Convert.ToInt32(ln.amount);
                //            p6.Amount = p6.Amount + lk;
                //        }



                //    }
                //    SeriesCollection1.Clear();

                //    foreach (var p5 in App.ProductForPies)
                //    {
                //        SeriesCollection1.Add(new PieSeries() { Title = p5.ProductId.name, Values = new ChartValues<ObservableValue> { new ObservableValue(p5.Amount) }, DataLabels = true });
                //    }
                //    DataContext = this;
                //}
                SortPie();
            }
            else
            {
                count2 = count2 + 1;
            }
           
        }
        private void SortPie()
        {
            var choisenStore = storeCmb.SelectedItem as Point;
            if (storeCmb.SelectedIndex == 0 && productCmb.SelectedIndex == 1)
            {
                App.CategoryAmountForPies.Clear();
                App.ProductForPies.Clear();
                var p7 = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate select ordPoint;

                foreach (var prod in p7)
                {

                    var lquest = (from prodPie in App.ProductForPies where prodPie.ProductId.id == prod.product_id select prodPie).FirstOrDefault();
                    if (lquest == null)
                    {
                        ProductForPie productFor = new ProductForPie()
                        {
                            ProductId = prod.Product
                        };
                        App.ProductForPies.Add(productFor);
                    }
                }
                foreach (var ln in p7)
                {
                    var ln1 = from prod3 in App.ProductForPies where prod3.ProductId.id == ln.product_id select prod3;
                    foreach (var p6 in ln1)
                    {
                        var g = ln1.FirstOrDefault();
                        var lk = Convert.ToInt32(ln.amount);
                        p6.Amount = p6.Amount + lk;
                    }



                }
                SeriesCollection1.Clear();

                foreach (var p5 in App.ProductForPies)
                {
                    SeriesCollection1.Add(new PieSeries() { Title = p5.ProductId.name, Values = new ChartValues<ObservableValue> { new ObservableValue(p5.Amount) }, DataLabels = true });
                }
                DataContext = this;
            }
            else if (storeCmb.SelectedIndex != 0 && productCmb.SelectedIndex == 1)
            {
                App.CategoryAmountForPies.Clear();
                App.ProductForPies.Clear();
                var p = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate && ordPoint.Order.Point.id == choisenStore.id select ordPoint;

                foreach (var prod in p)
                {

                    var lquest = (from prodPie in App.ProductForPies where prodPie.ProductId.id == prod.product_id select prodPie).FirstOrDefault();
                    if (lquest == null)
                    {
                        ProductForPie productFor = new ProductForPie()
                        {
                            ProductId = prod.Product
                        };
                        App.ProductForPies.Add(productFor);
                    }
                }
                foreach (var ln in p)
                {
                    var ln1 = from prod3 in App.ProductForPies where prod3.ProductId.id == ln.product_id select prod3;
                    foreach (var p6 in ln1)
                    {
                        var g = ln1.FirstOrDefault();
                        var lk = Convert.ToInt32(ln.amount);
                        p6.Amount = p6.Amount + lk;
                    }



                }
                SeriesCollection1.Clear();

                foreach (var p5 in App.ProductForPies)
                {
                    SeriesCollection1.Add(new PieSeries() { Title = p5.ProductId.name, Values = new ChartValues<ObservableValue> { new ObservableValue(p5.Amount) }, DataLabels = true });
                }
                DataContext = this;
            }
            else if (storeCmb.SelectedIndex == 0 && productCmb.SelectedIndex == 0)
            {
                App.CategoryAmountForPies.Clear();
                App.ProductForPies.Clear();
                var p7 = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate select ordPoint;

                foreach (var prod in p7)
                {

                    var lquest = (from prodPie in App.CategoryAmountForPies where prodPie.TypeId == prod.Product.Type select prodPie).FirstOrDefault();
                    if (lquest == null)
                    {
                        CategoryAmountForPie productFor = new CategoryAmountForPie()
                        {
                            TypeId = prod.Product.Type
                        };
                        App.CategoryAmountForPies.Add(productFor);
                    }
                }
                foreach (var ln in p7)
                {
                    var ln1 = from prod3 in App.CategoryAmountForPies where prod3.TypeId.id == ln.Product.type_id select prod3;
                    foreach (var p6 in ln1)
                    {
                        var g = ln1.FirstOrDefault();
                        var lk = Convert.ToInt32(ln.amount);
                        p6.Amount = p6.Amount + lk;
                    }



                }
                SeriesCollection1.Clear();

                foreach (var p5 in App.CategoryAmountForPies)
                {
                    SeriesCollection1.Add(new PieSeries() { Title = p5.TypeId.name, Values = new ChartValues<ObservableValue> { new ObservableValue(p5.Amount) }, DataLabels = true });
                }
                DataContext = this;
            }
            else if (storeCmb.SelectedIndex != 0 && productCmb.SelectedIndex == 0)
            {
                App.CategoryAmountForPies.Clear();
                App.ProductForPies.Clear();
                var p7 = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate && ordPoint.Order.point_id == choisenStore.id select ordPoint;

                foreach (var prod in p7)
                {

                    var lquest = (from prodPie in App.CategoryAmountForPies where prodPie.TypeId == prod.Product.Type select prodPie).FirstOrDefault();
                    if (lquest == null)
                    {
                        CategoryAmountForPie productFor = new CategoryAmountForPie()
                        {
                            TypeId = prod.Product.Type
                        };
                        App.CategoryAmountForPies.Add(productFor);
                    }
                }
                foreach (var ln in p7)
                {
                    var ln1 = from prod3 in App.CategoryAmountForPies where prod3.TypeId.id == ln.Product.type_id select prod3;
                    foreach (var p6 in ln1)
                    {
                        var g = ln1.FirstOrDefault();
                        var lk = Convert.ToInt32(ln.amount);
                        p6.Amount = p6.Amount + lk;
                    }



                }
                SeriesCollection1.Clear();

                foreach (var p5 in App.CategoryAmountForPies)
                {
                    SeriesCollection1.Add(new PieSeries() { Title = p5.TypeId.name, Values = new ChartValues<ObservableValue> { new ObservableValue(p5.Amount) }, DataLabels = true });
                }
                DataContext = this;
            }
        }

       
    }
    }

    

