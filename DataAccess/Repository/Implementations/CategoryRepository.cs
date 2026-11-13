using DataAccess.Data;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Implementations
{
    public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context):base(context)
        {
        }
    }
}
