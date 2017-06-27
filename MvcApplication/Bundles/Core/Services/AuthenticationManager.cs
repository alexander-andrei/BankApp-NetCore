namespace MvcApplication.Bundles.Core.Services
{
    public class AuthenticationManager
    {
        public const string UserIdKey = "_userId";

        private readonly UserManager _userManager;

        public AuthenticationManager(UserManager userManager)
        {
            _userManager = userManager;
        }

        public bool CheckIfUserIsAuthorized(int? key)
        {
            if (key == null)
            {
                return false;
            }

            return _userManager.GetAll((int) key).Count != 0;
        }
    }
}