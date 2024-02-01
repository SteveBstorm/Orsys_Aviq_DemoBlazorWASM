using DemoBlazorWASM.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DemoBlazorWASM.Pages.Auth
{
    public partial class Register
    {
        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }

        public UserRegister Form { get; set; }
        public Register()
        {
            Form = new UserRegister();
        }

        public async Task Submit()
        {
            await Client.PostAsJsonAsync("Auth/register", Form);
            Nav.NavigateTo("/login");
        }
    }
}
