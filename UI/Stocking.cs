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
    public class Stocking : IMenu
    {
        //connect and pass things with IProductBL
        private IProduct _product;

        public Stocking(IProduct product)
        {
            _product = product;
        }
    
        public void Start()
        {
            bool exit = false;

            List<CProduct> restock = _product.ListProducts();
            //display current product inventory
            foreach(var y in restock)
            {
                Console.WriteLine($"The current Stock for {y.ProductName},        (ID: {y.ProductId})               is QTY:{y.Stock}, Location: {y.InventoryLocation}");
            }
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Update stock inventory.");
                Console.WriteLine("2. Exit.\n");                

            do
            {
                switch(Console.ReadLine())
                {
                    case "1":
                        changeStock();
                            Console.WriteLine("\nWhat would you like to do?");
                            Console.WriteLine("1. Update stock inventory.");
                            Console.WriteLine("2. Exit.\n");
                        break;

                    case "2":
                        new MainMenu().Start();
                        break;

                    default:
                        Console.WriteLine("Product was not found.");
                        break;
                }
            } while (!exit);
        }

        //write over old stock amount
        private void changeStock()
        {
            List<CProduct> restock = _product.ListProducts();
            Console.WriteLine("");
            Console.Write("Please entered the Product ID:");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Please entered the new amount for stock :");
            int amount = int.Parse(Console.ReadLine());
            if(amount < 0)
            {
                Console.WriteLine("Inventory can not be negative.");
                amount = 0;
            }
            Models.CProduct stockCount = new Models.CProduct();

            foreach(var p in restock){
                if(id == p.ProductId)
                {
                    stockCount = p;
                    stockCount.Stock = amount;
                    _product.changeStock(stockCount);
                    Console.WriteLine($"\nNew stock count for {restock[id-1].ProductName} is {restock[id-1].Stock}.");
                }
            }
        }
    }
}