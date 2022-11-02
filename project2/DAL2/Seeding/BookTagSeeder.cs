using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class BookTagSeeder : ISeeder<BookTag>
{
    private readonly List<BookTag> _bookTags = new()
    {

    };

    public void Seed(EntityTypeBuilder<BookTag> builder) => builder.HasData(_bookTags);
}