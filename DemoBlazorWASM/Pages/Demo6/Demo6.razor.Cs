using DemoBlazorWASM.Pages.Demo3;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DemoBlazorWASM.Pages.Demo6
{
    public partial class Demo6
    {
        public List<Movie> Liste { get; set; }

        [Inject]
        public IHttpClientFactory HttpClientFactory { get; set; }
        public HttpClient client { get; set; }

        protected override async Task OnInitializedAsync()
        {
            client = HttpClientFactory.CreateClient("apiDemo");
            Liste = await client.GetFromJsonAsync<List<Movie>>("movie");
        }
    }
}
