using Orders.Interfaces;
using Orders.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Services
{
    public class CustomerService : ICustomerService
    {
        private IList<Customer> customers;

        public CustomerService()
        {
            this.customers = new List<Customer> 
            {
                new Customer(1, "KinetEco"), 
                new Customer(2, "Pixelford"),
                new Customer(3, "Topsy Turvy"),
                new Customer(4, "Leaf & Mortar")
            };
        }
        public Customer GetCustomerById(int id) => GetCustomerByIdAsync(id).Result;
        public Task<Customer> GetCustomerByIdAsync(int id) => Task.FromResult(customers.Single(c => Equals(c.Id, id)));
        public Task<IEnumerable<Customer>> GetCustomersAsync() => Task.FromResult(customers.AsEnumerable());
    }
}
