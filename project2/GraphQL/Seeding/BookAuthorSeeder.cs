using GraphQL.Entitys;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Seeding;

public class BookAuthorSeeder : ISeeder<BookAuthor>
{
    private readonly List<BookAuthor> _bookAuthors = new()
    {

    };

    public void Seed(EntityTypeBuilder<BookAuthor> builder) => builder.HasData(_bookAuthors);
}