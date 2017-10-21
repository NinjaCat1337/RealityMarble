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
    public class UserPageService :IUserPageService
    {
        IUnitOfWork Database { get; set; }

        public UserPageService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public async Task<OperationDetails> CreateUserPageAsync(UserPageDTO userPageDTO)
        {
            UserPage page = BLLMappers.ToUserPage(userPageDTO);
            Database.UserPages.Create(page);
            await Database.SaveAsync();
            return new OperationDetails(true, "UserPage has been added.", "");
        }

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

        public UserPageDTO GetUserPage(int id)
        {
            var page = Database.UserPages.Get(id);
            if (page == null)
            {
                throw new ValidationException("Can't find a userpage", "");
            }
            return BLLMappers.ToUserPageDTO(page);
        }

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

        public IEnumerable<UserPageDTO> GetAllUserPages()
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<UserPage, UserPageDTO>(); });
            return Mapper.Map<IEnumerable<UserPage>, List<UserPageDTO>>(Database.UserPages.GetAll());
        }

        public IEnumerable<UserPageDTO> GetLast30Authors()
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<UserPage, UserPageDTO>(); });
            return Mapper.Map<IEnumerable<UserPage>, List<UserPageDTO>>(Database.UserPages.GetAll(sortByInt: x => x.Id, ascending: false, take: 30));
        }
    }
}
