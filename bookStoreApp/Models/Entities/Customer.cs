namespace bookStoreApp.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Rut { get; set; } = string.Empty;
        public string Status { get; set; } = "Activo";
    }
}
