using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class StatusSeeder : ISeeder<Status>
{
    private readonly List<Status> _statusList = new()
    {
        new Status()
        {
            Id = 1,
            Name = "finished"
        },
        new Status()
        {
            Id = 2,
            Name = "to throw"
        },
        new Status()
        {
            Id = 3,
            Name = "continues"
        }
        
    };

    public void Seed(EntityTypeBuilder<Status> builder) => builder.HasData(_statusList);
}