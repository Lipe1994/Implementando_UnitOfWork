using System;

namespace Core.DTOs
{
    public class OrderDTO
    {
        public Guid? Id { get; set; }
        public int Number { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}
