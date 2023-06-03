using NightMarket.Infrastructure.MailKit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Infrastructure.MailKit.Services
{
	public interface IEmailService
	{
		void SendEmail(Message message);
	}
}
