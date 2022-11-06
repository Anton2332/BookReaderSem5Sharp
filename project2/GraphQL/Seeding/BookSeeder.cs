using GraphQL.Entitys;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Seeding;

public class BookSeeder : ISeeder<Book>
{
    private readonly List<Book> _books = new()
    {

    };

    public void Seed(EntityTypeBuilder<Book> builder) => builder.HasData(_books);
}