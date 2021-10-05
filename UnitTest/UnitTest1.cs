using System;
using Xunit;
using System.Collections.Generic;
using Models;

namespace UnitTest
{
    public class UnitTest1
    {
    [Fact] 
    public void Test_CreateCustomer(){

        Customers c1 = new CCustomer("Jill", "Bill", "jillbill");
        Assert.NotNull(c1);
        }

    [Fact]
    public void Test_changeStock(){

        CProduct p1 = new Models.CProduct();
        int amount = 1;
        p1.Stock = amount;
        Assert.Equal(p1.Stock,amount);
    }

    [Fact]
    public void Test_LinesOfItems()
    {
        CProduct p1 = new Models.CProduct(2);
        CProduct p2 = new Models.CProduct();
        p2.ProductId = 2;

        Assert.Equal(p1.ProductId,p2.ProductId);
    }

    [Fact]
    public void Test_GetAllCustomer()
    {
        List<Customers> getallcustomer = new List<Customers>();
        Customers g1 = new CCustomer("ni", "na", "nu");
        getallcustomer.Add(g1);
        Assert.NotNull(g1);
    }

    [Fact]
    public void addToCart()
    {

        int addItemId = 0;
        int selectedId = 12;
        addItemId = selectedId;

        Assert.InRange(addItemId, 0, 25);

    }
    [Fact]
    public void OrderHistory()
    {
        List<Order> OrderHistory = new List<Order>();
        Order r = new Order();
        Order q = new Order();
        OrderHistory.Add(r);
        OrderHistory.Add(q);

        Assert.True(OrderHistory.Count > 0);
    }

    [Fact]
    public void maxBuy()
    {
        int inventory = 10;
        int addToCart = 5;

        inventory -= addToCart;

        Assert.True(inventory > 0);
    }

    [Fact]
    public void newAccount()
    {
        Customers c1 = new CCustomer("t", "t", "t");
        Customers c2 = new CCustomer("d", "d", "d");

        Assert.True(c1 != c2);
    }

    [Fact]
    public void removeAccount()
    {
        List<Customers> person = new List<Customers>();
        Customers y = new Customers();
        Customers k = new Customers();
        person.Add(y);
        person.Add(k);
        

        person.Remove(y);

        Assert.True(person.Count == 1);
    }

    [Fact]
    public void restock()
    {
        int CurrentStock = 9;
        int addedStock = 5;

        CurrentStock += addedStock;

        Assert.True(CurrentStock > 9);
    }
    }
}
