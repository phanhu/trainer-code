using Models;
using System.Collections.Generic;

namespace StoreDL
{
    public interface IRepo
    {

        CCustomers AddCustomer(CCustomers customer);
        List<CCustomers> GetAllCustomer();

        List<CProduct> ListProducts();
        Models.CProduct changeStock(CProduct stockCount);

        List<LineItems> LinesOfItems();
        LineItems createLineItem(LineItems item);

        List<Order> OrderHistory();


    }
}