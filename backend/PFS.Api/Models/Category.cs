using System;
using System.ComponentModel.DataAnnotations;

namespace PFS.Api.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
       
        public ICollection<Feedback>? Feedbacks { get; set; }
    }
}