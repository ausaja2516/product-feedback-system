using System;
using System.ComponentModel.DataAnnotations;

namespace PFS.Api.Models
{
   public class Feedback
   {
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public int Upvotes { get; set; } = 0;
    public string? Status { get; set; } = "Suggestion";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
   }
}
