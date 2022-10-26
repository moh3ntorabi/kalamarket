using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesTest.Builders
{
    public class AddressBuilder
    {
        private Address _address;
        public string TestCity => "Esfahan";
        public string TestState => "Bozorgmehr";
        public string TestZipCode => "2946646";
        public string TestPostalAddress => "Meta";
        public string TestReceiverName => "Test Name";
        public AddressBuilder()
        {
            _address = WithDefaultValue();
        }
        public Address Build()
        {
            return _address;
        }
        private Address WithDefaultValue()
        {
            _address = new Address(TestCity, TestState, TestZipCode, TestPostalAddress,TestReceiverName);
            return _address;
        }
    }
}
