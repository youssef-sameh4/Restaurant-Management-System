using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class clsEmployee
{ 
    enum EChoices { viewallitem=1,Add=2,Search=3,Udate=4,Delet=5,BackMainMenu=6}
    static void PrintItems(List<clsItem> items)
    {
        Console.Clear();
        Console.WriteLine("============================================================");
        Console.WriteLine("ID\tName\t\tCategory\tPrice\tQuantity");
        Console.WriteLine("============================================================");

        foreach (var item in items)
        {
            Console.WriteLine($"{item.Id}\t{item.Name.PadRight(15)}\t{item.Category.PadRight(8)}\t{item.Price}\t{item.Quantity}");
        }

        Console.WriteLine("============================================================");
    }

    static clsItem Enterditem()
    {
        clsItem item=new clsItem();
        Console.Write("Enter ID OF Item ? ");
        item.Id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name OF Item ? ");
        item.Name = Console.ReadLine();

        Console.Write("Enter Price OF Item ? ");
        item.Price = double.Parse(Console.ReadLine());

        Console.Write("Enter Quantity OF Item ? ");
        item.Quantity = int.Parse(Console.ReadLine());

        Console.Write("Enter Category OF Item (food/drink) ? ");
        item.Category = Console.ReadLine();

       
        return item;
    }
    static private void _PressEnterToReturn()
    {
        Console.WriteLine("\n-----------------------------------------");
        Console.Write("Press ENTER to return to Cashier Menu...");
        Console.ReadLine();
    }
    static short ChoiceOfMenue()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("              EMPLOYEE MENU             ");
        Console.WriteLine("========================================\n");
        Console.WriteLine("[1]  ➤  View All Item");
        Console.WriteLine("[2]  ➤  Add New Item");
        Console.WriteLine("[3]  ➤  Search for Item");
        Console.WriteLine("[4]  ➤  Update Item");
        Console.WriteLine("[5]  ➤  Delete Item");
        Console.WriteLine("[6]  ➤  Back To Main Menu\n");

        Console.WriteLine("----------------------------------------");
        Console.Write("Enter your choice: ");

        short choice = short.Parse(Console.ReadLine());
        return choice;
    }

    static private void _searchiem()
    {
        int Id;
        Console.Write("Enter ID Of Item ? ");
        Id = int.Parse(Console.ReadLine());
       clsItemFileOperations.SearchOnItem(Id);
    }
    public static void EmployeeMenue()
    {
        while (true)
        {
            short choice = ChoiceOfMenue();
            int Id;

            switch ((EChoices)choice)
            {
                case EChoices.viewallitem:
                    Console.Clear();

                    PrintItems(clsItemFileOperations.ReadAllItems());
                    _PressEnterToReturn();
                    break;
                case EChoices.Add:
                    Console.Clear();

                    clsItem item = Enterditem();
                    clsItemFileOperations.AddNewItem(item);
                    _PressEnterToReturn();
                    break;
                case EChoices.Search:
                    Console.Clear();

                    _searchiem();
                    _PressEnterToReturn();

                    break;
                case EChoices.Udate:
                    Console.Clear();

                    Console.Write("Enter ID Of Item ? ");
                    Id = int.Parse(Console.ReadLine());
                    clsItemFileOperations.UpdateItem(Id);
                    _PressEnterToReturn();

                    break;
                case EChoices.Delet:
                    Console.Clear();

                    Console.Write("Enter ID Of Item ? ");
                    Id = int.Parse(Console.ReadLine());
                    clsItemFileOperations.DeletItem(Id);
                    _PressEnterToReturn();

                    break;
                case EChoices.BackMainMenu:
                    return;
            }
        }
    }

}

