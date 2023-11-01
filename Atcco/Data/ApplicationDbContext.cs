using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Atcco.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Project> Projects { get; set; }

        public DbSet<ImagePath> ImagePaths { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Define the relationship between Project and ImagePath
			modelBuilder.Entity<Project>()
				.HasMany(p => p.Images)
				.WithOne(i => i.Project)
				.HasForeignKey(i => i.ProjectId);
		}
	}
}