using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Infrastructure.MailKit.Models
{
    public class EmailConfiguration
    {
        public string From { get; set; } = null;
        public string SmtpServer { get; set; } = null!;
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
