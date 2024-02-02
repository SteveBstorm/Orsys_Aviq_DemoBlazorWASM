using DemoBlazorWASM.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace DemoBlazorWASM.Pages.Chat
{
    public partial class Chat
    {
        //Microsoft.aspnetcore.signalr.client

        public List<Message> Messages { get; set; }

        public string newMessage { get; set; }
        public string author { get; set; }

        public HubConnection connection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Messages = new List<Message>();
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7200/chathub").Build();

            await connection.StartAsync();

            connection.On("NotifyNewMessage",
                (Message m) =>
                {
                    Messages.Add(m);
                    StateHasChanged();
                });
        }

        public async Task SendMessage()
        {
            await connection.SendAsync("SendMessage", 
                new Message { Author = author, Content = newMessage});
        }

        public async Task JoinGroup()
        {
            await connection.SendAsync("JoinGroup", "aviq");

            connection.On("NotifyFromaviq", (Message m) =>
            {
                Messages.Add(m);
                StateHasChanged();
            });
        }

        public async Task SendToGroup()
        {
            await connection.SendAsync("SendToGroup", "aviq", 
                new Message { Author = author, Content = newMessage});
        }
    }

    
}
