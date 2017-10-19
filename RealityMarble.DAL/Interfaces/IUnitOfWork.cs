﻿using RealityMarble.DAL.Entities;
using RealityMarble.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.DAL.Interfaces
{
    public interface IUnitOfWork 
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IRepository<UserPage> UserPages { get; }
        IRepository<Image> Images { get; }
        IRepository<Rating> Ratings { get; }
        Task SaveAsync();
    }
}
