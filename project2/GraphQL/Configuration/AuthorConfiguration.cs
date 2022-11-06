﻿using GraphQL.Entitys;
using GraphQL.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasIndex(x => x.Name)
            .IsUnique()
            ;

        builder.Property(x => x.Name).HasMaxLength(100);

        new AuthorSeeder().Seed(builder);
    }
}