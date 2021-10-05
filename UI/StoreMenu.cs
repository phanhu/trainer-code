using System;
using Models;
using StoreBL;
using StoreDL;
using StoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace UI
{
    class StoreMenu : IMenu
    {
        public void Start()
        {
            string connectionString = File.ReadAllText(@"../connectionString.txt");
            DbContextOptions<EarlOfTeaDBContext> options = new 
            DbContextOptionsBuilder<EarlOfTeaDBContext>().UseSqlServer(connectionString).Options;
            EarlOfTeaDBContext next = new EarlOfTeaDBContext(options);
            
            bool exit = false;
            string input = "";
            do
            {
                Console.WriteLine("\nWelcome " + CustomerFollower.followMe + ",  ID: " + CustomerFollower.getMyID);
                Console.WriteLine("\nWhere would you like to go? ");
                Console.WriteLine("===========================");
                Console.WriteLine(" 1. Start Shopping.");
                Console.WriteLine(" 2. Exit.");
                Console.WriteLine("===========================\n");
                //Allow user to pick which Menu they want to go to next
                input = Console.ReadLine();

                switch (input)
                {
                    case "1": 
                        new OnlineInventory(new ProductBL(new DBRepo(next))).Start();
                        break;

                    case "2":
                        Console.WriteLine("Thank you for visit, hope to see you again soon!");
                        new MainMenu().Start();
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Sorry, please select an option from above.");
                        break;
                }           
            } while (!exit);
        }
    }
}