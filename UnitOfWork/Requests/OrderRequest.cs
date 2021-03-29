using System;

namespace UnitOfWorkAPI.Requests
{
    public class OrderRequest
    {
        public int Number { get; set; }
        public Guid CutomerId { get; set; }
    }
}
