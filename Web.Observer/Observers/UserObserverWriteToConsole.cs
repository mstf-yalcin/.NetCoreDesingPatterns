using BaseProject.Models;

namespace Web.Observer.Observers
{
    public class UserObserverWriteToConsole : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverWriteToConsole(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void UserCreated(AppUser appUser)
        {
            var logger= _serviceProvider.GetRequiredService<ILogger<UserObserverWriteToConsole>>();

            logger.LogInformation("user created:" + appUser.Id);

        }
    }
}
