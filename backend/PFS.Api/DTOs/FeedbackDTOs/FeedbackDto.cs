using System;
using PFS.Api.DTOs.CategoryDTOs;

namespace PFS.Api.DTOs.FeedbackDTOs;

public class FeedbackDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Upvotes { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public CategoryDto? Category { get; set; }
}
