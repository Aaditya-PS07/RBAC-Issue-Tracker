using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using IssueTracker.API.Data;
using IssueTracker.API.Models;

[ApiController]
[Route("api/issues")]
[Authorize]
public class IssuesController : ControllerBase
{
    private readonly AppDbContext _context;

    public IssuesController(AppDbContext context)
    {
        _context = context;
    }

    // 👀 VIEW ISSUES
    [HttpGet]
    public async Task<IActionResult> GetIssues()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var role = User.FindFirstValue(ClaimTypes.Role);

        if (role == "Admin")
        {
            // Admin sees ALL issues
            return Ok(await _context.Issues.ToListAsync());
        }

        // User sees ONLY their own issues
        return Ok(await _context.Issues
            .Where(i => i.CreatedByUserId == userId)
            .ToListAsync());
    }

    // ➕ CREATE ISSUE
    [HttpPost]
    public async Task<IActionResult> CreateIssue(Issue issue)
    {
        issue.CreatedByUserId = int.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );

        issue.IsClosed = false;

        _context.Issues.Add(issue);
        await _context.SaveChangesAsync();

        return Ok(issue);
    }

    // 🔒 CLOSE ISSUE (ADMIN ONLY)
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}/close")]
    public async Task<IActionResult> CloseIssue(int id)
    {
        var issue = await _context.Issues.FindAsync(id);
        if (issue == null) return NotFound();

        issue.IsClosed = true;
        await _context.SaveChangesAsync();

        return Ok(issue);
    }
}
