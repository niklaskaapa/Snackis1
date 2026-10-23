using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Snackis1.Data;
using System.Security.Claims;

namespace Snackis1.Services
{
    public class CurrentUserService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly UserManager<ApplicationUser> _userManager;

        public CurrentUserService(AuthenticationStateProvider authStateProvider,
            UserManager<ApplicationUser> userManager)
        {
            _authStateProvider = authStateProvider;
            _userManager = userManager;
        }

        public async Task<string?> GetUserIdAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();

            if (authState.User.Identity?.IsAuthenticated != true)
            {
                return null;
            }


            return authState.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<ApplicationUser?> GetUserAsync ()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();

            if (authState.User.Identity?.IsAuthenticated != true)
            {
                return null;
            }

            return await _userManager.GetUserAsync(authState.User);
        }

    }
}
