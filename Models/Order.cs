using System.Collections.Generic;
using System;

namespace Models
{


    public class Order
    {
        public Order()
        {
        }

        //Constructor overloading
        public Order(int o_ID, int pid, decimal cost, int qty, string location , decimal total, int customerId)
        {
            this.OrderID = o_ID;
            this.ProductID = pid;
            this.QTY = qty;
            this.Cost = cost;
            this.Location = location;
            this.Total = total;
            this.CustomerId = customerId;
        }

        //Constructor overloading
        public Order(int id, int o_ID, int pid, decimal cost, int qty, string location , decimal total, int customerId, string address) 
        {
            this.ID = id;
            this.OrderID = o_ID;
            this.ProductID = pid;
            this.QTY = qty;
            this.Cost = cost;
            this.Location = location;
            this.Total = total;
            this.CustomerId = customerId;
            this.CAddress = address;
        }

        public int ID {get; set;}
        public int OrderID {get; set;}
        public int OrderId { get; set; }
        public int ProductID {get; set;}
        public int ProductId { get; set; }
        public int QTY {get; set;}
        public decimal Cost {get; set;}
        public string Location {get; set;}
        public decimal Total {get; set;}
        public int CustomerId {get; set;} 
        public string CAddress { get; }
        public int ProductQty { get; set; }
        public decimal PriceOfProduct { get; set; }
        public string StoreLocation { get; set; }
        public int OrderDetailsId { get; set; }

        public override string ToString()
        {
        return $"ProductID: {this.ProductID}, Location: {this.Location}, QTY: {this.QTY}, Cost of Product: {this.Cost}, Total: {this.Total}";
        }
    }
}