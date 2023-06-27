using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApp.Data.Entities;

namespace WebApp.EntityFramework
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<UserEntity> Users { get; set; }
        public ApplicationDbContext()
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=WebAppDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
