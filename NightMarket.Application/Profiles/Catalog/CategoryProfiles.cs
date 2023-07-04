using AutoMapper;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Profiles.Catalog
{
	public class CategoryProfiles : Profile {
		public CategoryProfiles() {
			CreateMap<Categories, GetACategoryDto>().ReverseMap();
			CreateMap<Categories, GetAllCategoriesDto>().ReverseMap();
			CreateMap<Categories, CreateACategoryDto>().ReverseMap();
			CreateMap<Categories, UpdateACategoryDto>().ReverseMap();
			
		}
	}
}
