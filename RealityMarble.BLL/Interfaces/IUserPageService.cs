using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Interfaces
{
    public interface IUserPageService
    {
        Task<OperationDetails> CreateUserPageAsync(UserPageDTO userPageDTO);
        Task<OperationDetails> UpdateUserPageAsync(UserPageDTO userPageDTO);
        UserPageDTO GetUserPage(int id);
        Task<OperationDetails> DeleteUserPageAsync(int id);
        IEnumerable<UserPageDTO> GetAllUserPages();
        IEnumerable<UserPageDTO> GetLast30Authors();
    }
}
