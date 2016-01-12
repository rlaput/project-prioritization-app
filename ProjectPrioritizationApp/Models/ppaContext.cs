using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ProjectPrioritizationApp.Models.Mapping;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjectPrioritizationApp.Models
{
    public partial class ppaContext : DbContext
    {
        static ppaContext()
        {
            Database.SetInitializer<ppaContext>(null);
        }

        public ppaContext()
            : base("Name=ppaContext")
        {
        }

        public DbSet<criterion> criteria { get; set; }
        public DbSet<project> projects { get; set; }
        public DbSet<score> scores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
