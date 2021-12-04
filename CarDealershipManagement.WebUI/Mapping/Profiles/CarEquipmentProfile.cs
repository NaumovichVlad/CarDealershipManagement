using AutoMapper;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.ViewModels;

namespace CarDealershipManagement.WebUI.Mapping.Profiles
{
    public class CarEquipmentProfile : Profile
    {
        public CarEquipmentProfile()
        {
            CreateMap<CarEquipmentDto, CarEquipmentViewModel>();
        }
    }
}
