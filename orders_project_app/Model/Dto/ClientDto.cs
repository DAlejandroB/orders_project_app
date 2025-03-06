using System.ComponentModel.DataAnnotations;

namespace orders_project_app.Model.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Address { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public List<int> Orders { get; set; } = [];
    }
}
