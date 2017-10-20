using Microsoft.AspNet.Identity;
using RealityMarble.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store) : base(store) { }

        public async Task<IdentityResult> ChangePasswordByAdminAsync(ApplicationUser user, string newPassword)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var store = this.Store as IUserPasswordStore<ApplicationUser, int>;
            if (store == null)
            {
                var errors = new string[] { "Current UserStore doesn't implement IUserPasswordStore" };
                return IdentityResult.Failed(errors);
            }

            var newPasswordHash = this.PasswordHasher.HashPassword(newPassword);
            await store.SetPasswordHashAsync(user, newPasswordHash);
            await store.UpdateAsync(user);
            return IdentityResult.Success;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(int userId)
        {
            var user = await Store.FindByIdAsync(userId);
            return user;
        }
    }
}
