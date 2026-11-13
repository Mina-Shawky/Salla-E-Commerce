using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task Create(T entity);
        public Task Delete(T entity);
        public Task SaveChangesInDatabase();
    }
}
