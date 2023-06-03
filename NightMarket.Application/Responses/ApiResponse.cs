using Microsoft.AspNetCore.Http;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Responses
{
	public abstract class ApiResponseBase
	{
		public bool IsSuccess { get; set; }
		public string? Message { get; set; }
		public int?StatusCode { get; set; }

		protected ApiResponseBase(bool isSuccess, string? message, int? statusCode)
		{
			IsSuccess = isSuccess;
			Message = message;
			StatusCode = statusCode;
		}
	}
}
public class ApiResponse : ApiResponseBase
{
	public ApiResponse(bool isSuccess, string? message, int? statusCode) : base(isSuccess, message, statusCode)
	{
	}
    



    public static ApiResponse Success(int statusCode,string? message = null) => new(true, message, statusCode);
	public static ApiResponse Error(int statusCode, string? message = null) => new(false, message, statusCode);
}

public class ApiResponse<T> : ApiResponseBase
{
	public T? Data { get; set; }

	private ApiResponse(bool isSuccess, T? data, int? statusCode, string? message) : base(isSuccess, message, statusCode)
	{
		Data = data;
	}
	public static ApiResponse<T> Success(T? data, string? message = null) => new ApiResponse<T>(true, data, null, message);
	public static ApiResponse<T> Error(int statusCode, string? message = null) => new(false, default, statusCode, message);
}

