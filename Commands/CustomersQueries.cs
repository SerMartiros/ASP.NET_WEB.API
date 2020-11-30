using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_WEB.API
{
    class CustomersQueries
    {
        AUTO_ETL_META_DBEntities _context = new AUTO_ETL_META_DBEntities();
        List<Customer> customerList = new List<Customer>();
        public List<Customer> GetAllCustomers()
        {
            var allCustomers = _context.Customers.ToList();
            return allCustomers;
        }
        public void GetAllCustomers_IntervalMinutes(int minutes)
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(minutes);

            var timer = new System.Threading.Timer((e) =>
            {
                customerList.AddRange(GetAllCustomers());
            }, null, startTimeSpan, periodTimeSpan);
        }
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void AddCustomers(List<Customer> customerList)
        {
            _context.Customers.AddRange(customerList);
            _context.SaveChanges();
        }
        public void Put(int id, Customer customer)
        {
            var entity = _context.Customers.FirstOrDefault(e => e.Id == id);
            entity.WasSatisfied = customer.WasSatisfied;
            entity.Age = customer.Age;
            entity.Sex = customer.Sex;
            entity.VisitDateTime = customer.VisitDateTime;
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteCustomer(int id)
        {
            Customer customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
        }
    }
}
