using Microsoft.AspNetCore.Identity;

namespace Pokedex.Infra.Data.Identity
{
    public class SeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("poke.admin@gmail.com").Result == null)
            {
                var user = new ApplicationUser();
                user.UserName = "poke.admin@gmail.com";
                user.Email = "poke.admin@gmail.com";
                user.NormalizedUserName = "POKE.ADMIN@GMAIL.COM";
                user.NormalizedEmail = "POKE.ADMIN@GMAIL.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "@Poke123").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
            }

            if (_userManager.FindByEmailAsync("poke.user@gmail.com").Result == null)
            {
                var user = new ApplicationUser();
                user.UserName = "poke.user@gmail.com";
                user.Email = "poke.user@gmail.com";
                user.NormalizedUserName = "POKE.USER@GMAIL.COM";
                user.NormalizedEmail = "POKE.USER@GMAIL.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "@Poke123").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "User").Wait();
            }
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
