using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealityMarble.DAL.Entities;
using static RealityMarble.DAL.Entities.ApplicationUser;

namespace RealityMarble.DAL.Identity
{
    public class ApplicationRoleManager :RoleManager<Role, int>
    {
        public ApplicationRoleManager(IRoleStore<Role, int> store) : base(store) { }
    }
}
