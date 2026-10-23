
using Microsoft.AspNetCore.Identity;
using Snackis1.Data;

namespace Snackis1.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await Task.FromResult(
                _userManager.Users.ToList());
        }
    }
}

