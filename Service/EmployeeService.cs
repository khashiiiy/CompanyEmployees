using AutoMapper;
using Contracts;
using DataTransferObjects;
using Entities.Exceptions;

namespace Service;

public sealed class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public IEnumerable<EmployeeDataTransfer> GetAllEmployees(Guid companyId, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);
        var employees = _repositoryManager.Employee.GetAllEmployees(companyId, trackChanges);
        return _mapper.Map<IEnumerable<EmployeeDataTransfer>>(employees);
    }

    public EmployeeDataTransfer GetEmployee(Guid companyId, Guid employeeId, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);
        var employee = _repositoryManager.Employee.GetEmployee(companyId, employeeId, trackChanges);
        if (employee is null)
            throw new EmployeeNotFoundException(employeeId);
        return _mapper.Map<EmployeeDataTransfer>(employee);
    }
}