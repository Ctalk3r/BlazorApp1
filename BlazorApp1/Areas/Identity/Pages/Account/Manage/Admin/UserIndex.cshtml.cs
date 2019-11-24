using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BlazorApp1.Areas.Identity.Pages.Account.Manage.Admin
{
    public class UserIndexModel : PageModel
    {
        public readonly UserManager<User> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UserIndexModel> _logger;

        public UserIndexModel(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public IEnumerable<User> UsersList { get; set; }

        public void OnGet()
        {
            UsersList = _userManager.Users.ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null && !await _userManager.IsInRoleAsync(user, "admin"))
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result == null)
                {
                    _logger.LogWarning($"Eror in deleting user {user.Email}");
                }
            }
            else
            {
                StatusMessage = "Error: Access Denied";
            }
            return RedirectToPage("UserIndex");
        }
    }
}
