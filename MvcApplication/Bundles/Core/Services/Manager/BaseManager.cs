using System.Collections.Generic;

namespace MvcApplication.Bundles.Core.Services.Manager
{
    public abstract class BaseManager<T>
    {
        private readonly string _connectionString;

        protected BaseManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        public abstract List<T> GetAll(int id = 0);
    }
}