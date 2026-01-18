using Microsoft.EntityFrameworkCore;
using IssueTracker.API.Models;

namespace IssueTracker.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<User> Users => Set<User>();
    public DbSet<Issue> Issues => Set<Issue>();
}
