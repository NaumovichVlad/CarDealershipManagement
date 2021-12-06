using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface IPositionService
    {
        PositionDto GetPositionById(int id);
        List<PositionDto> GetPositions();
    }
}
