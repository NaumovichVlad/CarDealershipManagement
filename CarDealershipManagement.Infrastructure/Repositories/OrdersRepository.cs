﻿using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class OrdersRepository : Repository<Order>
    {
        public OrdersRepository(DbContextOptions<CarDealershipContext> options) : base(options)
        { }
    }
}
