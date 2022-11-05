using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContexts _repositoryContexts;

    private readonly Lazy<ICompanyRepository> _companyRepository;

    private readonly Lazy<IEmployeeRepository> _employeeRepository;
    
    public RepositoryManager(RepositoryContexts repositoryContexts)
    {
        _repositoryContexts = repositoryContexts;
        _companyRepository = new Lazy<ICompanyRepository>(() => 
            new CompanyRepository(repositoryContexts));
        _employeeRepository = new Lazy<IEmployeeRepository>(() => 
            new EmployeeRepository(repositoryContexts));
    }
    
    public ICompanyRepository Company => _companyRepository.Value;

    public IEmployeeRepository Employee => _employeeRepository.Value;

    public void Save() => _repositoryContexts.SaveChanges();
}