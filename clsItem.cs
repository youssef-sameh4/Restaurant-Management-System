using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


     class clsItem
    {
      private int _id;
    private string _category;
    private double _price;
     private int _quantity;
      public int Id {
        get
        { 
            return _id;
        } 
        set 
        {
          if(value < 0)
            {
                throw new Exception(message: "The number must be greater than zero.");
            }

            _id = value;
        }
    
    }
       public string Name { get; set; }
      public string Category
    {
        get;


        set
        ;
    }
      public double Price {
        get
        {
            return _price;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(message: "The number must be greater than zero.");
            }

            _price = value;
        }
    }
      public int Quantity {
        get
        {
            return _quantity;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(message: "The number must be greater than zero.") ;
            }

            _quantity = value;
        }
    }

     
    }

