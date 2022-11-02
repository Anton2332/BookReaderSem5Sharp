using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class CategorySeeder : ISeeder<Category>
{
    private readonly List<Category> _categories = new()
    {

    };

    public void Seed(EntityTypeBuilder<Category> builder) => builder.HasData(_categories);
}