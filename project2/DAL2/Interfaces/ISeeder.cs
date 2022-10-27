using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Interfaces;

public interface ISeeder<T> where T : class
{
    void Seed(EntityTypeBuilder<T> builder);
}