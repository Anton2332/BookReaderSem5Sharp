using GraphQL.Entitys;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Seeding;

public class CategorySeeder : ISeeder<Category>
{
    private readonly List<Category> _categories = new()
    {

    };

    public void Seed(EntityTypeBuilder<Category> builder) => builder.HasData(_categories);
}