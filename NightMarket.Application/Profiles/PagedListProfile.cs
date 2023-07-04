﻿using AutoMapper;
using NightMarket.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Profiles
{
	public class PagedListProfile : Profile
	{
        public PagedListProfile()
        {
			CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(PagedListConverter<,>));
		}
    }

	public class PagedListConverter<TSource, TDestination> : ITypeConverter<PagedList<TSource>, PagedList<TDestination>>
	{
		public PagedList<TDestination> Convert(PagedList<TSource> source, PagedList<TDestination> destination, ResolutionContext context)
		{
			var mappedItems = context.Mapper.Map<List<TDestination>>(source);
			return new PagedList<TDestination>(mappedItems, source.TotalCount, source.CurrentPage, source.PageSize);
		}
	}
}
