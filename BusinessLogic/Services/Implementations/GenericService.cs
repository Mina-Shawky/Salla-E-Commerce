using Azure.Core;
using BusinessLogic.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repository.Implementations;
using DataAccess.Repository.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Implementations
{
    public class GenericService<TRequest, TResponse, TEntity> : IGenericService<TRequest, TResponse, TEntity> where TEntity : BaseModel where TResponse : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task CreateAsync(TRequest request)
        {
            TEntity tEntity = request.Adapt<TEntity>();
            await _genericRepository.Create(tEntity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _genericRepository.GetById(id);
            if (entity == null)
                return false;
            await _genericRepository.Delete(entity);
            return true;
        }

        public async Task<List<TResponse>> GetAllAsync()
        {
            var entities = await _genericRepository.GetAll();

            return entities.Adapt<List<TResponse>>();
        }

        public async Task<TResponse> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetById(id);
            return (entity is null)? null : entity.Adapt<TResponse>();

        }

        public async Task<bool> ToggleStatus(int id)
        {
            var entity =await _genericRepository.GetById(id);
            if (entity == null)
                return false;
            entity.Status = (entity.Status == Status.Active) ? Status.InActive : Status.Active;
            await _genericRepository.SaveChangesInDatabase();
            return true;
        }

        public async Task<bool> Update(int id, TRequest request)
        {
            var entity = _genericRepository.GetById(id);
            if (entity is null) return false;
            var updatedEntity = request.Adapt(entity);
            await _genericRepository.SaveChangesInDatabase();

            return true;
        }
    }
}
