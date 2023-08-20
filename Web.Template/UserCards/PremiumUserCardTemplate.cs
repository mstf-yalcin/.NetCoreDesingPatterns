using System.Text;

namespace Web.Template.UserCards
{
    public class PremiumUserCardTemplate : UserCardTemplate
    {
        protected override string SetFooter()
        {
            var sb = new StringBuilder();

            sb.Append("<a href='#' class='card-link'>Send Message</a>");
            sb.Append("<a href='#' class='card-link'>Profile</a>");
            return sb.ToString();
        }

        protected override string SetProfilePicture()
        {
            return $"<img class='card-img-top img-thumbnail' src={AppUser.PictureUrl}>";

        }
    }
}
