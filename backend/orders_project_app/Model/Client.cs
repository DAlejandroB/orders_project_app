﻿using System.ComponentModel.DataAnnotations;

namespace orders_project_app.Model
{
    public class Client
    {
        public int Id { get; set; }
        [StringLength(255)]
        public required string Name { get; set; }
        [StringLength(255)]
        public string? Address { get; set; }
        [StringLength(255)]
        public string? ContactEmail { get; set; }
        [StringLength(255)]
        public string? ContactPhone { get; set; }
        public List<Order> Orders { get; set; } = [];
    }
}
