using BaseProject.Models;
using MediatR;

namespace Web.Observer.Events
{
    public class UserCreatedEvent:INotification
    {
        public AppUser  AppUser { get; set; }


    }
}
