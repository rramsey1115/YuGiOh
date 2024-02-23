using Microsoft.AspNetCore.Identity;

namespace YuGiOh.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public List<string>? Roles { get; set; }
    public string IdentityUserId { get; set; }
    public IdentityUser? IdentityUser { get; set; } 
}