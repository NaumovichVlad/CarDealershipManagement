using CarDealershipManagement.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI
{
    public interface IDbTestFiller
    {
        Manufacturer[] GetTestManufacturers();
        Brand[] GetTestBrands();
        Position[] GetTestPositions();
        Specification[] GetTestSpecs();
        Car[] GetTestCars();
        CarEquipment[] GetTestCarEquipments();
        CarSpecification[] GetTestCarSpecs();
        Customer[] GetTestCustomers();
        Employee[] GetTestEmployees();
        OptionalEquipment[] GetTestOptionalEquipments();
        Order[] GetTestOrders();
        User[] GetTestUsers();
    }
}
