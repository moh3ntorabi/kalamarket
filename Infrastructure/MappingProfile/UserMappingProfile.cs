using Application.Services.Users;
using AutoMapper;
using Domain.Orders;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MappingProfile
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AddUserAddressDto, UserAddress>();
            CreateMap<UserAddress, UserAddressDto>();
            CreateMap<UserAddress, Address>();
        }
       
    }
}
