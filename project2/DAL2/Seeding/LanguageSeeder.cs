using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class LanguageSeeder : ISeeder<Language>
{
    private readonly List<Language> _languages = new()
    {
        new Language()
        {
            Id = 1,
            Name = "Ukraine",
            Abbreviated = "UKR"
        }
    };

    public void Seed(EntityTypeBuilder<Language> builder) => builder.HasData(_languages);
}