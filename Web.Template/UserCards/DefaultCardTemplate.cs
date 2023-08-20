namespace Web.Template.UserCards
{
    public class DefaultCardTemplate : UserCardTemplate
    {
        protected override string SetFooter()
        {
            return String.Empty;
        }

        protected override string SetProfilePicture()
        {
            return "<img class='card-img-top img-thumbnail' src='https://static.vecteezy.com/system/resources/previews/009/734/564/large_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg'>";
        }
    }
}
