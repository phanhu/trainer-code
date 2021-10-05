using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CProduct
    {
        public CProduct() {
        }

        //Constructor overloading
        public CProduct(int id) {
            this.ProductId = id;
        }

        //Constructor overloading   
        public CProduct(int id, string name, string writting,
        decimal price, string home, int stock, string sort) {
            this.ProductId = id;
            this.ProductName = name;
            this.ProductDescription = writting;
            this.Price = price;
            this.InventoryLocation = home;
            this.Stock = stock;
            this.Category = sort;
        }

        [Key]
        public int ProductId {get; set;}

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string ProductDescription { get; set; }

        public string Category { get; set; }

        public int Stock {get; set; }

        public string InventoryLocation { get; set;}
    }
}