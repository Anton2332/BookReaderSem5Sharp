using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class BookCategorySeeder : ISeeder<BookCategory>
{
    private readonly List<BookCategory> _bookCategories = new()
    {

    };

    public void Seed(EntityTypeBuilder<BookCategory> builder) => builder.HasData(_bookCategories);
}