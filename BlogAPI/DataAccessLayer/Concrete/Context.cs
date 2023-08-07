using Microsoft.EntityFrameworkCore;

namespace BlogAPI.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(LocalDB)\\MSSQLLocalDB; database=DbBlogSiteAPI; integrated security=true;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
