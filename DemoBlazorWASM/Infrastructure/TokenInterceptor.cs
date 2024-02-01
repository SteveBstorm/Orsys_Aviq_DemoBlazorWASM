using Microsoft.JSInterop;

namespace DemoBlazorWASM.Infrastructure
{
    public class TokenInterceptor : DelegatingHandler
    {
        private readonly IJSRuntime JS;

        public TokenInterceptor(IJSRuntime js)
        {
            JS = js;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem","jwt");
            if(!string.IsNullOrEmpty(token))
            {
                request.Headers.Remove("Authorization");
                request.Headers.Add("Authorization", "Bearer " + token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
