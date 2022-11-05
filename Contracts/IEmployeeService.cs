using DataTransferObjects;

namespace Contracts;

public interface IEmployeeService
{
    IEnumerable<EmployeeDataTransfer> GetAllEmployees(Guid companyId, bool trackChanges);
    EmployeeDataTransfer GetEmployee(Guid companyId, Guid employeeId, bool trackChanges);
}