using Microsoft.AspNetCore.Components;

namespace DemoBlazorWASM.Pages.Demo2
{
    public partial class Children
    {
        [Parameter]
        public int ValueFromParent { get; set; }

        [Parameter]
        public EventCallback<string> MyEvent { get; set; }

        public string MyString { get; set; }

        public async Task Send()
        {
           await MyEvent.InvokeAsync(MyString);
        }

        protected override async Task OnParametersSetAsync()
        {
            ValueFromParent *= 2;
        }
    }
}
