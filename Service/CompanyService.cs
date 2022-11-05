using AutoMapper;
using Contracts;
using DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;

namespace Service;

public sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager;
    // private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;
    public CompanyService(IRepositoryManager repositoryManager /*, ILoggerManager loggerManager */, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        // _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public IEnumerable<CompanyDataTransfer> GetAllCompanies(bool trackChanges)
    {
        var companies = _repositoryManager
                .Company
                .GetAllCompanies(trackChanges);
        return _mapper.Map<IEnumerable<CompanyDataTransfer>>(companies);
    }

    public CompanyDataTransfer GetCompany(Guid companyId, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);
        return _mapper.Map<CompanyDataTransfer>(company);
    }

    public CompanyDataTransfer CreateCompany(CreationCompanyDataTransfer company)
    {
        var companyEntity = _mapper.Map<Company>(company);
        _repositoryManager.Company.CreateCompany(companyEntity);
        _repositoryManager.Save();
        return _mapper.Map<CompanyDataTransfer>(companyEntity);
    }
}