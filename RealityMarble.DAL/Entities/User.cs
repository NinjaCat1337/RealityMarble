using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RealityMarble.DAL.Essence;
using RealityMarble.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static RealityMarble.DAL.Entities.ApplicationUser;

namespace RealityMarble.DAL.Entities
{
    public class ApplicationUser : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public ApplicationUser()
        {
            Images = new List<Image>();
            Ratings = new List<Rating>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        } 
        public class UserRole : IdentityUserRole<int>
        {
        }

        public class UserClaim : IdentityUserClaim<int>
        {
        }

        public class UserLogin : IdentityUserLogin<int>
        {
        }

        public class Role : IdentityRole<int, UserRole>
        {
            public Role() { }
            public Role(string name) { Name = name; }
        }

        public class UserStore : UserStore<ApplicationUser, Role, int, UserLogin, UserRole, UserClaim>
        {
            public UserStore(EntityDbContext context) : base(context)
            {
            }
        }

        public class RoleStore : RoleStore<Role, int, UserRole>
        {
            public RoleStore(EntityDbContext context) : base(context)
            {
            }
        }
    }
}
