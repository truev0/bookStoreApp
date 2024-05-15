namespace bookStoreApp.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Book(string title, string description, string author)
        {
            Title = title;
            Description = description;
            Author = author;

        }
        public Book()
        {
            Title = string.Empty;
            Description = string.Empty;
            Author = string.Empty;

        }
    }
}
