using AutoMapper;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.ViewModels.Orders;

namespace CarDealershipManagement.WebUI.Mapping.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, OrderViewModel>().ReverseMap();
        }
    }
}
