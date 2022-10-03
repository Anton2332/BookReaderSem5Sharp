﻿using DAL1.Model;

namespace DAL1.Interface;

public interface ILikeRepository : IGenericRepository<Like>
{
    Task<int> GetIdByBodyAsync(string str);
}