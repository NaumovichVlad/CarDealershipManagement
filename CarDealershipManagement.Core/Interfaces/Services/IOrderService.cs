using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface IOrderService
    {
        void CreateNewOrder(CarDto car, CustomerDto customer);
        List<OrderDto> GetOrdersByCustomerId(int customerId);
        List<OrderDto> GetOrdersByEmployeeId(int employeeId);
        List<OrderDto> GetNotApprovedOrders();
        void ApproveOrder(int orderId, int employeeId);
    }
}