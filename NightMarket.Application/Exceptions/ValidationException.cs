using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace NightMarket.Application.Exceptions
{
	public class ValidationException : ApplicationException
	{
		public List<string> Errors { get; set; } = new List<string>();

		public ValidationException(ValidationResult validationResult)
		{
			foreach (var error in validationResult.Errors)
			{
				Errors.Add(error.ErrorMessage);
			}
		}

		

		public ValidationException(string? message) : base(message)
		{
		}

		public ValidationException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
