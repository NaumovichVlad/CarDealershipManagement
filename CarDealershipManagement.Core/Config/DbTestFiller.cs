using CarDealershipManagement.Core.Models;
using System;
using System.Drawing;
using System.IO;

namespace CarDealershipManagement.Core.Config
{
    public static class DbTestFiller
    {
        private static readonly int _oneCount = 1000;
        private static readonly int _manyCount = 100;

        public static Brand[] GetTestBrands()
        {
            var brands = new Brand[_oneCount];
            for (var i = 0; i < _oneCount; i++)
            {
                brands[i] = new Brand()
                {
                    BrandName = "brand_" + (i + 1)
                };
            }
            return brands;
        }

        public static Position[] GetTestPositions()
        {
            var positions = new Position[_oneCount];
            for (var i = 0; i < _oneCount; i++)
            {
                positions[i] = new Position()
                {
                    PositionName = "position_" + (i + 1)
                };
            }
            return positions;
        }

        public static Manufacturer[] GetTestManufacturers()
        {
            var manufacturers = new Manufacturer[_oneCount];
            for (var i = 0; i < _oneCount; i++)
            {
                manufacturers[i] = new Manufacturer()
                {
                    ManufacturerName = "manufacturer_" + (i + 1),
                    Adress = GetRandomString(30),
                    Description = GetRandomString(50)
                };
            }
            return manufacturers;
        }

        public static Specification[] GetTestSpecs()
        {
            var random = new Random();
            var specs = new Specification[_oneCount];
            for (var i = 0; i < _oneCount; i++)
            {
                specs[i] = new Specification()
                {
                    SpecificationName = "specification_" + (i + 1),
                    SpecificationValue = random.NextDouble()
                };
            }
            return specs;
        }

        public static Car[] GetTestCars()
        {
            var random = new Random();
            var cars = new Car[_oneCount];
            var images = Directory.GetFiles(@"../Images");
            for (var i = 0; i < _oneCount; i++)
            {
                var image = Image.FromFile(images[i % images.Length]);
                byte[] imageBytes;
                using (MemoryStream ms = new())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageBytes = ms.ToArray();
                }
                cars[i] = new Car()
                {
                    RegistrationNumber = GetRandomString(10),
                    BrandId = random.Next(1, _oneCount),
                    ManufacturerId = random.Next(1, _oneCount),
                    Picture = imageBytes,
                    Color = GetRandomString(10),
                    BodyTypeNumber = GetRandomString(10),
                    EngineNumber = GetRandomString(10),
                    Price = random.NextDouble()
                };
            }
            return cars;
        }

        public static CarEquipment[] GetTestCarEquipments()
        {
            var random = new Random();
            var carEquipments = new CarEquipment[_manyCount];
            for (var i = 0; i < _manyCount; i++)
            {
                carEquipments[i] = new CarEquipment()
                {
                    CarId = random.Next(1, _oneCount),
                    EquipmentId = random.Next(1, _oneCount)
                };
            }
            return carEquipments;
        }

        public static CarSpecification[] GetTestCarSpecs()
        {
            var random = new Random();
            var carSpecs = new CarSpecification[_manyCount];
            for (var i = 0; i < _manyCount; i++)
            {
                carSpecs[i] = new CarSpecification()
                {
                    CarId = random.Next(1, _oneCount),
                    SpecificationId = random.Next(1, _oneCount)
                };
            }
            return carSpecs;
        }

        public static Customer[] GetTestCustomers()
        {
            var customers = new Customer[_oneCount];
            for (var i = 0; i < _oneCount; i++)
            {
                customers[i] = new Customer()
                {
                    Surname = GetRandomString(15),
                    Name = GetRandomString(15),
                    MiddleName = GetRandomString(15),
                    PassportData = GetRandomString(10),
                    Address = GetRandomString(20),
                };
            }
            return customers;
        }

        public static Employee[] GetTestEmployees()
        {
            var random = new Random();
            var employees = new Employee[_manyCount]; 
            for (var i = 0; i < _manyCount; i++)
            {
                employees[i] = new Employee()
                {
                    Surname = GetRandomString(15),
                    Name = GetRandomString(15),
                    MiddleName = GetRandomString(15),
                    PositionId = random.Next(1, _manyCount),
                
                };
            }
            return employees;
        }

        public static OptionalEquipment[] GetTestOptionalEquipments()
        {
            var random = new Random();
            var equipments = new OptionalEquipment[_oneCount];
            for (var i = 0; i < _oneCount; i++)
            {
                equipments[i] = new OptionalEquipment()
                {
                    EquipmentName = GetRandomString(15),
                    Price = random.NextDouble()
                };
            }
            return equipments;
        }

        public static Order[] GetTestOrders()
        {
            var random = new Random();
            var orders = new Order[_manyCount];
            for (var i = 0; i < _manyCount; i++)
            {
                orders[i] = new Order()
                {
                    CustomerId = random.Next(1, _oneCount),
                    CarId = random.Next(1, _oneCount),
                    EmployeeId = random.Next(1, _manyCount),
                    OrderDate = GetRandomDate(),
                    OrderCompleteMark = Convert.ToBoolean(random.Next(0, 1)),
                    SaleDate = GetRandomDate(),
                    PrePayment = random.NextDouble()
                };
            }
            return orders;
        }

        private static string GetRandomString(int stringSize)
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
            for (int i = 0; i < stringSize; i++)
                randomString += symbols[random.Next(symbols.Length)];
            return randomString;
        }

        private static DateTime GetRandomDate()
        {
            Random random = new();
            DateTime start = new(2020, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}
