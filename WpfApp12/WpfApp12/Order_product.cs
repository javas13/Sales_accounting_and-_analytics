//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp12
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_product
    {
        public int id { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> order_id { get; set; }
        public Nullable<int> amount { get; set; }
        public Nullable<decimal> price { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
