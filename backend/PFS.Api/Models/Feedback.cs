using System;

namespace PFS.Api.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}