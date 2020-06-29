using System;

namespace ImpVsDec
{
    class CustomerOrderItem
    {
        public CustomerOrderItem(string name, decimal cost) {
            Name = name;
            Cost = cost;
        }
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}
