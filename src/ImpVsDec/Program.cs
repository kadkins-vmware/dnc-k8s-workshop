using System;
using System.Collections.Generic;
using System.Linq;

namespace ImpVsDec
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderItems = CustomerOrder.Items;

            imperative(orderItems);

            declarative(orderItems);
        }

        static void imperative(List<CustomerOrderItem> order)
        {
            decimal orderTotal = 0;
            foreach(var item in order) {
                orderTotal += item.Cost;
            }
            Console.WriteLine($"Imperative Order total = ${orderTotal:N2}");
        }

        static void declarative(List<CustomerOrderItem> order)
        {
            decimal orderTotal = order.Sum(item => item.Cost);
            Console.WriteLine($"Declarative Order total = ${orderTotal:N2}");
        }
    }
}
