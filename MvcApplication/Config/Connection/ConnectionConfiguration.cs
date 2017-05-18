namespace MvcApplication.Config.Connection
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