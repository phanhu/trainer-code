using System;
using Models;
using StoreBL;
using Serilog;
using System.Collections.Generic;
using System.Collections;
using StoreDL;
using StoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;
using System.IO;

namespace UI
{
    public class OnlineInventory : IMenu
    {
        //connect and pass things with IProductBL
        private IProduct _product;

        public OnlineInventory(IProduct product)
        {
            _product = product;
        }
        
        public void Start()
        {
            //made two list shoppingCart and addToOrder, called on LinesOfItems and ListProducts through IProductBL
            List<Cart> shoppingCart = new List<Cart>();
            List<LineItems> items = _product.LinesOfItems();
            List<LineItems> addToOrder = new List<LineItems>();
            List<CProduct> newStock = _product.ListProducts();

            bool exit = false;
            int fullCart = 0;
            //set random order number
            var rnd = new Random();
            int OrderNum = rnd.Next(1000000);

            do
            {
                Console.WriteLine("");
                //made a list to hold carted items
                List<CProduct> addToCart = _product.ListProducts();
                Console.WriteLine("Customer: " + CustomerFollower.followMe + ",  ID: " + CustomerFollower.getMyID);
                Console.WriteLine("  Which item would you like to add to your cart?");

                //display inventory bt productid, product name, price, stock qty, location
                foreach (var add in addToCart)
                {
                    Console.WriteLine($@"ID: {add.ProductId} - {add.ProductName}              Price: {add.Price} is QTY:{add.Stock}, Location: {add.InventoryLocation}");
                }
                Console.WriteLine("\nWould you like to shop online or pick up in store?");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("1. Shop");
                Console.WriteLine("2. Checkout"); 
                Console.WriteLine("3. Exit");
                Console.WriteLine("");

            switch(Console.ReadLine())
            {
                case "1":
                    int lookup = 0;
                    Console.Write("Pick a product to look at: ");
                    try{
                    lookup = int.Parse(Console.ReadLine()) - 1;
                    }
                    catch(Exception outOfRange)
                    {
                            Console.WriteLine("ID picked was outside of Inventory", outOfRange);
                    }
                    if(lookup > 25 || lookup < 0){
                        Console.WriteLine("Please enter valid opinion.");
                        } 

                        //shows product info after picking an productID
                        Console.WriteLine($@"{addToCart[lookup].ProductName}: {addToCart[lookup].ProductDescription}");
                        Console.WriteLine("\nInventory:");
                        string loc = addToCart[lookup].InventoryLocation;
                        Console.WriteLine($@"{loc}: {addToCart[lookup].Stock}");
                        Console.WriteLine("How many would you like to buy?");
                        int storeCart = int.Parse(Console.ReadLine());

                        //To stop from over ordering
                        if(storeCart > addToCart[lookup].Stock)
                            {
                                Console.WriteLine("Sorry, but we can not fulfill your order.");
                                storeCart = 0;
                            }
                        fullCart += storeCart;
                        decimal On_total = storeCart*addToCart[lookup].Price;
                        Console.WriteLine($@"You have add {storeCart} {addToCart[lookup].ProductName} into your cart.");

                        //setting variables from Product DB to shoppingCart parameters
                        int newCid = CustomerFollower.getMyID;
                        int newOid = OrderNum;
                        string newLoc = addToCart[lookup].InventoryLocation;
                        int newPid = addToCart[lookup].ProductId;
                        string newName = addToCart[lookup].ProductName;
                        decimal newPrice = addToCart[lookup].Price;
                        int newqQty = storeCart; 
                        decimal newTotal = On_total;

                        //Add to shoppingCart and made Lineitem
                        shoppingCart.Add(new Cart() {oid = newOid, pid = newPid, qty = newqQty, price = newPrice, loc = newLoc, total = newTotal,cid = newCid});
                        Models.LineItems newItem = new Models.LineItems(newOid, newPid, newqQty, newPrice, loc, newTotal, CustomerFollower.getMyID);
                        Models.CProduct buyingProduct = new Models.CProduct(storeCart);

                        //add new LineItem to list of lineItems above
                        addToOrder.Add(newItem);
                        Console.WriteLine(addToOrder);

                        //shows what is currently in cart
                        Console.WriteLine("Currently in Cart:");
                        foreach (Cart cart in shoppingCart)
                        {
                            Console.WriteLine("Name: {newName} " + cart.ToString());
                            
                        }
                    break;
                    
                case "2":
                    Console.WriteLine("Would you like to checkout?");
                    Console.WriteLine("Currently in Cart:");
                        foreach (Cart cart in shoppingCart)
                        {
                            Console.WriteLine(cart.ToString());
                        }
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    switch(Console.ReadLine())
                    {
                        case "1":
                            //foreach loop to loop through add the line items then another foreach loop to match the product id of the line items 
                            //to items in currently list of products. and subtract the carted amount from the inventory amount.
                            foreach (var l in addToOrder)
                            {
                                _product.createLineItem(l); 
                                foreach(var p in newStock){
                                if(l.ProductId == p.ProductId)
                                {
                                    p.Stock -= l.ProductQty;
                                    _product.changeStock(p);
                                }
                                }
                            }
                                Console.WriteLine("Order was completed.");
                            break;

                        case "2":
                            break;

                        default:
                            Console.WriteLine("Please enter valid opinion.");
                            break;
                    }
                break;

                case "3":
                    //leaves menu and will not save cart
                    Console.WriteLine("Exiting will cause you to empty your cart. Do you like to continue?");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    switch(Console.ReadLine())
                    {
                        case "1":
                            
                            new MainMenu().Start();
                            break;

                        case "2":
                            break;

                        default:
                            Console.WriteLine("Please enter valid opinion.");
                            break;
                    }
                break;

                default:
                Console.WriteLine("Please pick an opinion above.");
                break;

                }
            }while (!exit);
        }

        //my shopping cart
        public class Cart
        {
        public int cid {get; set;}
        public int oid {get; set;}
        public string loc { get; set; }
        public int pid {get; set;}
        public string name {get; set;}
        public decimal price { get; set; }
        public int qty {get;set;}
        public decimal total { get; set; }

        public override string ToString()
        {
            return "Product ID: " + pid + " Location: " + loc + " Price: " + price + " QTY: " + qty + " Total: " + total + " Customer ID: " + cid + " Order ID: " + oid ;
        }

        }
    }
}