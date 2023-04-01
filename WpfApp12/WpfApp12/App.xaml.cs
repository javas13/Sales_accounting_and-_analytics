using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApp12
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    /// 
    
    public partial class App : Application
    {
        public static WorkshopEntities10 db = new WorkshopEntities10();
        public static Point currentPoint;
        public static User currentUser;
        public static LoginPage loginPage;
        private static List<ProductForPie> productForPies = new List<ProductForPie>();
        private static List<CategoryAmountForPie> categoryAmountForPies = new List<CategoryAmountForPie>();
        private static List<DateSaleForDynamicPage> dateAmountForLine = new List<DateSaleForDynamicPage>();
        public static Product redatctProd;
        
        internal static List<DateSaleForDynamicPage> DateAmountForLine { get => dateAmountForLine; set => dateAmountForLine = value;}
        internal static List<ProductForPie> ProductForPies { get => productForPies; set => productForPies = value; }
        internal static List<CategoryAmountForPie> CategoryAmountForPies { get => categoryAmountForPies; set => categoryAmountForPies = value;}
        //IEnumerable<Product> resultOfFind = (from product in db.Products  select product);
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }

    }
    
}
