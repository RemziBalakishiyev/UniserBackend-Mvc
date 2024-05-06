using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFrameworkCore.Contexts;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProduct
    {
        public ProductRepository(UniserContext uniserContext) : base(uniserContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductList()
        {
            var products = await Table.Include(x => x.Category).ToListAsync();
            return products;
        }

        public async Task<ProductReport> GetReport()
        {
            var reports = await GetMember<ProductReport>().FirstOrDefaultAsync();
            return reports;
        }
    }
}
