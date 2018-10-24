using Microsoft.AspNet.Identity.EntityFramework;
using RealityMarble.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RealityMarble.DAL.Entities.ApplicationUser;

namespace RealityMarble.DAL.Essence
{
    public class EntityDbContext :IdentityDbContext<ApplicationUser, Role, int, UserLogin, UserRole, UserClaim>
    {
        public EntityDbContext (string connectionString) :base("RealityMarbleDB") { }

        public IDbSet<Image> Images { get; set; }
        public IDbSet<Rating> Ratings { get; set; }
        public IDbSet<UserPage> UserPages { get; set; }
        public IDbSet<Message> Messages { get; set; }
    }

    public class EntityContextFactory : IDbContextFactory<EntityDbContext>
    {
        public EntityDbContext Create()
        {
            return new EntityDbContext("RealityMarbleDB");
        }
    }
}
