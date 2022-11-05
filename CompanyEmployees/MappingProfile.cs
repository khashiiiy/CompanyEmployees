using AutoMapper;
using DataTransferObjects;
using Entities.Models;

namespace CompanyEmployees;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDataTransfer>()
            .ForCtorParam("FullAddress", b =>
            {
                b.MapFrom(c => string.Join(' ', c.Address, c.Country));
            });
        
        CreateMap<Employee, EmployeeDataTransfer>();

        CreateMap<CreationCompanyDataTransfer, Company>();
    }
}