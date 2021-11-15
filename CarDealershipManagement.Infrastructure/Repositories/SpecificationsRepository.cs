﻿using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class SpecificationsRepository : Repository<Specification>
    {
        public SpecificationsRepository(DbContextOptions<CarDealershipContext> options) : base(options)
        { }
    }
}
