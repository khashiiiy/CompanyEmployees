using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContexts : DbContext
{
    public RepositoryContexts(DbContextOptions<RepositoryContexts> options) : base(options) { }

    public DbSet<Employee>? Employees { get; set; }
    
    public DbSet<Company>? Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Company>().HasData(new List<Company>
        {
            new()
            {
                Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                Name = "Admin_Solutions Ltd",
                Address = "312 Forest Avenue, BF 923",
                Country = "USA"
            }
        });

        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    }
}