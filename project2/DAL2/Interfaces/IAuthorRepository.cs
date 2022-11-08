﻿using DAL2.Entitys;

namespace DAL2.Interfaces;

public interface IAuthorRepository : IRepository<Author>
{
    Task<IEnumerable<Author>> GetAllWithoutIdsAsync(int[] ids, string? orderBy = null);
}