﻿using DAL2.Entitys;
using DAL2.Interfaces;

namespace DAL2.Repository;

public class ChapterRepository : GenericRepository<Chapter>, IChapterRepository
{
    public ChapterRepository(DBContext dbContext) : base(dbContext) {}
}