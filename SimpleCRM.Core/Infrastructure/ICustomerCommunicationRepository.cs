using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleCRM.Core.Entities;

namespace SimpleCRM.Core.Infrastructure
{
    /// <summary>
    /// Interface to be implemented by Customer Communication Repository classes
    /// </summary>
    public interface ICustomerCommunicationRepository
    {
        IEnumerable<CustomerCommunication> GetCommunicationsForCustomer(int? customerID);
        Task<IEnumerable<CustomerCommunication>> GetCommunicationsForCustomerAsync(int? id);
    }
}
