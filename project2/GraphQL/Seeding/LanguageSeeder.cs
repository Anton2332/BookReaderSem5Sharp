using GraphQL.Entitys;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Seeding;

public class LanguageSeeder : ISeeder<Language>
{
    private readonly List<Language> _languages = new()
    {

    };

    public void Seed(EntityTypeBuilder<Language> builder) => builder.HasData(_languages);
}