using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorApp1.Areas.Identity.Pages.Account.Manage.Admin
{
    public class UserEditModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly string adminName = "mivladi99@yandex.ru";

        public UserEditModel(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public EditUserViewModel Input { get; set; }

        public class EditUserViewModel
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public List<IdentityRole> AllRoles { get; set; }
            public IList<string> UserRoles { get; set; }
            public EditUserViewModel()
            {
                AllRoles = new List<IdentityRole>();
                UserRoles = new List<string>();
            }
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();
            Input = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserRoles = userRoles,
                AllRoles = allRoles
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, List<string> roles)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(Input.Id);
                if (user != null)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var addedRoles = roles.Except(userRoles);
                    var removedRoles = userRoles.Except(roles);

                    if (User.Identity.Name != adminName && (addedRoles.Contains("admin") || removedRoles.Contains("admin"))) 
                    {
  
                            TempData["StatusMessage"] = "Error: Only superadmin can remove or add admin";
                            return RedirectToPage("UserIndex");
                    }

                    if (user.UserName == adminName && removedRoles.Contains("admin"))
                    {
                        TempData["StatusMessage"] = "Error: Cant't remove admin role from superadmin";
                        return RedirectToPage("UserIndex");
                    }

                    await _userManager.AddToRolesAsync(user, addedRoles);
                    await _userManager.RemoveFromRolesAsync(user, removedRoles);

                    if (user.UserName == User.Identity.Name)
                    {
                        await _signInManager.RefreshSignInAsync(user);
                    }


                    user.Email = Input.Email;
                    user.UserName = Input.Email;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        TempData["StatusMessage"] = "Successfully changed";
                        return RedirectToPage("UserIndex");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return Page();
        }
    }
}
