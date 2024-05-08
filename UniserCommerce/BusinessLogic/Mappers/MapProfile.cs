using AutoMapper;
using BusinessLogic.Dtos;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mappers
{
    internal class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product,ProductListDto>()
                .ForMember(x=>x.StockInHand,s=>s.MapFrom(y=>y.InStock ? "Stokda var":"Stokda yoxdur"))
                .ForMember(x=>x.CategoryName,s=>s.MapFrom(y=>y.Category.Name))
                .ReverseMap();


            CreateMap<ProductAddDto, Product>()
                .ForMember(x => x.InStock, s => s.MapFrom(y => y.Quantity > 0));

            CreateMap<Category, CategoryListDto>().ReverseMap();

            CreateMap<UserRegisterDto, User>()
                .ForMember(x=>x.PasswordHash,s=>s.MapFrom(y=>y.Password))
                .ReverseMap();
        }
    }
}
