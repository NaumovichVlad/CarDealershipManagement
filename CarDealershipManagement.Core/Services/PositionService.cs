using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.Core.Services
{
    /// <summary>
    /// Сервис для раьоты с репозиторием
    /// </summary>
    public class PositionService : IPositionService
    {
        private readonly IRepository<Position> _positionsRepository;
        public PositionService(IRepository<Position> positionsRepository)
        {
            _positionsRepository = positionsRepository;
        }

        public List<PositionDto> GetPositions() => _positionsRepository.List().Select(p => new PositionDto()
        {
            Id = p.Id,
            Name = p.PositionName
        }).ToList();
        public PositionDto GetPositionById(int id)
        {
            var position = _positionsRepository.GetById(id);
            return new PositionDto()
            {
                Id = position.Id,
                Name = position.PositionName
            };
        }
    }
}
