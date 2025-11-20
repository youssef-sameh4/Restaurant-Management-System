using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class clsCashierMenu
{
    enum EChoices { EViewAllOrders=1, ESearchOrder=2, EPaymentprocess=3, EDeleteOrder=4, BackMainMenu=5 }
    static private void _viewAllOrders()
    {
        var orders = clsOrderFileOpration.ReadAllOrders();
        Console.Clear();
        Console.WriteLine("===========================================");
        Console.WriteLine("                ORDER DETAILS              ");
        Console.WriteLine("===========================================\n\n");

        foreach (var order in orders)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine($" Customer Name : {order.CustomerName}");
            Console.WriteLine($" Order ID      : {order.OrderId}");
            Console.WriteLine($" Date          : {order.OrderDate}");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($" Item ID       : {order.ItemId}");
            Console.WriteLine($" Item Name     : {order.ItemName}");
            Console.WriteLine($" Item Price    : {order.ItemPrice} EGP");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($" TOTAL PRICE   : {order.TotalPrice} EGP");
            Console.WriteLine("===========================================\n\n");
        }

    }

    static private void _searchorder()
    {
        bool found = false;
        int ID = 0;
        var orders = clsOrderFileOpration.ReadAllOrders();
        Console.Clear();
        Console.WriteLine("===========================================");
        Console.WriteLine("                Search Order              ");
        Console.WriteLine("===========================================\n");
        Console.WriteLine("Enter ID OF Order ? ");
        ID=int.Parse(Console.ReadLine());   
        foreach (var order in orders)
        {
            if (order.OrderId == ID )
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("                ORDER DETAILS              ");
                Console.WriteLine("===========================================\n");
                found = true;
                Console.WriteLine($" Customer Name : {order.CustomerName}");
                Console.WriteLine($" Order ID      : {order.OrderId}");
                Console.WriteLine($" Date          : {order.OrderDate}");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($" Item ID       : {order.ItemId}");
                Console.WriteLine($" Item Name     : {order.ItemName}");
                Console.WriteLine($" Item Price    : {order.ItemPrice} EGP");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($" TOTAL PRICE   : {order.TotalPrice} EGP");
                Console.WriteLine("===========================================\n");
                break;
            }
        }
        if(!found)
        {
            Console.WriteLine("Order Not Found !. ");
            return;
        }


    }
    static private void _paymentprocess()
    {
        int Id;
        bool found = false;
        var orders = clsOrderFileOpration.ReadAllOrders();
        Console.Clear();
        Console.WriteLine("===========================================");
        Console.WriteLine("                Payment Process             ");
        Console.WriteLine("===========================================\n");
        Console.WriteLine("Enter ID OF Order ? ");
        Id = int.Parse(Console.ReadLine());
        foreach (var order in orders)
        {
            if (order.OrderId == Id)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("                ORDER DETAILS              ");
                Console.WriteLine("===========================================\n");
                found = true;
                Console.WriteLine($" Customer Name : {order.CustomerName}");
                Console.WriteLine($" Order ID      : {order.OrderId}");
                Console.WriteLine($" Date          : {order.OrderDate}");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($" Item ID       : {order.ItemId}");
                Console.WriteLine($" Item Name     : {order.ItemName}");
                Console.WriteLine($" Item Price    : {order.ItemPrice} EGP");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($" TOTAL PRICE   : {order.TotalPrice} EGP");
                Console.WriteLine("===========================================\n");

                Console.WriteLine();
                short paymentmethod;
                Console.WriteLine("Choose your payment method: ([1] Cash or [2] Visa )");
                paymentmethod=short.Parse(Console.ReadLine());
                if (paymentmethod == 1)
                {
                    short Amount = 0;
                    Console.WriteLine("Please enter the cost to complete the purchase.");
                    Amount = short.Parse(Console.ReadLine());

                    if (Amount == order.TotalPrice)
                    {
                        Console.WriteLine("Thank you, payment was successful");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The payment process was unsuccessful. Please enter the correct cost.");
                        break;
                    }
                }
                else if (paymentmethod == 2)
                {
                    string sarnumbervise;
                    Console.WriteLine("Please enter the Visa serial number");
                    sarnumbervise = Console.ReadLine();
                    if (sarnumbervise.Length == 12)
                    {
                        short Amount = 0;
                        Console.WriteLine("Please enter the cost to complete the purchase.");
                        Amount = short.Parse(Console.ReadLine());
                        if (Amount == order.TotalPrice)
                        {
                            Console.WriteLine("Thank you, payment was successful");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The payment process was unsuccessful. Please enter the correct cost.");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The number must consist of 12 digits.");
                    }

                }

            }
        }
        if (!found)
        {
            Console.WriteLine("Order Not Found !. ");
            return;
        }
    }
    static private void _deletorder()
    {
        int Id;
        Console.Clear();
        Console.WriteLine("===========================================");
        Console.WriteLine("                Delet Order              ");
        Console.WriteLine("===========================================\n");
        Console.WriteLine("Enter ID OF Order ? ");
        Id= int.Parse(Console.ReadLine());
        clsOrderFileOpration.DeletOrder(Id);
    }
    static private void _PressEnterToReturn()
    {
        Console.WriteLine("\n-----------------------------------------");
        Console.Write("Press ENTER to return to Cashier Menu...");
        Console.ReadLine();
    }
    static short ChoiceOfMenu()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("              Cashier MENU             ");
        Console.WriteLine("========================================\n");

        Console.WriteLine("[1]  ➤   View All Orders..");
        Console.WriteLine("[2]  ➤ Search for an Order..");
        Console.WriteLine("[3]  ➤  Payment Process..");
        Console.WriteLine("[4]  ➤   Delete an Order..");
        Console.WriteLine("[5]  ➤  Back To Main Menu\n");

        Console.WriteLine("----------------------------------------");
        Console.Write("Enter your choice: ");

        short choice = short.Parse(Console.ReadLine());
        return choice;

        
    }


    static public void CashierMenu()
    {
        while (true)   
        {
            short choice = ChoiceOfMenu();

            switch ((EChoices)choice)
            {
                case EChoices.EViewAllOrders:
                    Console.Clear();

                    _viewAllOrders();
                    _PressEnterToReturn();
                    break;

                case EChoices.ESearchOrder:
                    Console.Clear();

                    _searchorder();
                    _PressEnterToReturn();
                    break;

                case EChoices.EPaymentprocess:
                    Console.Clear();

                    _paymentprocess();
                    _PressEnterToReturn();
                    break;

                case EChoices.EDeleteOrder:
                    Console.Clear();

                    _deletorder();
                    _PressEnterToReturn();
                    break;

                case EChoices.BackMainMenu:
                    return;  
            }
        }
    }
}
