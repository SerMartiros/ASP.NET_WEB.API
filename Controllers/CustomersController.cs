using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP.NET_WEB.API.Controllers
{
    public class CustomersController : ApiController
    {
        public IEnumerable<Customer> Get()
        {
            CustomersQueries cq = new CustomersQueries();
            return cq.GetAllCustomers();
        }
        public Customer Get(int id)
        {
            CustomersQueries cq = new CustomersQueries();
            return cq.GetAllCustomers().Where(x=>x.Id == id).FirstOrDefault();
        }
        public void Post([FromBody] Customer customer)
        {
            CustomersQueries cq = new CustomersQueries();
            cq.AddCustomer(customer);
        }

        //public void Post([FromBody] List<Customer> customers)
        //{
        //    CustomersQueries cq = new CustomersQueries();
        //    cq.AddCustomers(customers);
        //}
        public void Put(int id, [FromBody] Customer customer)
        {
            CustomersQueries cq = new CustomersQueries();
            cq.Put(id, customer);
        }

        public void Delete(int id)
        {
            CustomersQueries cq = new CustomersQueries();
            cq.DeleteCustomer(id);
        }
    }
}
