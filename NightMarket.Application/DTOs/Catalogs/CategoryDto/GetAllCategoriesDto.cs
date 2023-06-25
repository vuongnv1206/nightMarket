using NightMarket.Application.DTOs.Common;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.Categories
{
	public class GetAllCategoriesDto : BaseDto
	{
		public string Name { get; set; }
		public string Slug { get; set; }
		public string? Description { get; set; }	
		public string? ShortDescription { get; set; }
		public CategoryStatus Status { get; set; }
		public DateTime? PublishDate { get; set; }
		public DateTime DateCreated { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? LastModifiedDate { get; set; }
		public string? LastModifiedBy { get; set; }
	}
}
