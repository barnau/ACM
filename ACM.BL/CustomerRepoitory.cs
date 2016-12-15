using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerRepoitory
    {
        public AddressRepository addressRepository { get; set; }

        public CustomerRepoitory()
        {
            addressRepository = new AddressRepository();
        }

        public Customer Retrieve(int customerId)
        {
            var customer = new Customer(customerId);
            customer.AddressList = addressRepository.RetrieveByCustomerId(customerId).ToList();

            if (customerId == 1)
            {
                customer.EmailAddress = "fbag@hob.com";
                customer.FirstName = "Frodo";
                customer.LastName = "Baggins";
            }

            return customer;

        }

        public List<Customer> Retrieve()
        {
            return new List<Customer>();
        }

        public bool Save(Customer customer)
        {
            var success = true;

            if (customer.HasChanges && customer.IsValid)
            {
                // Call an Insert Stored Procedure
            }
            else
            {
                // Call an Updated Stored Procedure
            }
            return success;
        }
    }
}
