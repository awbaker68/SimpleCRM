using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCRM.Core.Entities;

namespace SimpleCRM.Infrastructure.Data
{
    /// <summary>
    /// Database context class for the Hospital
    /// </summary>
    public class ApplicationDBContext : DbContext
    {
        #region Properties
        public string CurrentUserId { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCommunication> CustomerCommunications { get; set; }
        #endregion

        #region Construction
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        { }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>().HasIndex(c => c.Id);
            builder.Entity<Customer>().Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.Surname).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.Address).HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.Phone).HasMaxLength(20);
            builder.Entity<Customer>().Property(c => c.Email).HasMaxLength(100);
            builder.Entity<Customer>().ToTable($"App{nameof(this.Customers)}");

            builder.Entity<CustomerCommunication>().Property(o => o.Detail).HasMaxLength(1000);
            builder.Entity<CustomerCommunication>().ToTable($"App{nameof(this.CustomerCommunications)}");
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(cancellationToken);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
