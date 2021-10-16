using CarDealershipManagement.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Infrastructure
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
