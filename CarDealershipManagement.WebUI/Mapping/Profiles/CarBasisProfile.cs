using AutoMapper;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.ViewModels;

namespace CarDealershipManagement.WebUI.Mapping.Profiles
{
    public class CarBasisProfile : Profile
    {
        public CarBasisProfile()
        {
            CreateMap<CarBasisDto, CarBasisViewModel>();
        }
    }
}
