using BaseProject.Models;
using System.Text;

namespace Web.Template.UserCards
{
    public abstract class UserCardTemplate
    {

        protected AppUser AppUser { get; set; }

        public void SetUser(AppUser appUser)
        {
            AppUser = appUser;
        }


        public string Builder()
        {
            if (AppUser == null)
                throw new ArgumentNullException(nameof(AppUser));


            var sb = new StringBuilder();

            sb.Append("<div class='card'>");

            sb.Append(SetProfilePicture());
            sb.Append($@"<div class='card-body'>
                    <h5>{AppUser.UserName}</h5>
                    <p>{AppUser.Description}</>");
            sb.Append(SetFooter());
            
            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();
        }


        protected abstract string SetProfilePicture();

        protected abstract string SetFooter();





    }
}
