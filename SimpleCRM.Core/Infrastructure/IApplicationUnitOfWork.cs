using System;
using System.Collections.Generic;
using System.Text;
using SimpleCRM.Core.Entities;

namespace SimpleCRM.Core.Infrastructure
{
    /// <summary>
    /// Interface to be implemented by Application Unit of Work classes
    /// </summary>
    public interface IApplicationUnitOfWork
    {
		#region Properties
		/// <value>Accesses the CustomerRepository instance</value>
		ICustomerRepository Customers { get; }

		/// <value>Accesses the CustomerCommunicationsRepository instance</value>
		ICustomerCommunicationRepository CustomerCommunications { get; }
		#endregion

		#region Save Changes
		/// <summary>
		/// Save the changes
		/// </summary>
		/// <returns>The number of records saved</returns>
		int SaveChanges();
		#endregion
	}
}
