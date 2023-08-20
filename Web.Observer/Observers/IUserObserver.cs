using BaseProject.Models;

namespace Web.Observer.Observers
{
    public interface IUserObserver
    {
        public void UserCreated(AppUser appUser);
    }
}
