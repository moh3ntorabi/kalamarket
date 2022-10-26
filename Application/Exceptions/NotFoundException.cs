using Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    class NotFoundException:Exception
    {
        public NotFoundException(string EntityName,object Key)
            :base($"Entity {EntityName} with key {Key} not found")
        {

        }

        
    }
}
