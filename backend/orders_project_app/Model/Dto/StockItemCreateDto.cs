using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace orders_project_app.Model.Dto
{
    public class StockItemCreateDto
    {
        [Required]
        public required string Name { get; set; }
        public int Quantity { get; set; }
        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }
    }
}
