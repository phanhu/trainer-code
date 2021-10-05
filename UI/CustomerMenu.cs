using System;
using Models;
using StoreBL;
using System.Collections.Generic;
using StoreDL;
using StoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;
using Serilog;

namespace UI
{
    public class CustomerMenu : IMenu
    {
        //connect and pass things with ICustomerBL
        private ICustomerBL _customer;

        public CustomerMenu(ICustomerBL customer)
        {
            _customer = customer;
        }

        //Layout for the Customer Start Menu using a do while loop to display opinions and nested a switch case to select opinion
        public void Start()
        {
            bool exit = false;
            //practice code before connecting db
            //string fakeuser = "user";
            //string fakepassword = "pass";

            do
            {
                Console.WriteLine("\n    How can we help you? ");
                Console.WriteLine("===========================");
                Console.WriteLine(" 1. Sign-In");
                Console.WriteLine(" 2. Make New Username");
                Console.WriteLine(" 3. Exit.");
                Console.WriteLine("===========================\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        //if the account info match then sent to store menu
                        if(matchAccount())
                        {
                        new StoreMenu().Start();
                        }
                        break;

                    case "2":
                        //making a new customer user
                        AddCustomer();
                        new StoreMenu().Start();
                        break;

                    case "3":
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

        //For customer to create an User
        private void AddCustomer()
        {
            //et list of current customers
            List<CCustomer> validAccount = _customer.GetAllCustomer();
            Log. Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().WriteTo.File("../logs/logs.txt").CreateLogger();

            Log.Information("Adding Account ");
            Console.Write("Please enter your name: ");
            string cName = Console.ReadLine();
            Console.Write("Please enter desired username: ");
            string newUser = Console.ReadLine();

            //loops through current customer list to see if username ids taken
            foreach(var user in validAccount)
            {
                if(user.Username == newUser)
                {
                    Console.WriteLine("This username already exists. Please come back when you think of a new password.");
                    
                }
            }

            Console.Write("Please make a password: ");
            string newPassword = Console.ReadLine();
            Log.Information("Made account. Time to go shopping ");

            //make new customer with entered info and save it to the customer db by using the AddCustomer
            Models.CCustomer customer = new Models.CCustomer(cName, newUser, newPassword);
            _customer.AddCustomer(customer);
            
            Console.WriteLine($"\nWelcome, {customer.ToString()}");
            Console.WriteLine("Your Account was made please login.\n");
            Log.CloseAndFlush();
            new MainMenu().Start();
        }

        private bool matchAccount()
        {
            //bool if account matches or not
            bool match = false;
            string enteredUser;
            string enteredPassword;

            //to loop through each row of customer 
            List<CCustomer> validAccount = _customer.GetAllCustomer();

            Console.WriteLine("\nPlease enter in your account information.");
            Console.Write("User: ");
            enteredUser = Console.ReadLine();
            Console.Write("Password: ");
            enteredPassword = Console.ReadLine();

            //for loop to match compatable Username and Password to existing account
            for( int u = 0; u <validAccount.Count; u++){
                if(enteredUser == validAccount[u].Username && enteredPassword == validAccount[u].CPassword){
                Console.WriteLine($@"Welcome {validAccount[u].CustomerName}.");
                Console.WriteLine("");
                    match = true;
                    CustomerFollower.followMe = validAccount[u].CustomerName;
                    CustomerFollower.getMyID = validAccount[u].CustomerId;
                }
            }if(match == false){
                Console.WriteLine("\nUsername or Password are incorrect. Please try again.");
            }else {
                Console.WriteLine("Where would you like to shop?");
            }
            return match;
        }
    }
}
