using Microsoft.AspNetCore.Components;

namespace DemoBlazorWASM.Pages.Exercices.Exo1
{
    public partial class Question
    {
        [Parameter]
        public string Nickname { get; set; }
        [Parameter]
        public string CurrentQuestion { get; set; }

        [Parameter]
        public EventCallback<string> NotifyResponse { get; set; }

        [Parameter]
        public EventCallback NotifyGameIsOver { get; set; }

        public int Counter { get; set; } = 1;

        public void SendResponse(string response)
        {
            NotifyResponse.InvokeAsync(response);
            Counter++;
            if(Counter == 4) {
                NotifyGameIsOver.InvokeAsync();
            }
        }
    }
}
