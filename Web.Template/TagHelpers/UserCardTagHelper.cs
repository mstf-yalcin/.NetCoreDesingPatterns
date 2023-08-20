using BaseProject.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Web.Template.UserCards;

namespace Web.Template.TagHelpers
{
    public class UserCardTagHelper : TagHelper
    {

        public AppUser Appuser { get; set; }

        public int test { get;set; }

        public IHttpContextAccessor _httpContextAccessor;

        public UserCardTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            UserCardTemplate userCard;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                userCard = new PremiumUserCardTemplate();
            else
                userCard = new DefaultCardTemplate();

            userCard.SetUser(Appuser);

            output.Content.SetHtmlContent(userCard.Builder());


        }
    }
}
