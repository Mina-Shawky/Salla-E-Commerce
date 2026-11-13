using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Interfaces
{
    public interface IGenericService<TRequest ,TResponse, TEntity>
    {
        public Task<List<TResponse>> GetAllAsync();
        public Task<TResponse> GetByIdAsync(int id);
        public Task CreateAsync(TRequest request);
        public Task<bool> Update(int id, TRequest request);
        public Task<bool> ToggleStatus(int id);
        public Task<bool> Delete(int id);
    }
}
