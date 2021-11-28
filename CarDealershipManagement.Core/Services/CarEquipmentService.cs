﻿using CarDealershipManagement.Core.BusinessModels;
using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.Core.Services
{
    public class CarEquipmentService : ICarEquipmentService
    {
        private readonly IRepository<CarEquipment> _repository;
        public CarEquipmentService (IRepository<CarEquipment> carEquipmentRepository)
        {
            _repository = carEquipmentRepository;
        }

        public List<CarEquipmentBusiness> GetCarEquipment()
        {
            var carEquipments = _repository.List().Select(e => new CarEquipmentBusiness
            {
                CarId = e.CarId,
                EquipmentId = e.OptionalEquipmentId,
                EquipmentName = e.OptionalEquipment.EquipmentName,
                EquipmentPrice = e.OptionalEquipment.Price,
            }).ToList();
            return carEquipments;
        }

        public List<CarEquipmentBusiness> GetCarEquipmentsByCarId(int carId)
        {
            return _repository.ListWithIncludes(c => c.CarId == carId, c => c.OptionalEquipment)
            .Select(e => new CarEquipmentBusiness
            {
                CarId = e.CarId,
                EquipmentId = e.OptionalEquipmentId,
                EquipmentName = e.OptionalEquipment.EquipmentName,
                EquipmentPrice = e.OptionalEquipment.Price,
            }).ToList();
        }
    }
}