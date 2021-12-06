using AutoMapper;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.ViewModels.Employees;

namespace CarDealershipManagement.WebUI.Mapping.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, EmployeeViewModel>().ReverseMap();
        }
    }
}
