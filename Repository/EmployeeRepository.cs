using Contracts;
using Entities.Models;

namespace Repository;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContexts repositoryContexts) : base(repositoryContexts) { }

    public IEnumerable<Employee> GetAllEmployees(Guid companyId, bool trackChanges)
    {
        return FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.Name)
            .ToArray();
    }

    public Employee? GetEmployee(Guid companyId, Guid id, bool trackChanges)
    {
        return FindByCondition(employee =>
            employee.CompanyId.Equals(companyId) && employee.Id.Equals(id), trackChanges)
            .SingleOrDefault();
    }
}