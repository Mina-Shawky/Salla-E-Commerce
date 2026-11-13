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
    public class ProducetService : GenericService<ProductRequestDTO, ProductResponseDTO, Product>, IProducetService
    {
        private readonly IFileService _fileService;
        private readonly IProductRepository _productRepository;
        public ProducetService(IProductRepository productRepository, IFileService fileService) : base(productRepository)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }

        public async Task<long> CreateFile(ProductRequestDTO request)
        {
            var entity = request.Adapt<Product>();
            entity.CreatedDate = DateTime.Now;
            if(request.MainImage != null)
            {
                var imagePath = await _fileService.UploadAsync(request.MainImage);
                entity.MainImage = imagePath;
            }
            await _productRepository.Create(entity);
            return entity.Id;
        }

        public async Task<bool> DeleteFile(int id)
        {
            var entity =await _productRepository.GetById(id);
            bool successDelete = await _fileService.DeleteAsync(entity.MainImage);
            if (successDelete is false)
                throw new Exception("Error");
            await _productRepository.Delete(entity);
            return true;
        }

        public async Task<bool> UpdateProductAsync(int id, ProductRequestDTO request)
        {
            var entity = await _productRepository.GetById(id);
            if (entity is null) return false;
            entity.Name = request.Name!;
            entity.Price = (decimal)request.Price!;
            entity.Quantity = request.Quantity;
            if (request.MainImage is not null)
            {
                if (!string.IsNullOrEmpty(entity.MainImage))
                {
                    await _fileService.DeleteAsync(entity.MainImage);
                }
                string newImage = await _fileService.UploadAsync(request.MainImage);
                entity.MainImage = newImage;

            }
            await _productRepository.SaveChangesInDatabase();
            return true;
        }
    }
}
