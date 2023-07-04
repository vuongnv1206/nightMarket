using AutoMapper;
using NightMarket.Application.DTOs.Catalogs.ProductConfigurationDto;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Domain.Entities.Catalogs;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Profiles.Catalog
{
	public class ProductCombinationProfiles : Profile
	{
        public ProductCombinationProfiles()
        {
			CreateMap<ProductCombinations, ProductCombinationDto>().ReverseMap();
		}
    }
}
