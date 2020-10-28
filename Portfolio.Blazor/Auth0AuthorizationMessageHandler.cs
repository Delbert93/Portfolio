using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Portfolio.BlazorWasm
{
    public class Auth0AuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public Auth0AuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigationManager, IConfiguration config) : base(provider, navigationManager)
        {
            this.ConfigureHandler(
                authorizedUrls: new[] { config["APIBaseAddress"], "http://localhost:5005", "https://lloyd-portfoli.herokuapp.com/", "https://myportfolio.snow.edu" }
            );
        }
    }
}