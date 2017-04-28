namespace MvcApplication.Config.Users
{
    public class ConnectionConfiguration
    {
        public ConnectionConfiguration()
        {
            ConnectionString = "someConnection";
        }

        public string ConnectionString { get; set; }
    }
}