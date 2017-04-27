namespace MvcApplication.Config.Users
{
    public class UserConfiguration
    {
        public UserConfiguration()
        {
            ConnectionString = "someConnection";
        }

        public string ConnectionString { get; set; }
    }
}