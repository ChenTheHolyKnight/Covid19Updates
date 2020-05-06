using Covid19Backend.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.Formatter
{
    public class EmailBodyFormatter: IEmailBodyFormatter
    {
        
        public string GenerateEmailBody(DailyStats stats,string email)
        {
            DateTime date = DateTime.Today;
            string dateStr = string.Format("{0} {1}, {2}", date.Day, date.ToString("MMMM"), date.Year);
            string unsubscribeURL = "\"https://192.168.1.3:45457/emailUnreg/" + email+"\"";

            string body = string.Empty;

            body = @"<!doctype html>
                     <html lang=""en"">

                     <head>
                        <meta charset = ""UTF-8"">
                        <meta name = ""viewport"" content = ""width=device-width, initial-scale=1"">    
                        <link rel = ""stylesheet"" href = ""https://www.w3schools.com/w3css/4/w3.css"">       
                        <link rel = ""stylesheet"" href = ""https://fonts.googleapis.com/css?family=Raleway"">
                     </head> 
                     <style>
                        i {
                          border: solid red;
                          border-width: 0 3px 3px 0;
                          display: inline-block;
                          padding: 3px;
                          transform: rotate(-135deg);
                          -webkit-transform: rotate(-135deg);
                        }
                     </style>
                    
                     <!-- Header -->
                     <header class=""w3-container w3-center w3-padding-32"">
                        <h1><b> Covid- 19 Updates </b></h1>
                     </header >
                     <div style=""margin-left: 10vw; margin-right: 10vw"">    
                        <div class=""w3-card-4 w3-margin w3-white"">
                            <img src = ""https://www.knowablemagazine.org/sites/default/files/styles/1600_600/public/articles/442/coronavirus-structure-1600x600_0.jpg?itok=usw1MShH"" style=""width:100%;height:40vh;"">
                            <div class=""w3-container"">
                                <h3><b>New Zealand</b></h3>
                                <h5><b>Summary on</b> <span class=""w3-opacity"">" + dateStr+@"</span></h5>
                            </div>
                            <div class=""w3-container"">
                                <p>Number of confirmed cases:   " +	stats.ConfirmedCases +  @"</p>
                                <p>Number of probable cases:    " +	stats.ProbableCases + @"</p>
                                <p>Number of recovered cases:   " + stats.RecoveredCases + @"</p>
                                <p>Number of deaths:            "+	stats.TotalDeath + @"</p>
                                <div class=""w3-row"">
                                    <div class=""w3-col m8 s12"">
                                        <p><button class=""w3-button w3-padding-large w3-white w3-border""><b>READ MORE »</b></button></p>
                                </div>
                            </div>
                        </div>
                     </div>
                     <hr>
                    </div>
                         <p class=""w3-center"" style=""text-align: center;""><a href=""https://192.168.1.3:45457/emailUnreg/czha959@aucklanduni.ac.nz"">Unsubscribe</a></p>

                    

                    </html>";
            return body;
        }
    }
}
