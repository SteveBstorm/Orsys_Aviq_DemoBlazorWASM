using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using DemoBlazorWASM.Security;

namespace DemoBlazorWASM.Pages.Auth
{
    public partial class Logout
    {
        [Inject]
        public NavigationManager Nav { get; set; }
        [Inject]
        public IJSRuntime JS { get; set; }

        [Inject]
        public AuthenticationStateProvider StateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await JS.InvokeVoidAsync("localStorage.clear");
            ((MyStateProvider)StateProvider).NotifyUserChanged();
            Nav.NavigateTo("/");
        }
    }
}
