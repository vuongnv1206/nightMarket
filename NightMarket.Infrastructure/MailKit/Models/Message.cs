﻿using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Infrastructure.MailKit.Models
{
	public class Message
	{
		public List<MailboxAddress> To { get; set; }   // Địa chỉ gửi đến
		public string Subject { get; set; }         // Chủ đề (tiêu đề email)
		public string Content { get; set; }             // Nội dung (hỗ trợ HTML) của email

		public Message(IEnumerable<string> to, string subject, string content)
		{
			To = new List<MailboxAddress>();
			To.AddRange(to.Select(x => new MailboxAddress("email", x)));
			Subject = subject;
			Content = content;
		}
	}
}
