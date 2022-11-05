using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/companies/{companyId:guid}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public EmployeesController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpGet]
    public IActionResult GetEmployeesForCompany(Guid companyId)
    {
        var employees = _serviceManager.EmployeeService
            .GetAllEmployees(companyId, false);
        return Ok(employees);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetEmployeeForCompany(Guid companyId, Guid id) =>
        Ok(_serviceManager.EmployeeService.GetEmployee(companyId, id, false));
}