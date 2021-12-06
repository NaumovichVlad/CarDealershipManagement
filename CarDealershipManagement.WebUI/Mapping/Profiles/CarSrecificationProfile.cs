using AutoMapper;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.ViewModels.CarsSpecifications;

namespace CarDealershipManagement.WebUI.Mapping.Profiles
{
    public class CarSpecificationProfile : Profile
    {
        public CarSpecificationProfile()
        {
            CreateMap<CarSpecificationDto, CarSpecificationViewModel>();
        }
    }
}
