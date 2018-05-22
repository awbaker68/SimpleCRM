using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCRM.Core.Entities;
using SimpleCRM.Core.Infrastructure;

namespace SimpleCRM.Infrastructure.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private ApplicationDBContext AppContext
        {
            get { return (ApplicationDBContext)_context; }
        }

        public CustomerRepository(ApplicationDBContext context) : base(context)
        { }

        #region Get All
        public override IEnumerable<Customer> GetAll()
        {
            return base.GetAll().OrderBy(c => c.Surname).ThenBy(c => c.FirstName);
        }

        public override Task<IEnumerable<Customer>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return GetAll();
            });
        }
        #endregion

        #region Get By ID
        public Customer GetByID(int? id)
        {
            return base.Find(c => c.Id == id).FirstOrDefault();
        }

        public Task<Customer> GetByIDAsync(int? id)
        {
            return Task.Run(() =>
            {
                return GetByID(id);
            });
        }
        #endregion
    }
}
