using Microsoft.EntityFrameworkCore;

namespace orders_project_app.Model
{
    public class StockItem : Item
    {
        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }
    }
}
