using DataTransferObjects;
using Entities.Models;
namespace Contracts;

public interface ICompanyService
{
    IEnumerable<CompanyDataTransfer> GetAllCompanies(bool trackChanges);
    CompanyDataTransfer GetCompany(Guid companyId, bool trackChanges);
    CompanyDataTransfer CreateCompany(CreationCompanyDataTransfer company);
}