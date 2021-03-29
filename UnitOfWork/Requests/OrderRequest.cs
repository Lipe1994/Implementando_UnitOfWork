namespace UnitOfWorkAPI.Requests
{
    public class OrderRequest
    {
        public int Number { get; set; }
        public CustomerRequest Customer { get; set; }
    }
}
