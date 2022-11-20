using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class BookSeeder : ISeeder<Book>
{
    private readonly List<Book> _books = new()
    {
        new Book()
        {
            Id = 1,
            Image = new byte[]{},
            Name = "First book",
            Description = "Text for first book",
            LanguageId = 1,
            StatusId = 1,
        },
        new Book()
        {
            Id = 2,
            Image = new byte[]{},
            Name = "Second book",
            Description = "Text for second book",
            LanguageId = 1,
            StatusId = 2,
        },
        new Book()
        {
            Id = 3,
            Image = new byte[]{},
            Name = "3 book",
            Description = "Text for 3 book",
            LanguageId = 1,
            StatusId = 2,
        },
        new Book()
        {
            Id = 4,
            Image = new byte[]{},
            Name = "4 book",
            Description = "Text for 4 book",
            LanguageId = 1,
            StatusId = 3,
        },
        new Book()
        {
            Id = 5,
            Image = new byte[]{},
            Name = "5 book",
            Description = "Text for 5 book",
            LanguageId = 1,
            StatusId = 1,
        },
        new Book()
        {
            Id = 6,
            Image = new byte[]{},
            Name = "6 book",
            Description = "Text for 6 book",
            LanguageId = 1,
            StatusId = 2,
        },
        new Book()
        {
            Id = 7,
            Image = new byte[]{},
            Name = "7 book",
            Description = "Text for 7 book",
            LanguageId = 1,
            StatusId = 3,
        },
        new Book()
        {
            Id = 8,
            Image = new byte[]{},
            Name = "8 book",
            Description = "Text for 8 book",
            LanguageId = 1,
            StatusId = 2,
        },
        new Book()
        {
            Id = 9,
            Image = new byte[]{},
            Name = "9 book",
            Description = "Text for 9 book",
            LanguageId = 1,
            StatusId = 1,
        },
        new Book()
        {
            Id = 10,
            Image = new byte[]{},
            Name = "10 book",
            Description = "Text for 10 book",
            LanguageId = 1,
            StatusId = 2,
        }
    };

    public void Seed(EntityTypeBuilder<Book> builder) => builder.HasData(_books);
}