using Microsoft.AspNetCore.Identity;

namespace DAL.Entitys;

public class User : IdentityUser
{
    public int Rating { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int UsernameChangeLimit { get; set; } = 10;    
}