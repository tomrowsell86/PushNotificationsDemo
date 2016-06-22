using System.Data.Entity;

namespace PushNotifications.DatabaseRepositories
{
    public class PushHandlerContext : DbContext
    {
        public PushHandlerContext(string nameOrConnectionString) : base(nameOrConnectionString) {}

        
    }
}