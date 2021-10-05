using System;
using Models;
using StoreBL;
using StoreDL;
using StoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace UI
{
    class MainMenu : IMenu
    {
        //start() for begin the console app 
        public void Start()
        {  
            string connectionString = File.ReadAllText(@"../connectionString.txt");
            DbContextOptions<EarlOfTeaDBContext> options = new 
            DbContextOptionsBuilder<EarlOfTeaDBContext>().UseSqlServer(connectionString).Options;
            EarlOfTeaDBContext context = new EarlOfTeaDBContext(options);
            
            bool exit = false;
            string input = "";

            //Empty string for the manager to put their password in. Empty String for customer to enter in username 
            string password = "";
            
            //The Main Menu you see when opening console
            //Need to figure out how to jump around menus
            do
            {
                Console.WriteLine("\n  Welcome to Earl of Tea! ");
                Console.WriteLine("*Possibly the only non-British owned British tea shop in Anchorage, AK*");
                Console.WriteLine("===========================");
                Console.WriteLine(" 1. Login in as a Customer.");
                Console.WriteLine(" 2. Login in as Manager.");
                Console.WriteLine(" 3. View Order History.");
                Console.WriteLine(" 4. Exit.");
                Console.WriteLine("===========================\n");
                //Allow user to pick which Menu they want to go to next
                input = Console.ReadLine();

                switch (input)
                {
                    case "1": //go to the Customer Menu
                        new CustomerMenu(new CustomerBL(new DBRepo(context))).Start();
                        exit = true;
                        break;

                    case "2": // Has Manager enter password and if correct go to the Manager Menu if not has them try again.
                        Console.WriteLine("Please enter store password:");
                        password = Console.ReadLine();
                        if(password == "password1"){
                        new ManagerMenu().Start();  
                        } else {
                            Console.WriteLine("Incorrect password was entered. Please try again.");
                            }
                        break;
                    
                    case "3":
                        new SearchMenu(new CustomerBL(new DBRepo(context))).Start();
                        break;

                    case "4": // Makes exit true and thanks them to visiting
                        Console.WriteLine("Thank you for visit, hope to see you again soon!");
                        exit = true;
                        break;

                    default: //When user enter in a value that wasn't listed above
                        Console.WriteLine("Sorry, please select an option from above.");
                        break;
                }           
            } while (!exit);
        }
    }
}
