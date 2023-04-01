using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WpfApp12
{
    internal class MyProdPoint : INotifyPropertyChanged
    {
        public Product product;
        public Point point;
        public int price;
        public Product Product { get; set; }
        public Point Point { get { return point; } set { OnPropertyChanged("Point");  point = value; } }
        public int Price { get { return price; } set { OnPropertyChanged("Price"); price = value; } }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }   
        
       
    }

