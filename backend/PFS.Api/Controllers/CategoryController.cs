using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFS.Api.Data;
using PFS.Api.Models;
using PFS.Api.DTOs.CategoryDTOs;

namespace PFS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        var categories = await _context.Categories
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();

        return Ok(categories);
    }
}
