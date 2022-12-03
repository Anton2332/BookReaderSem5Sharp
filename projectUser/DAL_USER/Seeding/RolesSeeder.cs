using DAL_USER.Interfaces;
using Microsoft.AspNetCore.Identity;
using DAL_USER.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL_USER.Seeding;

public class RolesSeeder : ISeeder<IdentityRole>
{
    private readonly List<IdentityRole> _roles = new()
    {
        new IdentityRole(Roles.SuperAdmin.ToString()),
        new IdentityRole(Roles.Admin.ToString()),
        new IdentityRole(Roles.Moderator.ToString()),
        new IdentityRole(Roles.Redactor.ToString()),
        new IdentityRole(Roles.Basic.ToString()),
    };

    public void Seed(EntityTypeBuilder<IdentityRole> builder) =>
        builder.HasData(_roles);
}