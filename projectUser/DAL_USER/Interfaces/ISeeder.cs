﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL_USER.Interfaces;

public interface ISeeder<T> where T: class
{
    void Seed(EntityTypeBuilder<T> builder);
}