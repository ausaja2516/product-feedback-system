using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFS.Api.Data;
using PFS.Api.Models;
using PFS.Api.DTOs.FeedbackDTOs;
using PFS.Api.DTOs.CategoryDTOs;

namespace PFS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedbackController : ControllerBase
{
    private readonly AppDbContext _context;

    public FeedbackController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FeedbackDto>>> GetFeedbacks()
    {
        var feedbacks = await _context.Feedbacks
            .Include(f => f.Category)
            .OrderByDescending(f => f.Upvotes)
            .Select(f => new FeedbackDto
            {
                Id = f.Id,
                Title = f.Title,
                Description = f.Description,
                Upvotes = f.Upvotes,
                Status = f.Status,
                CreatedAt = f.CreatedAt,
                Category = new CategoryDto
                {
                    Id = f.Category.Id,
                    Name = f.Category.Name
                }
            })
            .ToListAsync();

        return Ok(feedbacks);
    }

    [HttpPost]
    public async Task<ActionResult<FeedbackDto>> CreateFeedback(CreateFeedbackDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var category = await _context.Categories.FindAsync(dto.CategoryId);
        if (category == null)
            return BadRequest(new { message = "Invalid category ID." });

        var feedback = new Feedback
        {
            Title = dto.Title.Trim(),
            Description = dto.Description.Trim(),
            CategoryId = dto.CategoryId,
            Upvotes = 0,
            Status = "Suggestion",
            CreatedAt = DateTime.UtcNow
        };

        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        var feedbackDto = new FeedbackDto
        {
            Id = feedback.Id,
            Title = feedback.Title,
            Description = feedback.Description,
            Upvotes = feedback.Upvotes,
            Status = feedback.Status,
            CreatedAt = feedback.CreatedAt,
            Category = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            }
        };

        return CreatedAtAction(nameof(GetFeedbacks), new { id = feedback.Id }, feedbackDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<FeedbackDto>> UpdateFeedback(int id, UpdateFeedbackDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var feedback = await _context.Feedbacks.FindAsync(id);

        if (feedback == null)
            return NotFound(new { message = "Feedback not found." });
        if (dto.CategoryId.HasValue)
        {
            var category = await _context.Categories.FindAsync(dto.CategoryId.Value);
            if (category == null)
                return BadRequest(new { message = "Invalid category ID." });

            feedback.CategoryId = dto.CategoryId.Value;
        }

        feedback.Title = dto.Title?.Trim() ?? feedback.Title;
        feedback.Description = dto.Description?.Trim() ?? feedback.Description;
        feedback.Status = dto.Status ?? feedback.Status;

        _context.Feedbacks.Update(feedback);

        await _context.SaveChangesAsync();
        
        var updatedDto = new FeedbackDto
        {
            Id = feedback.Id,
            Title = feedback.Title,
            Description = feedback.Description,
            Upvotes = feedback.Upvotes,
            Status = feedback.Status,
            CreatedAt = feedback.CreatedAt,
            Category = new CategoryDto
            {
                Id = feedback.Category.Id,
                Name = feedback.Category.Name
            }
        };
        return Ok(updatedDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeedback(int id)
    {
        var feedback = await _context.Feedbacks.FindAsync(id);
        if (feedback == null)
            return NotFound(new { message = "Feedback not found." });

        _context.Feedbacks.Remove(feedback);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
}


