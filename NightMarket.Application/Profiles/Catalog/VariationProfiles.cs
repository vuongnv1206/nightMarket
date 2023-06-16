using AutoMapper;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.DTOs.Catalogs.Variations;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Profiles.Catalog
{
	public class VariationProfiles : Profile
	{
        public VariationProfiles()
        {
			CreateMap<Variations, GetAVariationDto>().ReverseMap();
			CreateMap<Variations, GetAllVariationDto>().ReverseMap();
			CreateMap<Variations, CreateAVariationDto>().ReverseMap();
			CreateMap<Variations, UpdateAVariationDto>().ReverseMap();
		}
    }
}
