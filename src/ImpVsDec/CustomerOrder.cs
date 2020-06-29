using System;
using System.Collections.Generic;

namespace ImpVsDec
{
    class CustomerOrder
    {
        public static List<CustomerOrderItem> Items {
            get {
                List<CustomerOrderItem> customerOrder = new List<CustomerOrderItem>();
                customerOrder.Add(new CustomerOrderItem("Pizza", 10.10m));
                customerOrder.Add(new CustomerOrderItem("Peanuts", 2.75m));
                customerOrder.Add(new CustomerOrderItem("Beer", 4.995m));
                return customerOrder;
            }
        }
    }
}
