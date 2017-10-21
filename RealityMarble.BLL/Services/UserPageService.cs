using AutoMapper;
using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Helpers;
using RealityMarble.BLL.Infrastructure;
using RealityMarble.BLL.Interfaces;
using RealityMarble.DAL.Entities;
using RealityMarble.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Services
{
    /// <summary>
    /// Class UserPageService.
    /// </summary>
    /// <seealso cref="RealityMarble.BLL.Interfaces.IUserPageService" />
    public class UserPageService :IUserPageService
    {
        IUnitOfWork Database { get; set; }

        public UserPageService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        /// <summary>
        /// create user page as an asynchronous operation.
        /// </summary>
        /// <param name="userPageDTO">The user page dto.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> CreateUserPageAsync(UserPageDTO userPageDTO)
        {
            UserPage page = BLLMappers.ToUserPage(userPageDTO);
            Database.UserPages.Create(page);
            await Database.SaveAsync();
            return new OperationDetails(true, "UserPage has been added.", "");
        }

        /// <summary>
        /// update user page as an asynchronous operation.
        /// </summary>
        /// <param name="userPageDTO">The user page dto.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> UpdateUserPageAsync(UserPageDTO userPageDTO)
        {
            UserPage page = BLLMappers.ToUserPage(userPageDTO);
            UserPage item = Database.UserPages.Get(page.Id);
            if (item != null)
            {
                Database.UserPages.Update(item);
            }
            await Database.SaveAsync();
            return new OperationDetails(true, "UserPage has been updated.", "");
        }

        /// <summary>
        /// Gets the user page.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>UserPageDTO.</returns>
        /// <exception cref="RealityMarble.BLL.Infrastructure.ValidationException">Can't find a userpage</exception>
        public UserPageDTO GetUserPage(int id)
        {
            var page = Database.UserPages.Get(id);
            if (page == null)
            {
                throw new ValidationException("Can't find a userpage", "");
            }
            return BLLMappers.ToUserPageDTO(page);
        }

        /// <summary>
        /// delete user page as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> DeleteUserPageAsync(int id)
        {
            UserPage item = Database.UserPages.Get(id);
            if (item != null)
            {
                Database.UserPages.Delete(id);
            }
            await Database.SaveAsync();
            return new OperationDetails(true, "UserPage has been deleted.", "");
        }

        /// <summary>
        /// Gets all user pages.
        /// </summary>
        /// <returns>IEnumerable&lt;UserPageDTO&gt;.</returns>
        public IEnumerable<UserPageDTO> GetAllUserPages()
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<UserPage, UserPageDTO>(); });
            return Mapper.Map<IEnumerable<UserPage>, List<UserPageDTO>>(Database.UserPages.GetAll());
        }


        /// <summary>
        /// Gets the last authors.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>IEnumerable&lt;UserPageDTO&gt;.</returns>
        public IEnumerable<UserPageDTO> GetLastAuthors(int count)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<UserPage, UserPageDTO>(); });
            return Mapper.Map<IEnumerable<UserPage>, List<UserPageDTO>>(Database.UserPages.GetAll(sortByInt: x => x.Id, ascending: false, take: count));
        }
    }
}
