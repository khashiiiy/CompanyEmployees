using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace CompanyEmployees.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContexts>
{
    public RepositoryContexts CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<RepositoryContexts>()
            .UseSqlite("Data Source=CompanyEmployee.db", options =>
                {
                    options.MigrationsAssembly("CompanyEmployees");
                });
        
        return new RepositoryContexts(builder.Options);
    }
}