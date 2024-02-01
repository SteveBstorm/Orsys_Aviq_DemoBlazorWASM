using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Diagnostics.Metrics;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace DemoBlazorWASM.Security
{
    //Microsoft.AspNetCore.Components.Authorization
    public class MyStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime JS;
        public MyStateProvider(IJSRuntime js)
        {
            JS = js;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "jwt");

            if(string.IsNullOrEmpty(token))
            {
                ClaimsIdentity anonymousUser = new ClaimsIdentity();
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymousUser)));
            }

            JwtSecurityToken jwt = new JwtSecurityToken(token);
            //string role = jwt.Claims.First(x => x.Type == ClaimTypes.Role).Value;

            ClaimsIdentity currentUser = new ClaimsIdentity(jwt.Claims, "myAuth");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(currentUser)));
        }

        public void NotifyUserChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
