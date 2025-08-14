using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFS.Api.Data;
using PFS.Api.Models;

namespace PFS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly AppDbContext _context;
    public FeedbackController(AppDbContext context) => _context = context;

    [HttpGet]
    public IActionResult GetFeedbacks()
    {
        var feedbacks = _context.Feedbacks.OrderByDescending(f => f.CreatedAt).ToList();
        return Ok(feedbacks);
    }

    [HttpPost]
    public IActionResult CreateFeedback(Feedback feedback)
    {
        _context.Feedbacks.Add(feedback);
        _context.SaveChanges();
        return Ok(feedback);
    }

  
}

