using DataAccess.Data;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Implementations
{
    public class BrandRepository : GenericRepository<Brand>,IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
