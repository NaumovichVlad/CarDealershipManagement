using AutoMapper;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.ViewModels.Positions;

namespace CarDealershipManagement.WebUI.Mapping.Profiles
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<PositionDto, PositionViewModel>();
        }
    }
}
