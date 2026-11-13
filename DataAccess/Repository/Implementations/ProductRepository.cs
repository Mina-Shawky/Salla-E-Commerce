using DataAccess.Data;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Implementations
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task DecreaseProductQuantityAsync(List<(int productId, int quantity)> items)
        {
            var productIds = items.Select(i => i.productId).ToList();
            if (productIds is null) throw new Exception("Product not found");

            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
            if (products is null) throw new Exception("Product not found");

            foreach (var product in products)
            {
                var item = items.First(i => i.productId == product.Id);
                if (product.Quantity < item.quantity)
                {
                    throw new Exception("Product stock not enough");
                }
                product.Quantity -= item.quantity;
            }

            await _context.SaveChangesAsync();
        }
    }
}
