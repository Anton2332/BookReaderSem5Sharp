using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class RatingSeeder : ISeeder<Rating>
{
    private readonly List<Rating> _ratings = new()
    {

    };

    public void Seed(EntityTypeBuilder<Rating> builder) => builder.HasData(_ratings);
}