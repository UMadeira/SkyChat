using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace SkyChat.Client
{
    public class MockAuthenticationStateProvier : AuthenticationStateProvider
    {
        private ClaimsPrincipal User { get; set; } = new ClaimsPrincipal( new ClaimsIdentity() );

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult( new AuthenticationState( User ) );
        }

        public void SignIn( string username )
        {
            // Sign in the user with the specified username
            var identity = new ClaimsIdentity(new[] {
                new Claim( ClaimTypes.Name, username ), }, "mock");
            User = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged( Task.FromResult( new AuthenticationState( User ) ) );
        }

        public void SignOut()
        {
            // Sign out the user
            User = new ClaimsPrincipal( new ClaimsIdentity() );
            NotifyAuthenticationStateChanged( Task.FromResult( new AuthenticationState( User ) ) );
        }
    }
}
