using BusinessLogic.Services.Interfaces;
using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Implementations
{
    public class BrandService : GenericService<BrandRequestDTO, BrandResponseDTO, Brand>, IBrandService
    {
        private readonly IFileService _fileService;
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository, IFileService fileService) : base(brandRepository)
        {
            _fileService = fileService;
            _brandRepository = brandRepository;
        }

        public async Task<int> CreateFileAsync(BrandRequestDTO requestDTO)
        {
            var entity = requestDTO.Adapt<Brand>();
            entity.CreatedDate = DateTime.Now;
            if(requestDTO.Image != null)
            {
                var imagePath = await _fileService.UploadAsync(requestDTO.Image);
                entity.Image = imagePath;
            }
            await _brandRepository.Create(entity);
            return entity.Id;
        }

        public async Task<bool> DeleteFileAsync(int id)
        {
            var entity =await _brandRepository.GetById(id);
            bool successDelete = await _fileService.DeleteAsync(entity.Image);
            if (successDelete is false)
                throw new Exception("Error");
            await _brandRepository.Delete(entity);
            return true;
        }
    }
}
