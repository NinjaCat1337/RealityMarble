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
        private MessageRepository _messageRepository;

        public UnitOfWork(string connectionString)
        {
            _context = new EntityDbContext(connectionString);
        }

        /// <summary>
        /// Gets the user manager.
        /// </summary>
        /// <value>The user manager.</value>
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

        /// <summary>
        /// Gets the role manager.
        /// </summary>
        /// <value>The role manager.</value>
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


        /// <summary>
        /// Gets the user pages.
        /// </summary>
        /// <value>The user pages.</value>
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

        /// <summary>
        /// Gets the images.
        /// </summary>
        /// <value>The images.</value>
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

        /// <summary>
        /// Gets the ratings.
        /// </summary>
        /// <value>The ratings.</value>
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

        /// <summary>
        /// save as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        /// 
        public IRepository<Message> Messages
        {
            get
            {
                if (_messageRepository == null)
                {
                    _messageRepository = new MessageRepository(_context);
                }
                return _messageRepository;
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
