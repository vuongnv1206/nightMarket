using AutoMapper;
using NightMarket.Application.DTOs.Catalogs.VariationOptionDto;
using NightMarket.Application.DTOs.Catalogs.Variations;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Profiles.Catalog
{
	public class VariationOptionProfile : Profile
	{
        public VariationOptionProfile()
        {
			CreateMap<VariationOptions, GetVariationOptionDto>().ReverseMap();
			CreateMap<VariationOptions, CreateAVariationOptionDto>().ReverseMap();
			CreateMap<VariationOptions, UpdateAVariationOptionDto>().ReverseMap();
		}
    }
}
