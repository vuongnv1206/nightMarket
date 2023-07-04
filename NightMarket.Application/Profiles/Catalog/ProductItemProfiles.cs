using AutoMapper;
using NightMarket.Application.DTOs.Catalogs.ProductItemDto;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Profiles.Catalog
{
	public class ProductItemProfiles : Profile
	{
        public ProductItemProfiles()
        {
			CreateMap<ProductItems, CreateAProductItemDto>().ReverseMap();
			CreateMap<ProductItems, GetAllProductItemsDto>().ReverseMap();
			CreateMap<ProductItems, GetAProductItemDto>().ReverseMap();
			CreateMap<ProductItems, UpdateAProductItemDto>().ReverseMap();
		}
    }
}
