using AutoMapper;
using BusinessLogic.Abstract;
using BusinessLogic.Dtos;
using DataAccessLayer.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategory _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategory categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddCategoryAsync(CategoryListDto categoryList)
        {
            var category = _mapper.Map<Category>(categoryList);
            var result = await _categoryRepository.AddAsync(category);

            if (result is false)
            {
                throw new Exception("Category can't added");
            }
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryListDto>> GetCategoriesAsync()
        {
            return _mapper.Map<IEnumerable<CategoryListDto>>(await _categoryRepository.GetAllAsync());
        }
    }
}
