using Contracts;
using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public CompaniesController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpGet]
    public IActionResult GetCompanies()
    {
        var companies = _serviceManager
            .CompanyService
            .GetAllCompanies(trackChanges: false);
        return Ok(companies);
    }

    [HttpGet("{id:guid}", Name = "CompanyId")]
    public IActionResult GetCompany(Guid id)
    {
        return Ok(_serviceManager.CompanyService.GetCompany(id, false));
    }

    [HttpPost]
    public IActionResult CreateCompany([FromBody] CreationCompanyDataTransfer? company)
    {
        if (company is null)
            return BadRequest("object is null");
        var createCompany = _serviceManager.CompanyService.CreateCompany(company);
        return CreatedAtRoute("CompanyId",
            new { id = createCompany.Id }, createCompany);
    }
}