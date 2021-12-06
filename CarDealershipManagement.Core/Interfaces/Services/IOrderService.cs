using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface IOrderService
    {
        OrderDto GetOrderById(int orderId);
        List<OrderDto> GetOrders();
        void CreateNewOrder(CarDto car, CustomerDto customer);
        void CreateNewOrder(OrderDto order);
        void EditOrder(OrderDto order);
        void DeleteOrderById(int id);
        List<OrderDto> GetOrdersByCustomerId(int customerId);
        List<OrderDto> GetOrdersByEmployeeId(int employeeId);
        List<OrderDto> GetNotApprovedOrders();
        void ApproveOrder(int orderId, int employeeId);
    }
}