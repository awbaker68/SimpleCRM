using System;
using System.Collections.Generic;
using System.Text;
using SimpleCRM.Core.Infrastructure;
using SimpleCRM.Infrastructure.Data.Repositories;

namespace SimpleCRM.Infrastructure.Data
{
    /// <summary>
    /// Unit of work class for the Application
    /// </summary>
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
		#region Properties
		private ApplicationDBContext _context;
		private ICustomerRepository _customers;
		private ICustomerCommunicationRepository _customerCommunications;

		/// <value>Accesses the CustomerRepository instance</value>
		public ICustomerRepository Customers
		{
			get
			{
				if (_customers == null)
				{
					_customers = new CustomerRepository(_context);
				}
				return _customers;
			}
		}

		/// <value>Accesses the CustomerCommunicationsRepository instance</value>
		public ICustomerCommunicationRepository CustomerCommunications
		{
			get
			{
				if (_customerCommunications == null)
				{
					_customerCommunications = new CustomerCommunicationRepository(_context);
				}
				return _customerCommunications;
			}
		}
		#endregion

		#region Construction
		public ApplicationUnitOfWork(ApplicationDBContext context)
		{
			_context = context;
		}
		#endregion

		#region Save
		/// <summary>
		/// Save the changes
		/// </summary>
		/// <returns>The number of records saved</returns>
		public int SaveChanges()
		{
			return _context.SaveChanges();
		}
		#endregion
	}
}
