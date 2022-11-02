using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class BookSeeder : ISeeder<Book>
{
    private readonly List<Book> _books = new()
    {

    };

    public void Seed(EntityTypeBuilder<Book> builder) => builder.HasData(_books);
}