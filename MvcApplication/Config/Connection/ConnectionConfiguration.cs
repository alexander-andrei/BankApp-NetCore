namespace MvcApplication.Config.Users
{
    public class ConnectionConfiguration
    {
        public ConnectionConfiguration()
        {
            ConnectionString = "Server=localhost;database=banking;uid=root;pwd=root";
        }

        public string ConnectionString { get; set; }
    }
}