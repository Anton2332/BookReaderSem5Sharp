using Microsoft.AspNetCore.Identity;

namespace DAL_USER.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public List<RefreshToken> RefreshTokens { get; set; }
}