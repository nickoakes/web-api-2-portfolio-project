using System.Data.Entity;

namespace web_api_2_portfolio_project.Shared
{
    public class DBC : DbContext
    {
        public DBC() : base("Name=ServiceDatabase")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }

        public static DBC DatabaseConnection()
        {
            return new DBC();
        }
    }
}