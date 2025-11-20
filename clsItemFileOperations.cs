using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class clsItemFileOperations
{
    const string _filename = "Item.txt";

    static private void _addnewitem(clsItem item)
    {
        using (var file = new StreamWriter(_filename, true))
        {
            file.WriteLine(item.Id + "#//#" + item.Name + "#//#" + item.Price + "#//#" + item.Quantity + "#//#" + item.Category);
        }
       
        Console.WriteLine("Item Save successfully");
    }
    static private List<clsItem> _readallitems()
    {
        List<clsItem> items = new List<clsItem>();

        using (var file = new StreamReader(_filename))
        {
            string line;

            while ((line = file.ReadLine()) != null)
            {
                var part = line.Split("#//#");

                clsItem item = new clsItem();

                item.Id = int.Parse(part[0]);
                item.Name = part[1];
                
                item.Price = double.Parse(part[2]);
                item.Quantity = int.Parse(part[3]);
                item.Category = part[4];
                items.Add(item);
            }
        }

        return items;
    }
    static private void _searchonitem(int id)
    {
        List<clsItem> items = _readallitems();
        bool found=false;   
        Console.WriteLine("=========================================");
        Console.WriteLine("                ITEM DETAILS             ");
        Console.WriteLine("=========================================");

        Console.WriteLine(
            string.Format("{0,-6} {1,-20} {2,-10} {3,-8} {4,-10}",
            "ID", "Name", "Price", "Qty", "Category"));
        Console.WriteLine("------------------------------------------------");
        foreach (var item in items)
        {
            if (id == item.Id)
            {
                found = true;
                Console.WriteLine(
                     string.Format("{0,-6} {1,-20} {2,-10} {3,-8} {4,-10}",
                     item.Id, item.Name, item.Price, item.Quantity, item.Category));
                break;
            }

        }
        if(!found)
        {
            Console.WriteLine("Item Not Found!");
            return;
        }
       
    }
    
    private static void _saveAllItems(List<clsItem> Items)
    {
        using (var writer = new StreamWriter(_filename, false)) 
        {
            foreach (var item in Items)
            {
                string line = item.Id + "#//#" + item.Name + "#//#" + item.Price + "#//#" + item.Quantity + "#//#" + item.Category;
                writer.WriteLine(line);
            }
        }
    }

    private static void _choosethetypeofmenu(string type)
    {
        var Items = _readallitems();
        Console.Clear();

        Console.WriteLine("===============================================");
        Console.WriteLine($"                 {type.ToUpper()} MENU");
        Console.WriteLine("===============================================");

        Console.WriteLine(
            string.Format("{0,-6} {1,-20} {2,-10} {3,-8} {4,-10}",
            "ID", "Name", "Price", "Qty", "Category"));
        Console.WriteLine("------------------------------------------------");

        foreach (var item in Items)
        {
            if (item.Category.ToLower() == type.ToLower())
            {
                Console.WriteLine(
                    string.Format("{0,-6} {1,-20} {2,-10} {3,-8} {4,-10}",
                    item.Id, item.Name, item.Price, item.Quantity, item.Category));
            }
        }

        Console.WriteLine("===============================================");
    }


    static public void AddNewItem(clsItem Item)
    {
        _addnewitem(Item);
    }


    static public List<clsItem> ReadAllItems()
    {
      return  _readallitems();   
    }

    static public void SearchOnItem(int id)
    {
         _searchonitem(id);
    }

    static public void SaveAllItems(List<clsItem> Items)
    {
        _saveAllItems(Items);
    }
    static void _updateItem(int Id)
    {
        var Items =ReadAllItems();
        bool found = false;
        foreach (var Item in Items)
        {
            if (Item.Id == Id)
            {
                found = true;
                Console.WriteLine("Enter New Data Of Item..");
                Console.Write("Enter ID OF Item ? ");
                Item.Id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name OF Item ? ");
                Item.Name = Console.ReadLine();

                Console.Write("Enter Price OF Item ? ");
                Item.Price = double.Parse(Console.ReadLine());

                Console.Write("Enter Quantity OF Item ? ");
                Item.Quantity = int.Parse(Console.ReadLine());

                Console.Write("Enter Category OF Item (food/drink) ? ");
                Item.Category = Console.ReadLine();
                break;
            }

        }
        if (!found)
        {
            Console.WriteLine("ID Not Found !. ");
            return;
        }

        SaveAllItems(Items);
        Console.WriteLine("Item Update successfully");

    }
    static void _deletItem(int Id)
    {
        var Items = ReadAllItems();
        clsItem ItemDelet = null;
        foreach (var Item in Items)
        {
            if (Item.Id == Id)
            {
                ItemDelet = Item;
            }
        }

        if (ItemDelet == null)
        {
            Console.WriteLine("ID Not Found !. ");
            return;
        }
        Items.Remove(ItemDelet);
        Console.WriteLine("Item Deleted successfully");
       SaveAllItems(Items);
    }
    static public void UpdateItem(int Id)
    {
        _updateItem(Id);
    }
    static public void DeletItem(int Id)
    {
        _deletItem(Id);
    }

    static public void ChoosetheTypeofmenu(string Type)
    {
        _choosethetypeofmenu(Type);
    }

}

