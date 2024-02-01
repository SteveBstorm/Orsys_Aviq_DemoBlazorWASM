using DemoBlazorWASM.Models;
using DemoBlazorWASM.Security;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace DemoBlazorWASM.Pages.Auth
{
    public partial class Login
    {
        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }
        [Inject]
        public IJSRuntime JS { get; set; }

        [Inject]
        public AuthenticationStateProvider StateProvider { get; set; }

        public UserLogin Form { get; set; }
        public Login()
        {
            Form = new UserLogin();
        }

        public async Task Submit()
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync("Auth/login", Form);
            string token = await response.Content.ReadAsStringAsync();

            await JS.InvokeVoidAsync("localStorage.setItem", "jwt", token);
            ((MyStateProvider)StateProvider).NotifyUserChanged();
            
            Nav.NavigateTo("/login");
        }
    }
}
