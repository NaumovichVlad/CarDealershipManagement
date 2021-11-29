using CarDealershipManagement.Core.Models;
using System;
using System.Drawing;
using System.IO;

namespace CarDealershipManagement.Core.Config
{
    public static class DbTestFiller
    {
        private static readonly int _lowCount = 100;
        private static readonly int _middleCount = 500;
        private static readonly int _higtCount = 1000;

        public static Manufacturer[] GetTestManufacturers()
        {
            var manufacturers = new Manufacturer[_lowCount];
            for (var i = 0; i < _lowCount; i++)
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

        public static Brand[] GetTestBrands()
        {
            var brands = new Brand[_middleCount];
            for (var i = 0; i < _middleCount; i++)
            {
                brands[i] = new Brand()
                {
                    BrandName = "brand_" + (i + 1),
                    ManufacturerId = i % _lowCount + 1
                };
            }
            return brands;
        }

        public static Position[] GetTestPositions()
        {
            var positions = new Position[_lowCount];
            for (var i = 0; i < _lowCount; i++)
            {
                positions[i] = new Position()
                {
                    PositionName = "position_" + (i + 1)
                };
            }
            return positions;
        }

        public static Specification[] GetTestSpecifications()
        {
            var random = new Random();
            var specs = new Specification[_lowCount];
            for (var i = 0; i < _lowCount; i++)
            {
                specs[i] = new Specification()
                {
                    SpecificationName = "specification_" + (i + 1),
                    SpecificationValue = random.NextDouble()
                };
            }
            return specs;
        }

        public static CarBasis[] GetTestCarsBasis()
        {
            var random = new Random();
            var cars = new CarBasis[_middleCount];
            var images = Directory.GetFiles(@"../Images");
            for (var i = 0; i < _middleCount; i++)
            {
                var image = Image.FromFile(images[i % images.Length]);
                byte[] imageBytes;
                using (MemoryStream ms = new())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageBytes = ms.ToArray();
                }
                cars[i] = new CarBasis()
                {
                    BrandId = random.Next(1, _middleCount),
                    Picture = imageBytes,
                    Color = GetRandomString(10),
                    Price = random.NextDouble()
                };
            }
            return cars;
        }

        public static Car[] GetTestCars()
        {
            var cars = new Car[_higtCount];
            for (var i = 0; i < _higtCount; i++)
            {
                cars[i] = new Car()
                {
                    RegistrationNumber = GetRandomString(8),
                    BodyTypeNumber = GetRandomString(8),
                    EngineNumber = GetRandomString(8),
                    CarBasisId = i % _middleCount + 1
                };
            }
            return cars;
        }

        public static OptionalEquipment[] GetTestOptionalEquipments()
        {
            var random = new Random();
            var equipments = new OptionalEquipment[_lowCount];
            for (var i = 0; i < _lowCount; i++)
            {
                equipments[i] = new OptionalEquipment()
                {
                    EquipmentName = GetRandomString(15),
                    Price = random.NextDouble()
                };
            }
            return equipments;
        }

        public static CarEquipment[] GetTestCarEquipments()
        {
            var carEquipments = new CarEquipment[_higtCount];
            for (var i = 0; i < _higtCount; i++)
            {
                carEquipments[i] = new CarEquipment()
                {
                    CarId = i + 1,
                    OptionalEquipmentId = i % _lowCount + 1
                };
            }
            return carEquipments;
        }

        public static CarSpecification[] GetTestCarSpecifications()
        {
            var random = new Random();
            var carSpecs = new CarSpecification[_higtCount];
            for (var i = 0; i < _higtCount; i++)
            {
                carSpecs[i] = new CarSpecification()
                {
                    CarBasisId = i % _middleCount + 1,
                    SpecificationId = random.Next(1, _lowCount)
                };
            }
            return carSpecs;
        }

        public static Customer[] GetTestCustomers()
        {
            var customers = new Customer[_middleCount];
            for (var i = 0; i < _middleCount; i++)
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
            var employees = new Employee[_middleCount]; 
            for (var i = 0; i < _middleCount; i++)
            {
                employees[i] = new Employee()
                {
                    Surname = GetRandomString(15),
                    Name = GetRandomString(15),
                    MiddleName = GetRandomString(15),
                    PositionId = random.Next(1, _lowCount),
                
                };
            }
            return employees;
        }

        public static Order[] GetTestOrders()
        {
            var random = new Random();
            var orders = new Order[_middleCount];
            for (var i = 0; i < _middleCount; i++)
            {
                orders[i] = new Order()
                {
                    CustomerId = random.Next(1, _middleCount),
                    CarId = i + _lowCount + 1,
                    EmployeeId = random.Next(1, _middleCount),
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
