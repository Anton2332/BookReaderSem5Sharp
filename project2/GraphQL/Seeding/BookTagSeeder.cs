using GraphQL.Entitys;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Seeding;

public class BookTagSeeder : ISeeder<BookTag>
{
    private readonly List<BookTag> _bookTags = new()
    {

    };

    public void Seed(EntityTypeBuilder<BookTag> builder) => builder.HasData(_bookTags);
}