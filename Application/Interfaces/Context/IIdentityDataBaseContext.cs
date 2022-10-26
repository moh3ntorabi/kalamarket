using Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Context
{
    public interface IIdentityDataBaseContext
    {
        DbSet<User> Users { get; set; }
    }
}
