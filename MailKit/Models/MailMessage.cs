using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailKitDemo.Models
{
    public class MailMessage
    {
        public List<InternetAddress> From { get; set; }
        public List<InternetAddress> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
