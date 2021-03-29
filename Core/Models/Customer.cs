
using System;

namespace Core.Models
{
    public class Customer
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
