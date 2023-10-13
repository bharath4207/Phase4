using System;
using System.Numerics;
using CafetariaCardManagement;

class Program {
    public static void Main(string[] args)
    {
        FileHandling.Create();
        System.Console.WriteLine("---------------Cafetaria Card Management---------------");
       
        // Operations.AddDefaultData();
        
        
        FileHandling.ReadToCSV();
        //PrintDetails();
        bool choice = true;
        do
        {
            int option;
            bool temp;
            do
            {
                System.Console.WriteLine("Choose an option\n1.User Registration\n2.User Login\n3.Exit");
                temp = int.TryParse(Console.ReadLine(), out option);
            } 
            while (!temp);
            switch (option)
            {
                case 1:
                    {
                        //registration
                        Operations.Register();

                        break;
                    }
                case 2:
                    {
                        //Login
                        Operations.Login();
                        break;
                    }
                case 3:
                    {
                        //Exit from main menu
                        System.Console.WriteLine("You have decided to exit");
                        choice = false;
                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("Invalid Option!");
                        break;
                    }
            }

        } while (choice);

        FileHandling.WriteToCSV();

    }
}