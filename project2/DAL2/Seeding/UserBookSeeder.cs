using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class UserBookSeeder : ISeeder<UserBook>
{
    private readonly List<UserBook> _usersBook = new()
    {

    };

    public void Seed(EntityTypeBuilder<UserBook> builder) => builder.HasData(_usersBook);
}