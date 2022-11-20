using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class CategorySeeder : ISeeder<Category>
{
    private readonly List<Category> _categories = new()
    {
        new Category()
        {
            Id = 1,
            Name = "Ethnic & Cultural"
        },
        new Category()
        {
            Id = 2,
            Name = "Europe"
        },
        new Category()
        {
            Id = 3,
            Name = "Historical"
        },
        new Category()
        {
            Id = 4,
            Name = "Military"
        }

    };

    public void Seed(EntityTypeBuilder<Category> builder) => builder.HasData(_categories);
}