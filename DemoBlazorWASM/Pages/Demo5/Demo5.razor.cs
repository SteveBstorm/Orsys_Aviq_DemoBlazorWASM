using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DemoBlazorWASM.Pages.Demo5
{
    public partial class Demo5
    {
        [Inject]
        public IJSRuntime JS { get; set; }

        public string Value { get; set; }

        public async Task SaveValue()
        {
            await JS.InvokeVoidAsync("localStorage.setItem", "myValue", Value);
        }
    }
}
