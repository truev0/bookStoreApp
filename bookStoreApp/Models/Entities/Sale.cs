namespace bookStoreApp.Models.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
