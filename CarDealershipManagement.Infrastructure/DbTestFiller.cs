using CarDealershipManagement.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Infrastructure
{
    public class DbTestFiller : IDbTestFiller
    {
        private int oneCount, manyCount;
        public DbTestFiller(int oneCount, int manyCount)
        {
            this.oneCount = oneCount;
            this.manyCount = manyCount;
        }
        public Brand[] GetTestBrands()
        {
            var brands = new Brand[oneCount];
            for (var i = 0; i < oneCount; i++)
            {
                brands[i] = new Brand()
                {
                    Id = i + 1,
                    BrandName = "brand_" + (i + 1)
                };
            }
            return brands;
        }

        public Position[] GetTestPositions()
        {
            var positions = new Position[oneCount];
            for (var i = 0; i < oneCount; i++)
            {
                positions[i] = new Position()
                {
                    Id = i + 1,
                    PositionName = "position_" + (i + 1)
                };
            }
            return positions;
        }

        public Manufacturer[] GetTestManufacturers()
        {
            var manufacturers = new Manufacturer[oneCount];
            for (var i = 0; i < oneCount; i++)
            {
                manufacturers[i] = new Manufacturer()
                {
                    Id = i + 1,
                    ManufacturerName = "manufacturer_" + (i + 1),
                    Adress = GetRandomString(30),
                    Description = GetRandomString(50)
                };
            }
            return manufacturers;
        }

        public Specification[] GetTestSpecs()
        {
            var random = new Random();
            var specs = new Specification[oneCount];
            for (var i = 0; i < oneCount; i++)
            {
                specs[i] = new Specification()
                {
                    Id = i + 1,
                    SpecificationName = "specification_" + (i + 1),
                    SpecificationValue = random.NextDouble()
                };
            }
            return specs;
        }

        public Car[] GetTestCars()
        {
            var random = new Random();
            var cars = new Car[oneCount];
            var picture = new byte[random.Next(100)];
            random.NextBytes(picture);
            for (var i = 0; i < oneCount; i++)
            {
                cars[i] = new Car()
                {
                    Id = i + 1,
                    RegistrationNumber = GetRandomString(10),
                    BrandId = random.Next(1, oneCount),
                    ManufacturerId = random.Next(1, oneCount),
                    Picture = picture,
                    Color = GetRandomString(10),
                    BodyTypeNumber = GetRandomString(10),
                    EngineNumber = GetRandomString(10),
                    Price = random.NextDouble()
                };
            }
            return cars;
        }

        public CarEquipment[] GetTestCarEquipments()
        {
            var random = new Random();
            var carEquipments = new CarEquipment[manyCount];
            for (var i = 0; i < manyCount; i++)
            {
                carEquipments[i] = new CarEquipment()
                {
                    Id = i + 1,
                    CarId = random.Next(1, oneCount),
                    EquipmentId = random.Next(1, oneCount)
                };
            }
            return carEquipments;
        }

        public CarSpecification[] GetTestCarSpecs()
        {
            var random = new Random();
            var carSpecs = new CarSpecification[manyCount];
            for (var i = 0; i < manyCount; i++)
            {
                carSpecs[i] = new CarSpecification()
                {
                    Id = i + 1,
                    CarId = random.Next(1, oneCount),
                    SpecificationId = random.Next(1, oneCount)
                };
            }
            return carSpecs;
        }

        public Customer[] GetTestCustomers()
        {
            var random = new Random();
            var customers = new Customer[oneCount];
            for (var i = 0; i < oneCount; i++)
            {
                customers[i] = new Customer()
                {
                    Id = i + 1,
                    Surname = GetRandomString(15),
                    Name = GetRandomString(15),
                    MiddleName = GetRandomString(15),
                    PassportData = GetRandomString(10),
                    Address = GetRandomString(20),
                };
            }
            return customers;
        }

        public Employee[] GetTestEmployees()
        {
            var random = new Random();
            var employees = new Employee[oneCount]; 
            for (var i = 0; i < oneCount; i++)
            {
                employees[i] = new Employee()
                {
                    Id = i + 1,
                    Surname = GetRandomString(15),
                    Name = GetRandomString(15),
                    MiddleName = GetRandomString(15),
                    PositionId = random.Next(1, oneCount),
                    UserId = random.Next(1, oneCount),
                };
            }
            return employees;
        }

        public OptionalEquipment[] GetTestOptionalEquipments()
        {
            var random = new Random();
            var equipments = new OptionalEquipment[oneCount];
            for (var i = 0; i < oneCount; i++)
            {
                equipments[i] = new OptionalEquipment()
                {
                    Id = i + 1,
                    EquipmentName = GetRandomString(15),
                    Price = random.NextDouble()
                };
            }
            return equipments;
        }

        public Order[] GetTestOrders()
        {
            var random = new Random();
            var orders = new Order[manyCount];
            for (var i = 0; i < manyCount; i++)
            {
                orders[i] = new Order()
                {
                    Id = i + 1,
                    CustomerId = random.Next(1, oneCount),
                    CarId = random.Next(1, oneCount),
                    EmployeeId = random.Next(1, oneCount),
                    OrderDate = GetRandomDate(),
                    OrderCompleteMark = Convert.ToBoolean(random.Next(0, 1)),
                    SaleDate = GetRandomDate(),
                    PrePayment = random.NextDouble()
                };
            }
            return orders;
        }

        public User[] GetTestUsers()
        {
            var users = new User[oneCount];
            for (var i = 0; i < oneCount; i++)
            {
                users[i] = new User()
                {
                    Id = i + 1,
                    Login = GetRandomString(10),
                    Password = GetRandomString(10),
                    IsAdmin = false
                };
            }
            return users;
        }

        private string GetRandomString(int stringSize)
        {
            var randomString = string.Empty;
            var random = new Random();
            var symbols = new char[52]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            };
            for (int i = 0; i < symbols.Length; i++)
                randomString += symbols[random.Next(symbols.Length)];
            return randomString;
        }

        private DateTime GetRandomDate()
        {
            Random random = new Random();
            DateTime start = new DateTime(2020, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}
