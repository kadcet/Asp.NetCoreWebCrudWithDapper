namespace KadirWebApi2.Model
{
    public class Orders
    {
        public int id { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int OrderCount { get; set; }

        public DateTime OrderDate { get; set; }

        public List<Customers> Customers { get; set; }

        public List<Products> Products { get; set; }
    }
}
