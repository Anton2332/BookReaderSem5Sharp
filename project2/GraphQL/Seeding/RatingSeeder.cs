using GraphQL.Entitys;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Seeding;

public class RatingSeeder : ISeeder<Rating>
{
    private readonly List<Rating> _ratings = new()
    {

    };

    public void Seed(EntityTypeBuilder<Rating> builder) => builder.HasData(_ratings);
}