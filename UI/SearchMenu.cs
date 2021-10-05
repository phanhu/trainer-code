using System;
using Models;
using StoreBL;
using System.Collections.Generic;
using StoreDL;
using StoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;

namespace UI
{
    public class SearchMenu :IMenu
    {
        //connect and pass things with ICustomerBL
        private ICustomerBL _customer;

        public SearchMenu(ICustomerBL customer)
        {
            _customer = customer;
        }

        public void Start()
        {
            bool exit = false;
            do{
                Console.WriteLine("\nHow would you like to find your Order? ");
                Console.WriteLine("=======================================");
                Console.WriteLine(" 1. Find out my Customer ID.");
                Console.WriteLine(" 2. Search Order History with Customer ID.");
                Console.WriteLine(" 3. Exit.");
                Console.WriteLine("=======================================\n");

                switch(Console.ReadLine())
                {
                    case "1":
                    findMe();
                    new MainMenu().Start();
                    Console.Write("");
                    break;

                    case "2":
                    myOrders();
                    Console.Write("");
                    break;

                    case "3":
                    exit = true;
                    new MainMenu().Start();
                    break;

                    default:
                    Console.WriteLine("Sorry, please select an option from above.");
                    break;
                } 
            }while (!exit);
        }

        //looking for id by matching username and password of the same account
        private void findMe()
        {
            List<CCustomer> validAccount = _customer.GetAllCustomer();
            Console.Write("\nPlease enter your username: ");
            string uName = Console.ReadLine();
            Console.Write("Please enter your password: ");
            string uPass = Console.ReadLine();
            int id = 0;
            foreach(var u in validAccount)
            {
                if(u.Username == uName && u.CPassword == uPass)
                {
                    id = u.CustomerId;
                    Console.WriteLine($@"Customer Name: {u.CustomerName}, CustomerID: {u.CustomerId}");
                }
            }
        }

        //looking for list of order through customerID
        private void myOrders()
        {
        List<Order> mine = _customer.OrderHistory();
        Console.Write("Please enter CustomerID: ");
        string cid = Console.ReadLine();
        int id = int.Parse(cid);
        foreach(var m in mine)
        {
            if(id == m.CustomerId)
            {
                Console.WriteLine(m.ToString());
            }
        }
        }

    }
}

