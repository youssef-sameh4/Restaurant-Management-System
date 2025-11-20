using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
   class clsOrder
   {
    static int _count =0 ;
            public string CustomerName { get; set; }
            public int OrderId { get; set; }
            public int ItemId { get; set; }
            public string ItemName { get; set; }
            public double ItemPrice { get; set; }
            public double TotalPrice { get; set; }
            public DateTime OrderDate { get; set; }
    public clsOrder()
    {
        _count++;
        OrderId = _count ;
       
    }
}

    
