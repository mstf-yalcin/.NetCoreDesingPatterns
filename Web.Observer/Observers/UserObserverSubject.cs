using BaseProject.Models;

namespace Web.Observer.Observers
{
    public class UserObserverSubject
    {

        private List<IUserObserver> _userObservers;
        public UserObserverSubject()
        {
            _userObservers = new List<IUserObserver>();
        }


        public void AddObserver(IUserObserver observer)
        {

            _userObservers.Add(observer);

        }

        public void RemoveObserver(IUserObserver observer)
        {
            _userObservers.Remove(observer);
        }

        public void Notify(AppUser appUser)
        {
            _userObservers.ForEach(x =>
            {
                x.UserCreated(appUser);
            });


        }
    }
}
