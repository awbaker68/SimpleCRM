using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleCRM.Core.Entities;
using SimpleCRM.Core.Infrastructure;

namespace SimpleCRM.Infrastructure.Data
{
    /// <summary>
    /// Initialize the database
    /// </summary>
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger _logger;

        public DatabaseInitializer(ApplicationDBContext context, ILogger<DatabaseInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            //await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _context.Customers.AnyAsync())
            {
                _logger.LogInformation("Seeding initial data");

                // Customer 1
                Customer customer1 = new Customer
                {
                    Id = 1,
                    FirstName = "John",
                    Surname = "Smith",
                    Address = "Address1",
                    Email = "johnsmith@domain.co.uk",
                    Phone = "2222222"
                };

                CustomerCommunication comm1_1 = new CustomerCommunication
                {
                    Id = 1,
                    CustomerId = customer1.Id,
                    CommunicationType = Core.CommunicationType.Email,
                    CommunicationTime = DateTime.UtcNow,
                    Detail = "Quotation Request"
                };

                _context.Customers.Add(customer1);
                _context.CustomerCommunications.Add(comm1_1);

                // Customer 2
                Customer customer2 = new Customer
                {
                    Id = 2,
                    FirstName = "Dave",
                    Surname = "Jones",
                    Address = "Address1",
                    Email = "davejones@domain.co.uk",
                    Phone = "7777777"
                };

                CustomerCommunication comm2_1 = new CustomerCommunication
                {
                    Id =2,
                    CustomerId = customer2.Id,
                    CommunicationType = Core.CommunicationType.Email,
                    CommunicationTime = DateTime.UtcNow,
                    Detail = "Quotation Request"
                };

                CustomerCommunication comm2_2 = new CustomerCommunication
                {
                    Id= 3,
                    CustomerId = customer2.Id,
                    CommunicationType = Core.CommunicationType.Email,
                    CommunicationTime = DateTime.UtcNow,
                    Detail = "Quotation Request 2"
                };

                _context.Customers.Add(customer2);
                _context.CustomerCommunications.Add(comm2_1);
                _context.CustomerCommunications.Add(comm2_2);

                await _context.SaveChangesAsync();

                _logger.LogInformation("Seeding initial data completed");
            }
        }
    }
}
