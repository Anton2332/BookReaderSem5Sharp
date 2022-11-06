using GraphQL.Entitys;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Seeding;

public class PageSeeder : ISeeder<Page>
{
    private readonly List<Page> _pages = new()
    {

    };

    public void Seed(EntityTypeBuilder<Page> builder) => builder.HasData(_pages);
}