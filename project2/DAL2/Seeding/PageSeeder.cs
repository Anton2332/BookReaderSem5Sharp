using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class PageSeeder : ISeeder<Page>
{
    private readonly List<Page> _pages = new()
    {
        
    };

    public void Seed(EntityTypeBuilder<Page> builder) => builder.HasData(_pages);
}