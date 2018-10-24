using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using RealityMarble.BLL.Services;
using Microsoft.AspNet.Identity;
using RealityMarble.BLL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using RealityMarble.BLL.Infrastructure;

[assembly: OwinStartup(typeof(RealityMarble.App_Start.Startup))]

namespace RealityMarble.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });

        }

    }
}
