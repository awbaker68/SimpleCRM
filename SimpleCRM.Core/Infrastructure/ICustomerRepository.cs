using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleCRM.Core.Entities;

namespace SimpleCRM.Core.Infrastructure
{
    /// <summary>
    /// Interface to be implemented by Customer Repository classes
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
		#region Get
		Customer GetByID(int? id);
		Task<Customer> GetByIDAsync(int? id);
		#endregion
	}
}
