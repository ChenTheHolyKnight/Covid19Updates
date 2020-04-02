using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.Formatter
{
    public class EmailBodyFormatter
    {
        
        public string GenerateEmailBody()
        {
            string body = string.Empty;
            body = File.ReadAllText("./Services/Formatter/email.html");
            return body;
        }
    }
}
