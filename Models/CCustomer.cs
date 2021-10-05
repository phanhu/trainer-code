using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CCustomers
    {
        //Constructor for Customer 
        public CCustomers(){
        }
        //Constructor overloading
        public CCustomers(string name) : this()
        {      
            this.CustomerName = name;
        }

        public CCustomers(int id) : this()
        {      
            this.CustomerId = id;
        }

        //Constructor Chain to add on user if Customer wants to add user
        public CCustomers(string name, string user, string password, string address) : this(name)
        {
            this.Username = user;
            this.CPassword = password;
            this.Address = address;
        }

        //Properties
        [Key]
        public int CustomerId{get; set;}

        public string CustomerName {get; set;}

        public string Username {get; set;}

        public string CPassword {get; set;}

        public string Address { get; set; }

        public override string ToString()
        {
            return $"Name: {this.CustomerName}, Username: {this.Username}";
        }
    }
}
