using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 class clsMainMenu
{
    enum EChoices { ECustomerMenu=1,EEmployeeMenu=2,ECashierMenu=3,Exit=4};
   static private string _iddemployee="2244";
   static private string _idcashier = "3355";

    static short ChoiceOfMenu()
    {
        Console.Clear(); 
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("=======================================");
        Console.WriteLine("                MAIN MENU              ");
        Console.WriteLine("=======================================\n");

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine(" [1] Customer Menu");
        Console.WriteLine(" [2] Employee Menu");
        Console.WriteLine(" [3] Cashier Menu");
        Console.WriteLine(" [4] Exit\n");

        Console.ResetColor();
        Console.Write(">> Enter your choice: ");
        short choice;
        choice = short.Parse(Console.ReadLine());
        return choice;
    }

    static public void MainMenu()
    {
        while (true)
        {
            bool Notcorrect = true;

            short choice =ChoiceOfMenu();
            switch ((EChoices)choice)
            {
                case EChoices.ECustomerMenu:

                    clsCustomerMenu.CustomerMenu();
                    break;
                case EChoices.EEmployeeMenu:
                    while (Notcorrect==true)
                    {
                        string IdEmployee;
                        Console.Write("Enter Your ID ? ");
                        IdEmployee= Console.ReadLine();
                        if (IdEmployee == _iddemployee)
                        {
                            Notcorrect=false;
                            Console.Clear();
                            clsEmployee.EmployeeMenue();
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The ID is incorrect. Please enter the correct ID again.");
                        Console.ForegroundColor = ConsoleColor.White;

                        Notcorrect = true;
                    }
                    break;
                case EChoices.ECashierMenu:
                    while (Notcorrect == true)
                    {
                        string IdEmployee;
                        Console.Write("Enter Your ID ? ");
                        IdEmployee = Console.ReadLine();
                        if (IdEmployee == _idcashier)
                        {
                            Notcorrect = false;
                            Console.Clear();
                            clsCashierMenu.CashierMenu();
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The ID is incorrect. Please enter the correct ID again.");
                        Console.ForegroundColor = ConsoleColor.White;

                        Notcorrect = true;
                    }
                    break;
                case EChoices.Exit:
                    Console.WriteLine("Program End !.");
                    return;


            
            }

        }
    }
}

