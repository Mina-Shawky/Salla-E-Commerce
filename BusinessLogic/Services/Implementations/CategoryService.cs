using BusinessLogic.Services.Interfaces;
using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Implementations
{
    public class CategoryService : GenericService<CategoryRequestDTO, CategoryResponseDTO, Category>,ICategoryService
    {
        public CategoryService(ICategoryRepository categoryRepository):base(categoryRepository)
        {
            
        }
    }
}
