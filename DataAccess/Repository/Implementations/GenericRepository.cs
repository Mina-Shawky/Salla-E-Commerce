using DataAccess.Data;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            var data = await _context.Set<T>().OrderByDescending(e => e.CreatedDate).ToListAsync();
            return (data);
        }
        public async Task<T> GetById(int id)
        {
            var data = await _context.Set<T>().FirstOrDefaultAsync(e=>e.Id == id);
            return (data);
        }
        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChangesInDatabase()
        {
            await _context.SaveChangesAsync();
        }
    }
}
