﻿using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    [Auditable]
    public class UserAddress
    {
        public int Id { get; set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string UserId { get;private set; }
        public string RecieverName { get; private set; }

        public UserAddress(string state, string city, string zipCode, string postalAddress
            , string userId, string recieverName)
        {
            this.State = state;
            this.City = city;
            ZipCode = zipCode;
            PostalAddress = postalAddress;
            UserId = userId;
            RecieverName = recieverName;
        }
        public UserAddress()
        {

        }
    }
}
