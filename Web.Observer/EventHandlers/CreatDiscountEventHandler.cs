using BaseProject.Models;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Web.Observer.Events;

namespace Web.Observer.EventHandlers
{
    public class CreatDiscountEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<CreatDiscountEventHandler> _logger;

        private readonly AppIdentityDbContext _context;

        public CreatDiscountEventHandler(AppIdentityDbContext context, ILogger<CreatDiscountEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
    

           await _context.Discounts.AddAsync(new Models.Discount() { UserId = notification.AppUser.Id, Rate = 10 });
           await _context.SaveChangesAsync();
            _logger.LogInformation("Discount");
        }
    }
}
