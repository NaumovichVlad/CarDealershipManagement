using AutoMapper;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Entities;

namespace CarDealershipManagement.Infrastructure.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<User, AppUser>().ConstructUsing(u => new AppUser {Id = u.Id.ToString(), Login = u.UserName, Password = u.Password});
            CreateMap<AppUser, User>().ConstructUsing(au => new User { UserName = au.UserName, Id = au.Id, Password = au.Password });
        }
    }
}
