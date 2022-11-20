using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class BookCategorySeeder : ISeeder<BookCategory>
{
    private readonly List<BookCategory> _bookCategories = new()
    {
        new BookCategory()
        {
            Id = 1,
            BookId = 1,
            CategoryId = 1,
        },
        new BookCategory()
        {
            Id = 2,
            BookId = 1,
            CategoryId = 3,
        },
        new BookCategory()
        {
            Id = 3,
            BookId = 2,
            CategoryId = 2,
        },
        new BookCategory()
        {
            Id = 4,
            BookId = 4,
            CategoryId = 4,
        },
        new BookCategory()
        {
            Id = 5,
            BookId = 5,
            CategoryId = 2,
        },
        new BookCategory()
        {
            Id = 6,
            BookId = 6,
            CategoryId = 1,
        },
        new BookCategory()
        {
            Id = 7,
            BookId = 7,
            CategoryId = 1,
        },
        new BookCategory()
        {
            Id = 8,
            BookId = 8,
            CategoryId = 3,
        },
        new BookCategory()
        {
            Id = 9,
            BookId = 9,
            CategoryId = 1,
        },
        new BookCategory()
        {
            Id = 10,
            BookId = 10,
            CategoryId = 4,
        },
    };

    public void Seed(EntityTypeBuilder<BookCategory> builder) => builder.HasData(_bookCategories);
}