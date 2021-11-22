using AutoMapper;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Entities;

namespace CarDealershipManagement.Infrastructure.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, AppUser>().ConstructUsing(u => new AppUser { Id = u.Id, UserName = u.UserName, PasswordHash = u.Password });
            CreateMap<AppUser, User>().ConstructUsing(au => new User { UserName = au.UserName, Id = au.Id, Password = au.PasswordHash });
        }
    }
}
