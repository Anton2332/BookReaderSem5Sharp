using DAL2.Entitys;
using DAL2.Helpers;
using DAL2.Interfaces;
using DAL2.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL2.Repository;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(DBContext dbContext) : base(dbContext){}
}