using RealityMarble.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Interfaces
{
    public interface IUserManageService
    {
        Task<OperationDetails> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
        Task<OperationDetails> ChangeEmailAsync(int userId, string newEmail);
    }
}
