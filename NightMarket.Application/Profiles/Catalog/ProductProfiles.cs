using AutoMapper;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Profiles.Catalog
{
	public class ProductProfiles : Profile
	{
        public ProductProfiles()
        {
			CreateMap<Products, GetAProductDto>().ReverseMap();
			CreateMap<Products, GetAllProductsDto>().ReverseMap();
			CreateMap<Products, CreateAProductDto>().ReverseMap();
			CreateMap<Products, UpdateAProductDto>().ReverseMap();
		}
    }
}
