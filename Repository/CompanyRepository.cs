using Contracts;
using Entities.Models;

namespace Repository;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContexts repositoryContexts) : base(repositoryContexts) { }
    public IEnumerable<Company> GetAllCompanies(bool trackChanges)
    {
        return FindAll(trackChanges)
            .OrderBy(company => company.Name)
            .ToArray();
    }

    public Company? GetCompany(Guid id, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();
    
    public void CreateCompany(Company company) => Create(company);
}