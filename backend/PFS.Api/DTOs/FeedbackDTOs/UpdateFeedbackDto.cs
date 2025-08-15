using System;

namespace PFS.Api.DTOs.FeedbackDTOs;

public class UpdateFeedbackDto
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public string? Status { get; set; }
}
