using Microsoft.EntityFrameworkCore;
using WebApp.Data.Entities;

namespace WebApp.EntityFramework
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<UserEntity> Users { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }
	}
}
