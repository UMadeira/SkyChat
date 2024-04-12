using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

// https://learn.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-8.0

namespace SkyChat.Client.Pages
{
    public partial class Chat
    {

        [CascadingParameter]
        private Task<AuthenticationState>? AuthenticationState { get; set; }

        private string UserName { get; set; }
        private string MessageBody { get; set; }

        private IDictionary<string,string> Users { get; set; } = new Dictionary<string,string>();

        protected override async Task OnInitializedAsync()
        {
            var user = (await AuthenticationState).User;
            if ( user?.Identity?.IsAuthenticated ?? false )
            {
                UserName = user?.Identity?.Name ?? "Unknown";
            }
        }

        private void OnConnectUser( string user, string connection )
        {
            Users.Add( user, connection );
            InvokeAsync( StateHasChanged );
        }

        private async Task OnSelectUser( string user )
        { 
        }

        private async Task Send()
        {
        }
    }
}
