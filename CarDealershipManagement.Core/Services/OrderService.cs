using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        public OrderService(IRepository<Order> repository)
        {
            _orderRepository = repository;
        }

        public void CreateNewOrder(CarDto car, CustomerDto customer)
        {
            _orderRepository.Insert(new Order
            {
                CustomerId = customer.Id,
                OrderDate = DateTime.Now.Date,
                IsApproved = false,
                OrderCompleteMark = false,
                CarId = car.Id
            });
        }

        public List<OrderDto> GetOrdersByCustomerId(int customerId)
        {
            return _orderRepository.List(o => o.CustomerId == customerId).Select(o => new OrderDto
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                EmployeeId = o.EmployeeId,
                CarId = o.CarId,
                IsApproved = o.IsApproved,
                OrderCompleteMark = o.OrderCompleteMark,
                SaleDate = o.SaleDate,
                OrderDate = o.OrderDate,
            }).ToList();

        }
    }

}
