using System;
using System.ComponentModel.DataAnnotations;

namespace PFS.Api.DTOs.FeedbackDTOs; 

public class CreateFeedbackDto
{
    [Required]
    public string? Title { get; set; }
    
    [Required]
    public string? Description { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
}
