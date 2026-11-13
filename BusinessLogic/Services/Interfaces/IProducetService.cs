using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Interfaces
{
    public interface IProducetService : IGenericService<ProductRequestDTO, ProductResponseDTO, Product>
    {
        public Task<long> CreateFile(ProductRequestDTO request);
        public Task<bool> DeleteFile(int id);
        public Task<bool> UpdateProductAsync(int id, ProductRequestDTO request);
    }
}
