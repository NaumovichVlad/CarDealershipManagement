using CarDealershipManagement.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipManagement.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        public ShoppingCartController(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            var customer = _customerService.GetCustomerByUserName(User.Identity.Name);
            var orders = _orderService.GetOrdersByCustomerId(customer.Id);
            return View(orders);
        }
    }
}
