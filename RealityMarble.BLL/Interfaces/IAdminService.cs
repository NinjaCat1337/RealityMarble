using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Interfaces
{
    public interface IAdminService
    {
        Task<OperationDetails> ChangePasswordByAdminAsync(int userId, string newPassword);
        Task<OperationDetails> ChangeEmailByAdminAsync(int userId, string newEmail);
        Task<OperationDetails> ChangeUserNameByAdminAsync(int userId, string newUserName);
        Task<OperationDetails> DeleteUserAsync(int userId);
        Task<UserDTO> GetUserByIdAsync(int userId);
    }
}
