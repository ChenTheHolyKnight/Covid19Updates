﻿using Microsoft.AspNetCore.Http;
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

            body = @"<!doctype html>
                     <html lang=""en"">

                     <head>
                        <meta charset = ""UTF-8"">
                        <meta name = ""viewport"" content = ""width=device-width, initial-scale=1"">    
                        <link rel = ""stylesheet"" href = ""https://www.w3schools.com/w3css/4/w3.css"">       
                        <link rel = ""stylesheet"" href = ""https://fonts.googleapis.com/css?family=Raleway"">
                     </head> 
                    
                     <!-- Header -->
                     <header class=""w3-container w3-center w3-padding-32"">
                        <h1><b> Covid- 19 Updates </b></h1>
                     </header >
                     <div style=""margin-left: 10vw; margin-right: 10vw"">    
                        <div class=""w3-card-4 w3-margin w3-white"">
                            <img src = ""https://www.knowablemagazine.org/sites/default/files/styles/1600_600/public/articles/442/coronavirus-structure-1600x600_0.jpg?itok=usw1MShH"" style=""width:100%;height:40vh;"">
                            <div class=""w3-container"">
                                <h3><b>New Zealand</b></h3>
                                <h5><b>Summary on</b> <span class=""w3-opacity"">April 2, 2020</span></h5>
                            </div>
                            <div class=""w3-container"">
                                <p>Number of confirmed cases:	723</p>
                                <p>Number of probable cases:	74</p>
                                <p>Number of recovered cases:	92</p>
                                <p>TNumber of deaths:	1</p>
                                <div class=""w3-row"">
                                    <div class=""w3-col m8 s12"">
                                        <p><button class=""w3-button w3-padding-large w3-white w3-border""><b>READ MORE »</b></button></p>
                                </div>
                            </div>
                        </div>
                     </div>
                     <hr>
                    </div>

                    </html>";
            return body;
        }
    }
}