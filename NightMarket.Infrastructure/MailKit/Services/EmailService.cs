using MailKit.Net.Smtp;
using MimeKit;
using NightMarket.Infrastructure.MailKit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Infrastructure.MailKit.Services
{
	public class EmailService : IEmailService
	{
		private readonly EmailConfiguration _emailConfiguration;
		public EmailService(EmailConfiguration emailConfiguration)
		{
			_emailConfiguration = emailConfiguration;
		}


		public void SendEmail(Message message)
		{
			var emailMessage = CreateEmailMessage(message);
			Send(emailMessage);
		}

		private MimeMessage CreateEmailMessage(Message message)
		{
			var emailMessage = new MimeMessage();
			emailMessage.From.Add(new MailboxAddress("email", _emailConfiguration.From));
			emailMessage.To.AddRange(message.To);
			emailMessage.Subject = message.Subject;
			emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
			{
				Text = message.Content
			};
			return emailMessage;
		}

		private void Send(MimeMessage mailMessage)
		{
			using var client = new SmtpClient();
			try
			{
				client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
				client.AuthenticationMechanisms.Remove("XOAUTH2");
				client.Authenticate(_emailConfiguration.Username, _emailConfiguration.Password);
				client.Send(mailMessage);
			}
			catch (Exception ex)
			{
				//log an error message or throw an exeption or both
				Console.WriteLine(ex.Message);

			}
			finally
			{
				client.Disconnect(true);
				client.Dispose();
			}

		}

	}
}
