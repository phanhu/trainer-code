using System;
using System.Collections.Generic;

namespace Models
{
    public class LineItems
    {
        public LineItems(){
        }
        //Constructor overloading
        public LineItems(int id){
            this.ProductId = id;
        }
        
        //Constructor overloading
        public LineItems(int oid, int pid, int qty, int cid){
            this.OrderId = oid;
            this.ProductId = pid;
            this.ProductQty = qty;
            this.CustomerId = cid;
        }

        //Constructor overloading
        public LineItems(int oid, int pid, int qty,decimal price, string loca, decimal total, int cid){
            this.OrderId = oid;
            this.ProductId = pid;
            this.ProductQty = qty;
            this.PriceOfProduct = price;
            this.StoreLocation = loca;
            this.Total = total;
            this.CustomerId = cid;
        }

        public int ProductId {get; set;}
        public int ProductQty {get; set;}
        public int OrderId {get; set;} 
        public decimal PriceOfProduct { get; set; }
        public string StoreLocation { get; set; }
        public decimal Total { get; set; }
        public int CustomerId {get; set;} 

        public override string ToString()
        {
            return $"{this.ProductId}  Location: {this.StoreLocation}  QTY: {this.ProductQty}  Total: {this.Total}";
        }
    }
}