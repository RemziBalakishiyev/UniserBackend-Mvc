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
    public class ProductService : IProductService
    {
        private readonly IProduct _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProduct productRepository, IMapper mapper)// new ProductRepo();
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductAddDto product)
        {
            if (product is null)
            {
                throw new Exception("Product is null");
            }

            var data = _mapper.Map<Product>(product);
            await _productRepository.AddAsync(data);

            await _productRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductListDto>> GetProductListAsync()
        {
            var productList = _mapper.Map<IEnumerable<ProductListDto>>(await _productRepository.GetProductList());
            return productList;
        }




        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.GetAllAsync();
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
