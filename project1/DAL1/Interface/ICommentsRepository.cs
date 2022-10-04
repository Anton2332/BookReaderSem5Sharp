﻿using DAL1.Model;

namespace DAL1.Interface;

public interface ICommentsRepository : IGenericRepository<BaseComments>
{

    Task<IEnumerable<Comments>> GetAllByBookIdAsync(int id);

    Task<IEnumerable<Comments>> GetAllByCommentsIdAsync(int id);

}