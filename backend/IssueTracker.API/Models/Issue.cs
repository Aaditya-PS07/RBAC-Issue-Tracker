namespace IssueTracker.API.Models;

public class Issue
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsClosed { get; set; }

    // Ownership
    public int CreatedByUserId { get; set; }
    public User? CreatedByUser { get; set; }
}
