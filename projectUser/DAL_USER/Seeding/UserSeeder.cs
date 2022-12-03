using DAL_USER.Entities;
using DAL_USER.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL_USER.Seeding;

public class UserSeeder : ISeeder<ApplicationUser>
{
    private readonly List<ApplicationUser> _users = new()
    {
        new ApplicationUser()
        {
            UserName = "superadmin",
            Email = "superadmin@gmail.com",
            FirstName = "super",
            LastName = "admin",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        }
    };

    public void Seed(EntityTypeBuilder<ApplicationUser> builder) =>
        builder.HasData(_users);
}