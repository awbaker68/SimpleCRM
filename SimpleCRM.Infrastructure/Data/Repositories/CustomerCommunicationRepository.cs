using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCRM.Core.Entities;
using SimpleCRM.Core.Infrastructure;

namespace SimpleCRM.Infrastructure.Data.Repositories
{
    public class CustomerCommunicationRepository :Repository<CustomerCommunication>, ICustomerCommunicationRepository
    {
        private ApplicationDBContext appContext
        {
            get { return (ApplicationDBContext)_context; }
        }

        public CustomerCommunicationRepository(ApplicationDBContext context) : base(context)
        { }

        public IEnumerable<CustomerCommunication> GetCommunicationsForCustomer(int? customerId)
        {
            return appContext.CustomerCommunications.Where(q=>q.CustomerId == customerId).OrderBy(q=>q.CommunicationTime).ToList();
        }

        public Task<IEnumerable<CustomerCommunication>> GetCommunicationsForCustomerAsync(int? customerId)
        {
            return Task.Run(() =>
            {
                return GetCommunicationsForCustomer(customerId);
            });
        }
    }

}
