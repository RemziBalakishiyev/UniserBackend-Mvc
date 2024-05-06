using BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListDto>> GetCategoriesAsync();
        Task AddCategoryAsync(CategoryListDto categoryList);
    }
}
