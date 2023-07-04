using AutoMapper;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.DTOs.Catalogs.ProductCategoryDto;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Profiles.Catalog
{
	public class ProductCategoryProfiles : Profile
	{
        public ProductCategoryProfiles()
        {
			CreateMap<ProductCategories, ProductCategoryDto>().ReverseMap();
		}
    }
}
