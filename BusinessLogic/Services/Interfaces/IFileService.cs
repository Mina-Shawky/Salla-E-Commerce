using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Interfaces
{
    public interface IFileService
    {
        public Task<string> UploadAsync(IFormFile file);
        public Task<bool> DeleteAsync(string fileName);
    }
}
