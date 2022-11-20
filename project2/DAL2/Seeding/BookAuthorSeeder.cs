using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class BookAuthorSeeder : ISeeder<BookAuthor>
{
    private readonly List<BookAuthor> _bookAuthors = new()
    {
        new BookAuthor()
        {
            Id = 1,
            BookId = 1,
            AuthorId = 1,
        },
        new BookAuthor()
        {
            Id = 2,
            BookId = 1,
            AuthorId = 3,
        },
        new BookAuthor()
        {
            Id = 3,
            BookId = 2,
            AuthorId = 2,
        },
        new BookAuthor()
        {
            Id = 4,
            BookId = 4,
            AuthorId = 4,
        },
        new BookAuthor()
        {
            Id = 5,
            BookId = 5,
            AuthorId = 2,
        },
        new BookAuthor()
        {
            Id = 6,
            BookId = 6,
            AuthorId = 1,
        },
        new BookAuthor()
        {
            Id = 7,
            BookId = 7,
            AuthorId = 1,
        },
        new BookAuthor()
        {
            Id = 8,
            BookId = 8,
            AuthorId = 3,
        },
        new BookAuthor()
        {
            Id = 9,
            BookId = 9,
            AuthorId = 1,
        },
        new BookAuthor()
        {
            Id = 10,
            BookId = 10,
            AuthorId = 4,
        },
    };

    public void Seed(EntityTypeBuilder<BookAuthor> builder) => builder.HasData(_bookAuthors);
}