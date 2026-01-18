using Microsoft.AspNetCore.Mvc;
using IssueTracker.API.Data;
using IssueTracker.API.Models;
using IssueTracker.API.Services;

namespace IssueTracker.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly JwtService _jwt;

    public AuthController(AppDbContext db, JwtService jwt)
    {
        _db = db;
        _jwt = jwt;
    }

    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        _db.Users.Add(user);
        _db.SaveChanges();
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login(User user)
    {
        var dbUser = _db.Users
            .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

        if (dbUser == null) return Unauthorized();

        var token = _jwt.GenerateToken(dbUser);
        return Ok(new { token, role = dbUser.Role });
    }
}
