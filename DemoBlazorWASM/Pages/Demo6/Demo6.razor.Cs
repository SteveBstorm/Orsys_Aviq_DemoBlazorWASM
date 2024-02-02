using DemoBlazorWASM.Pages.Demo3;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http.Json;

namespace DemoBlazorWASM.Pages.Demo6
{
    public partial class Demo6
    {
        public List<Movie> Liste { get; set; }

        [Inject]
        public IHttpClientFactory HttpClientFactory { get; set; }
        public HttpClient client { get; set; }

        public HubConnection Hub { get; set; }

        protected override async Task OnInitializedAsync()
        {
            client = HttpClientFactory.CreateClient("apiDemo");

            Hub = new HubConnectionBuilder().WithUrl("https://localhost:7200/moviehub").Build();

            await Hub.StartAsync();

            Hub.On("NotifyNewMovie", async () =>
            {
                await LoadData();
                StateHasChanged();
            });

            await LoadData();
        }

        private async Task LoadData()
        {
            Liste = await client.GetFromJsonAsync<List<Movie>>("movie");

        }
    }
}
