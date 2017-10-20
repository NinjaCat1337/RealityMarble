using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Interfaces
{
    public interface IUserService
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task<OperationDetails> ChangePassword(int userId, string oldPassword, string newPassword);
        Task SetInitialData(List<string> roles);
        int GetUserIdByName(string userName);
        string GetUserNameById(int userId);
        IEnumerable<UserDTO> GetAllUsers();
    }
}
