using GraphQL.Entitys;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Seeding;

public class UserBookSeeder : ISeeder<UserBook>
{
    private readonly List<UserBook> _usersBook = new()
    {

    };

    public void Seed(EntityTypeBuilder<UserBook> builder) => builder.HasData(_usersBook);
}