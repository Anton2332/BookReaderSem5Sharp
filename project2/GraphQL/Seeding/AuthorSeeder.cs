using GraphQL.Entitys;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Seeding;

public class AuthorSeeder : ISeeder<Author>
{
    private readonly List<Author> _authors = new()
    {

    };

    public void Seed(EntityTypeBuilder<Author> builder) => builder.HasData(_authors);
}