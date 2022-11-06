using GraphQL.Entitys;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Seeding;

public class BookCategorySeeder : ISeeder<BookCategory>
{
    private readonly List<BookCategory> _bookCategories = new()
    {

    };

    public void Seed(EntityTypeBuilder<BookCategory> builder) => builder.HasData(_bookCategories);
}