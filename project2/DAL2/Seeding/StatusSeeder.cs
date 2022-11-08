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
            Id = 0,
            Name = "finished"
        },
        new Status()
        {
            Id = 0,
            Name = "to throw"
        },
        new Status()
        {
        Id = 0,
        Name = "continues"
        }
        
    };

    public void Seed(EntityTypeBuilder<Status> builder) => builder.HasData(_statusList);
}