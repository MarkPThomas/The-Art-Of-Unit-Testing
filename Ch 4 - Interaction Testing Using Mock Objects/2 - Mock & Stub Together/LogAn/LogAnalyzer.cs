using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class LogAnalyzer
    {
        public IWebService Service { get; set; }
        public IEmailService Email { get; set; }
        
        public LogAnalyzer(IWebService service, IEmailService email)
        {
            Service = service;
            Email = email;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    Service.LogError("Filename too short: " + fileName);
                }
                catch (Exception e)
                {
                    Email.SendEmail("someone@somewhere.com", "can't log", e.Message);
                }
            }
        }
    }
}
