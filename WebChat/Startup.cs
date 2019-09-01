using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(SignalRChat.Startup))]
namespace SignalRChat
{
    public class Startup
    {
        /// <summary>
        /// Sets up SignalR on app startup
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        /// <param name="app">The app</param>
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}