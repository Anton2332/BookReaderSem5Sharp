﻿using DAL2.Entitys;
using DAL2.Interfaces;
using DAL2.Seeding;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class AuthorSeeder : ISeeder<Author>
{
    private readonly List<Author> _authors = new()
    {
        new Author()
        {
            Id = 0,
            Name = "Сергій Жадан"
        },
        new Author()
        {
            Id = 0,
            Name = "Грицак Ярослав"
        },
        new Author()
        {
            Id = 0,
            Name = "Дал Роальд"
        },
        new Author()
        {
            Id = 0,
            Name = "Дашвар Люко"
        },
        new Author()
        {
            Id = 0,
            Name = "Дочинець Мирослав"
        },
    };

    public void Seed(EntityTypeBuilder<Author> builder) => builder.HasData(_authors);
}