using Application.Interfaces.Context;
using AutoMapper;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users
{
    public interface IUserAddressService
    {
        List<UserAddressDto> GetAddress(string userId);
        void AddUserAddress(AddUserAddressDto address);
    }

    public class UserAddressService : IUserAddressService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public UserAddressService(IDataBaseContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void AddUserAddress(AddUserAddressDto address)
        {
            var data=mapper.Map<UserAddress>(address);
            context.UserAddresses.Add(data);
            context.SaveChanges();
        }

        public List<UserAddressDto> GetAddress(string userId)
        {
            var addresses= context.UserAddresses.Where(p=>p.UserId==userId);
            var data = mapper.Map<List<UserAddressDto>>(addresses);
            return data;
        }
    }

    public class UserAddressDto
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PostalAddress { get; set; }
        public string RecieverName { get; set; }
    }
    public class AddUserAddressDto
    {
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PostalAddress { get; set; }
        public string RecieverName { get; set; }
        public string UserId { get; set; }
    }
}
