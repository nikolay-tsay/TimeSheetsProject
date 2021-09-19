using AutoMapper;
using TimeSheets.Entities;

namespace TimeSheets.DTO
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Invoice, InvoiceDto>()
                .ForSourceMember(x => x.CustomerId, opt => opt.DoNotValidate());

            CreateMap<Customer, CustomerDto>()
                .ForSourceMember(x => x.Id, opt => opt.DoNotValidate());

            CreateMap<Employee, EmployeeDto>()
                .ForSourceMember(x => x.Id, opt => opt.DoNotValidate());

            CreateMap<Contract, ContractDto>()
                .ForSourceMember(x => x.Id, opt => opt.DoNotValidate());
        }
    }
}