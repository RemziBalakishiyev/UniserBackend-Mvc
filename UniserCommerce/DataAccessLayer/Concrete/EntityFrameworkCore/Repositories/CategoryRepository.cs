using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFrameworkCore.Contexts;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategory
    {
        public CategoryRepository(UniserContext uniserContext) : base(uniserContext)
        {
        }


    }
}
