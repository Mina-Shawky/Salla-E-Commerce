using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Interfaces
{
    public interface IBrandService : IGenericService<BrandRequestDTO, BrandResponseDTO,Brand>
    {
        public Task<int> CreateFileAsync(BrandRequestDTO requestDTO);
        public Task<bool> DeleteFileAsync(int id);
    }
}
