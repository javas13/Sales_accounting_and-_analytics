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
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfApp12
{
    /// <summary>
    /// Логика взаимодействия для DynamicPage.xaml
    /// </summary>
    public partial class DynamicPage : Page
    {
        public DynamicPage()
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
            points.Insert(0, poin);
            storeCmb.ItemsSource = points;
            DateTime curdate = DateTime.Now;
            curdate = curdate.AddDays(-30);
            datepic.SelectedDate = curdate;
            curdate = curdate.AddDays(60);
            datepic2.SelectedDate = curdate;

            var p = from ordPoint in App.db.Order_product where ordPoint.Order.date > datepic.SelectedDate && ordPoint.Order.date < datepic2.SelectedDate select ordPoint;
            foreach (var prod in p)
            {
                string SalDat = prod.Order.date.ToString("dd.MM.yyyy");
                var lquest = (from prodLine in App.DateAmountForLine where prodLine.DateOfSale.ToString("dd.MM.yyyy") == SalDat select prodLine).FirstOrDefault();
                if (lquest == null)
                {
                    DateSaleForDynamicPage productFor = new DateSaleForDynamicPage()
                    {
                        DateOfSale = prod.Order.date
                    };
                    App.DateAmountForLine.Add(productFor);
                }
            }
            foreach (var ln in p)
            {
                var ln1 = from prod3 in App.DateAmountForLine where prod3.DateOfSale.ToString("dd.MM.yyyy") == ln.Order.date.ToString("dd.MM.yyyy") select prod3;
                foreach (var p6 in ln1)
                {
                    var g = ln1.FirstOrDefault();
                    var lk = Convert.ToInt32(ln.amount);
                    p6.AmountOfSale = p6.AmountOfSale + lk;
                }
            }
            //App.DateAmountForLine = App.DateAmountForLine.OrderBy(x => x.DateOfSale).ToList();
            //nadolst.ItemsSource = App.DateAmountForLine;
            //foreach (var prod in App.DateAmountForLine.OrderBy(x => x.DateOfSale))
            //{
            //    SeriesCollection.Add(new LineSeries { Title = "Количество продаж", Values = new ChartValues<double> { prod.AmountOfSale } });
            //    Labels.Add(prod.DateOfSale.ToString("dd.MM.yyyy"));

            //}
            //foreach (var prod in App.DateAmountForLine.OrderBy(x => x.DateOfSale))
            //{
            //    SeriesCollection.Add(new LineSeries { Title = "Количество продаж", Values = new ChartValues<double> { prod.AmountOfSale } });
            //    Labels.Add(prod.DateOfSale.ToString("dd.MM.yyyy"));

            //}
            //SeriesCollection.Add(new LineSeries { Title = "Количество продаж", Values = App.DateAmountForLine})
          
            foreach (var prod in App.DateAmountForLine.OrderBy(x => x.DateOfSale))
            {
                chartValues.Add(prod.AmountOfSale);
                //    lineSeries.Values.Add(6);
                Labels.Add(prod.DateOfSale.ToString("dd.MM.yyyy"));
                //new LineSeries
                //foreach(var pr1 in App.DateAmountForLine.OrderBy(x => x.DateOfSale))
                //{
                //    prod.Values.Add(pr1.AmountOfSale);

                //}

            }
            LineSeries lineSeries = new LineSeries()
            {
                Title = "Количество продаж",
                Values = chartValues
            };
            SeriesCollection.Add(lineSeries);

            //SeriesCollection = new SeriesCollection
            //{
            //    new LineSeries
            //    {
            //        Title = "Series 1",
            //        Values = (IChartValues)App.DateAmountForLine,
            //    }

            //};

            //Labels = new[] { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н" };
            //YFormatter = value => value.ToString("C");

            //modifying the series collection will animate and update the chart


            //modifying any series values will also animate and update the chart


            DataContext = this;
        }
        ChartValues<int> chartValues = new ChartValues<int>();
        public SeriesCollection SeriesCollection { get; set; } = new SeriesCollection();
        public SeriesCollection Labels1 { get; set; } = new SeriesCollection(); 
        public List<string> Labels { get; set;} = new List<string>();
        public Func<double, string> YFormatter { get; set; }
        //LineSeries lineSeries = new LineSeries()
        //{
        //    Title = "Количесвто продаж",
        //    Values = new ChartValues<int> { 2}
        //};
    }
    }

