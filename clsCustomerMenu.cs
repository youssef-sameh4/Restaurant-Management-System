using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class clsCustomerMenu
{
    enum EChoices { EViewFoodMenu = 1, EViewDrinksMenu = 2, ECreateOrder = 3, ECancelOrder = 4,BackMainMenu=5}
    static private void _viewFoodMenu()
    {
        clsItemFileOperations.ChoosetheTypeofmenu("food");
    }
    static private void _viewDrinkMenu()
    {
        clsItemFileOperations.ChoosetheTypeofmenu("drink");
    }
    static private void _chickidofitem()
    {
        clsOrder Order = new clsOrder();

        int id;
        int quantity = 0;
        bool found=false;
        var Items = clsItemFileOperations.ReadAllItems();
        Console.Write("Enter Id Of Item ? ");
        id=int .Parse(Console.ReadLine());
        foreach (var item in Items)
        {

            if(item.Id==id)
            {
                Console.Write("Enter Quantity Of Item ? ");
                quantity = int.Parse(Console.ReadLine());
                if (quantity <= item.Quantity)
                { 
                    found = true;
                    Order.ItemId = item.Id;
                    Order.ItemName = item.Name;
                    Order.ItemPrice = item.Price;
                    Order.TotalPrice = quantity * item.Price;
                    item.Quantity=item.Quantity-quantity;
                    Console.Write("To save your order, please enter your name ? ");
                    Order.CustomerName = Console.ReadLine();
                    clsOrderFileOpration.SaveNewOrder(Order);
                }

            }
        }
        if(!found)
        {
            Console.Write("Id of Item Not Found !. ");
            return;
        }
        clsItemFileOperations.SaveAllItems(Items);

    }
    static private void _creatNewOrder()
    {
        short choose;
        Console.Write("Choose Menu ([1] Food,[2] Drink)");
        choose = short.Parse(Console.ReadLine());
        if (choose == 1)
        {
            _viewFoodMenu();
            _chickidofitem();
        }
        else if (choose == 2)
        {
            _viewDrinkMenu();
            _chickidofitem();
        }
        else
        {
            Console.WriteLine("Sorry, this number is unavailable.");
        }
    }

    static private void _cancelorder()
    {
        int Id;
        Console.Clear();
        Console.WriteLine("===========================================");
        Console.WriteLine("                Delet Order              ");
        Console.WriteLine("===========================================\n");
        Console.WriteLine("Enter ID OF Order ? ");
        Id = int.Parse(Console.ReadLine());
        clsOrderFileOpration.DeletOrder(Id);

    }
    static short ChoiceOfMenu()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("              Customer MENU             ");
        Console.WriteLine("========================================\n");

        Console.WriteLine("[1]  ➤  View Food Menu..");
        Console.WriteLine("[2]  ➤ View Drinks Menu..");
        Console.WriteLine("[3]  ➤ Create Order..");
        Console.WriteLine("[4]  ➤  Cancel Order..");
        Console.WriteLine("[5]  ➤  Back To Main Menu\n");

        Console.WriteLine("----------------------------------------");
        Console.Write("Enter your choice: ");

        short choice = short.Parse(Console.ReadLine());
        return choice;
      
    }
    static private void _PressEnterToReturn()
    {
        Console.WriteLine("\n-----------------------------------------");
        Console.Write("Press ENTER to return to Cashier Menu...");
        Console.ReadLine();
    }
    static public void CustomerMenu()
    {
        while (true) {
      short choice=ChoiceOfMenu();
            switch ((EChoices)choice)
            {
                case EChoices.EViewFoodMenu:
                    Console.Clear();

                    _viewFoodMenu();
                    _PressEnterToReturn();
                    break;
                case EChoices.EViewDrinksMenu:
                    Console.Clear();

                    _viewDrinkMenu();
                    _PressEnterToReturn();

                    break;
                case EChoices.ECreateOrder:
                    _creatNewOrder();
                    _PressEnterToReturn();

                    break;
                case EChoices.ECancelOrder:
                    Console.Clear();

                    _cancelorder();
                    _PressEnterToReturn();

                    break;
                case EChoices.BackMainMenu:
                    return;
            }

        }
    }
}

