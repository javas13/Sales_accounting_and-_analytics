using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp12
{
    internal class ProdPointConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
             IEnumerable<Product_point> items = value as IEnumerable<Product_point>;
            string prod = "";
            var k = items.FirstOrDefault();
            foreach (var p in items)
            {
                if (p != k)
                {
                    prod = prod + p.Point.name;
                    prod = prod + "(" + p.Point.address + ")";
                    prod = prod + " - " + p.price + " руб. ";
                }
                else
                {
                    prod = prod + p.Point.name;
                    prod = prod + "(" + p.Point.address + ")";
                    prod = prod + " - " + p.price + " руб., ";
                }
                
               





            }


            return prod;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
