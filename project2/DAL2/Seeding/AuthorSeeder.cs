using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class AuthorSeeder : ISeeder<Author>
{
    private readonly List<Author> _authors = new()
    {

    };

    public void Seed(EntityTypeBuilder<Author> builder) => builder.HasData(_authors);
}