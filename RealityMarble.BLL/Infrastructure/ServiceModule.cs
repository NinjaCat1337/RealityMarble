using Ninject.Modules;
using RealityMarble.BLL.Helpers;
using RealityMarble.BLL.Interfaces;
using RealityMarble.BLL.Services;
using RealityMarble.DAL.Interfaces;
using RealityMarble.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Infrastructure
{
    public class ServiceModule :NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IAdminService>().To<AdminService>();
            Bind<IUserService>().To<UserService>();
            Bind<IUserManageService>().To<UserManageService>();
            Bind<IImageService>().To<ImageService>();
            Bind<IRatingService>().To<RatingService>();
            Bind<IMessageService>().To<MessageService>();
            Bind<IUserPageService>().To<UserPageService>();
            Bind<IRatingHelper>().To<RatingHelper>();
            Bind<IUnitOfWork>().ToMethod(x => new UnitOfWork(connectionString));
        }
    }
}
