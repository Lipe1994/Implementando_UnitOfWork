using System;

namespace Core.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Customer Customer { get; set; }
    }
}
