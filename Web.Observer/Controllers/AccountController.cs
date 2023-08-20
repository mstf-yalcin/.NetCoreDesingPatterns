using BaseProject.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Observer.Events;
using Web.Observer.Models;
using Web.Observer.Observers;

namespace BaseProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserObserverSubject _subject;
        private readonly IMediator _mediator;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, UserObserverSubject subject, IMediator mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _subject = subject;
            _mediator = mediator;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return View("Error");

            var singInResult = await _signInManager.PasswordSignInAsync(user, password, true, false);

            if (!singInResult.Succeeded)
                return View("Error");

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateDto newUser)
        {

           var appUser= new AppUser() { UserName=newUser.Name,Email=newUser.Email };
            var identityResult = await _userManager.CreateAsync(appUser, newUser.Password);

            if(identityResult.Succeeded)
            {
                //_mediator.Send(appUser); // event i dinleyen sadece 1 subscriber için
                await _mediator.Publish(new UserCreatedEvent() { AppUser=appUser}); 
                //_subject.Notify(appUser);
                ViewBag.message = "Success";
                
            }
            else
            {
                ViewBag.message = identityResult.Errors.ToList().First().Description;
            }

            return View();
        }
    }
}
