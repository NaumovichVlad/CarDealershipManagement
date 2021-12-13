using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.Core.Services
{
    /// <summary>
    /// Сервис для раьоты с репозиторием
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        public OrderService(IRepository<Order> repository)
        {
            _orderRepository = repository;
        }

        public OrderDto GetOrderById(int orderId)
        {
            var order = _orderRepository.GetByIdWithIncludes(orderId, o => o.Car, o => o.Customer, o => o.Employee); 
            return new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                CarId = order.CarId,
                CarRegistrationNumber = order.Car.RegistrationNumber,
                CustomerName = order.Customer.Name,
                CustomerSurname = order.Customer.Surname,
                EmployeeName = order.Employee.Name,
                EmployeeSurname = order.Employee.Surname,
                IsApproved = order.IsApproved,
                OrderCompleteMark = order.OrderCompleteMark,
                SaleDate = order.SaleDate,
                OrderDate = order.OrderDate,
            };
        }
        public List<OrderDto> GetOrders()
        {
            return _orderRepository.ListWithIncludes(o => o.Car, o => o.Customer, o => o.Employee).Select(o => new OrderDto
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                EmployeeId = o.EmployeeId,
                CarId = o.CarId,
                CarRegistrationNumber = o.Car.RegistrationNumber,
                CustomerName = o.Customer.Name,
                CustomerSurname = o.Customer.Surname,
                EmployeeName = o.Employee.Name,
                EmployeeSurname = o.Employee.Surname,
                IsApproved = o.IsApproved,
                OrderCompleteMark = o.OrderCompleteMark,
                SaleDate = o.SaleDate,
                OrderDate = o.OrderDate,
            }).ToList();
        }

        public void CreateNewOrder(CarDto car, CustomerDto customer)
        {
            _orderRepository.Insert(new Order
            {
                CustomerId = customer.Id,
                OrderDate = DateTime.Now.Date,
                IsApproved = false,
                OrderCompleteMark = false,
                CarId = car.Id,
                EmployeeId = null,
                SaleDate = null
            });
        }

        public void CreateNewOrder(OrderDto order)
        {
            _orderRepository.Insert(new Order
            {
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                CarId = order.CarId,
                OrderDate = order.OrderDate,
                SaleDate = order.SaleDate,
                IsApproved = order.IsApproved,
                OrderCompleteMark = order.OrderCompleteMark
            });
        }

        public void EditOrder(OrderDto order)
        {
            _orderRepository.Update(new Order()
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                CarId = order.CarId,
                IsApproved = order.IsApproved,
                OrderCompleteMark = order.OrderCompleteMark,
                SaleDate = order.SaleDate,
                OrderDate = order.OrderDate,
            });
        }

        public void DeleteOrderById(int id)
        {
            _orderRepository.Delete(_orderRepository.GetById(id));
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

        public List<OrderDto> GetOrdersByEmployeeId(int employeeId)
        {
            return _orderRepository.ListWithIncludes(o => o.EmployeeId == employeeId, o => o.Car, o => o.Customer).Select(o => new OrderDto
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                CarRegistrationNumber = o.Car.RegistrationNumber,
                CustomerName = o.Customer.Name,
                CustomerSurname = o.Customer.Surname,
                EmployeeId = o.EmployeeId,
                CarId = o.CarId,
                IsApproved = o.IsApproved,
                OrderCompleteMark = o.OrderCompleteMark,
                SaleDate = o.SaleDate,
                OrderDate = o.OrderDate,
            }).ToList();
        }

        public List<OrderDto> GetNotApprovedOrders()
        {
            return _orderRepository.ListWithIncludes(o => !o.IsApproved, o => o.Car, o => o.Customer).Select(o => new OrderDto
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                EmployeeId = o.EmployeeId,
                CarId = o.CarId,
                CarRegistrationNumber = o.Car.RegistrationNumber,
                CustomerName = o.Customer.Name,
                CustomerSurname = o.Customer.Surname,
                IsApproved = o.IsApproved,
                OrderCompleteMark = o.OrderCompleteMark,
                SaleDate = o.SaleDate,
                OrderDate = o.OrderDate,
            }).ToList();
        }

        public void ApproveOrder(int orderId, int employeeId)
        {
            var order = _orderRepository.GetById(orderId);
            order.EmployeeId = employeeId;
            order.IsApproved = true;
            _orderRepository.Update(order);
        }
    }

}
