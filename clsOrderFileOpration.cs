using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class clsOrderFileOpration
{
    const string _filename = "OrderFile.txt";
    static private void _saveneworder(clsOrder order)
    {
        using (var file = new StreamWriter(_filename, true))
        {
            file.WriteLine(order.CustomerName+ "#//#"+ order.OrderId + "#//#" + order.ItemId + "#//#" + order.ItemName + "#//#" + order.ItemPrice + "#//#" + order.TotalPrice+ "#//#"+ DateTime.Now);
        }

        Console.WriteLine("Item Save successfully");

    }
    static private List<clsOrder>_readallorder()
    {
        List<clsOrder> orders = new List<clsOrder>();

        using (var file = new StreamReader(_filename))
        {
            string line;

            while ((line = file.ReadLine()) != null)
            {
                var part = line.Split("#//#");

                clsOrder order = new clsOrder();

                order.CustomerName = part[0];
                order.OrderId =int.Parse( part[1]);
                order.ItemId = int.Parse(part[2]);
                order.ItemName = part[3];
                order.ItemPrice = double.Parse(part[4]);
                order.TotalPrice = double.Parse(part[5]);
                order.OrderDate =Convert.ToDateTime( part[6]);
                orders.Add(order);
            }
        }

        return orders;
    }
    private static void _saveAllOrder(List<clsOrder> Orders)
    {
        using (var writer = new StreamWriter(_filename, false))
        {
            foreach (var order in Orders)
            {
                string line = order.CustomerName + "#//#" + order.OrderId + "#//#" + order.ItemId + "#//#" + order.ItemName + "#//#" + order.ItemPrice + "#//#" + order.TotalPrice + "#//#" + DateTime.Now;
                writer.WriteLine(line);
            }
        }
    }
    static private void _deletorder(int orderId)
    {
        var ordres = _readallorder();
        clsOrder OrderDelet = null;
        foreach (var order in ordres)
        {
            if(order.OrderId == orderId)
            {
                OrderDelet = order;
                break;
            }

        }
        if (OrderDelet == null)
        {
            Console.WriteLine("ID Not Found !. ");
            return;
        }
       ordres.Remove(OrderDelet);
        Console.WriteLine("Order Deleted successfully..");

        _saveAllOrder(ordres);
    }
    static public void SaveNewOrder(clsOrder order)
    {
        _saveneworder(order);
    }
    static public List<clsOrder> ReadAllOrders()
    {
        return _readallorder();
    }
    static public void DeletOrder(int Id)
    {
        _deletorder(Id);
    }
}

