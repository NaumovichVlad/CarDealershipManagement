using AutoMapper;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.ViewModels.Customers;

namespace CarDealershipManagement.WebUI.Mapping.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, CustomerViewModel>().ReverseMap();
        }
    }
}
