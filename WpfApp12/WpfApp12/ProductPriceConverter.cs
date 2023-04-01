using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp12
{
    internal class ProductPriceConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<Order_product> items = value as IEnumerable<Order_product>;
            decimal l = 0;           
            foreach (var p in items)
            {

                l = (decimal)(l + p.price);



               

            }


            return l;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
