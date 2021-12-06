using AutoMapper;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.ViewModels.Cars;

namespace CarDealershipManagement.WebUI.Mapping.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarDto, CarViewModel>();
        }
    }
}
