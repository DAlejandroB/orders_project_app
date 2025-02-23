namespace orders_project_app.Model
{
    public class Client
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public List<Order> Orders { get; set; }
    }
}
