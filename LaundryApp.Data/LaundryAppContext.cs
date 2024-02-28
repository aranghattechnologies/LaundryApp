using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryApp.Entities;

namespace LaundryApp.Data
{
    public class LaundryAppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PickUpRequest> PickUpRequests { get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }

       public LaundryAppContext(DbContextOptions<LaundryAppContext> options) { }

    }
}
