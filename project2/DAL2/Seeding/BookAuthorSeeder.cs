using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class BookAuthorSeeder : ISeeder<BookAuthor>
{
    private readonly List<BookAuthor> _bookAuthors = new()
    {

    };

    public void Seed(EntityTypeBuilder<BookAuthor> builder) => builder.HasData(_bookAuthors);
}