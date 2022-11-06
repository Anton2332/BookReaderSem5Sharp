using GraphQL.Entitys;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Seeding;

public class StatusSeeder : ISeeder<Status>
{
    private readonly List<Status> _statusList = new()
    {

    };

    public void Seed(EntityTypeBuilder<Status> builder) => builder.HasData(_statusList);
}