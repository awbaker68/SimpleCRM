using SimpleCRM.Core;
using SimpleCRM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRM.API.Models
{
	/// <summary>
	/// Class to represent the customer communication data returned
	/// </summary>
	public class CustomerCommunicationModel
    {
        #region Properties
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CommunicationType CommunicationType { get; set; }
        public DateTime CommunicationTime { get; set; }
        public string Detail { get; set; }
        #endregion

        #region Construction
        /// <summary>
        /// Constructor
        /// </summary>
		/// <param name="customerCommunication">A customer communication instance to base the model on</param>
        public CustomerCommunicationModel(CustomerCommunication customerCommunication)
        {
            if (customerCommunication != null)
            {
                this.Id = customerCommunication.Id;
                this.CustomerId = customerCommunication.CustomerId;
                this.CommunicationType = customerCommunication.CommunicationType;
                this.CommunicationTime = customerCommunication.CommunicationTime;
                this.Detail = customerCommunication.Detail;
            }
        }
        #endregion

        /// <summary>
        /// Get a CustomerCommunication representation of the CustomerCommunicationModel class
        /// </summary>
        /// <returns>The customer communication</returns>
        public CustomerCommunication ToCustomerCommunication()
        {
            var customer = new CustomerCommunication()
            {
                Id = this.Id,
                CustomerId = this.CustomerId,
                CommunicationType = this.CommunicationType,
                CommunicationTime = this.CommunicationTime,
                Detail = this.Detail
            };
            return (customer);
        }
    }
}
