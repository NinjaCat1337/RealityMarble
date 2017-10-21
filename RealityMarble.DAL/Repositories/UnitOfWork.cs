using RealityMarble.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealityMarble.DAL.Entities;
using RealityMarble.DAL.Identity;
using RealityMarble.DAL.Essence;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RealityMarble.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private EntityDbContext _context;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private ImageRepository _imageRepository;
        private RatingRepository _ratingRepository;
        private UserPageRepository _userPageRepository;

        public UnitOfWork(string connectionString)
        {
            _context = new EntityDbContext(connectionString);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                if (_userManager == null)
                {
                    _userManager = new ApplicationUserManager(new ApplicationUser.UserStore(_context));
                }
                return _userManager;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                if (_roleManager == null)
                {
                    _roleManager = new ApplicationRoleManager(new ApplicationUser.RoleStore(_context));
                }
                return _roleManager;
            }
        }


        public IUserPageRepository UserPages
        { 
            get
            {
                if (_userPageRepository == null)
                {
                    _userPageRepository = new UserPageRepository(_context);
                }
                return _userPageRepository;
            }
        }

        public IRepository<Image> Images
        {
            get
            {
                if (_imageRepository == null)
                {
                    _imageRepository = new ImageRepository(_context);
                }
                return _imageRepository;
            }
        }

        public IRepository<Rating> Ratings
        {
            get
            {
                if (_ratingRepository == null)
                {
                    _ratingRepository = new RatingRepository(_context);
                }
                return _ratingRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
