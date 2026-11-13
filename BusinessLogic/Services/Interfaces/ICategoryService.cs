using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Interfaces
{
    public interface ICategoryService : IGenericService<CategoryRequestDTO,CategoryResponseDTO,Category>
    {
    }
}
