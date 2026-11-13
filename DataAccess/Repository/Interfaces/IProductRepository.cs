using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task DecreaseProductQuantityAsync(List<(int productId, int quantity)> items);

    }
}
