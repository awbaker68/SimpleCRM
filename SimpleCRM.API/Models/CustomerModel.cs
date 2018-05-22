using SimpleCRM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRM.API.Models
{
    /// <summary>
    /// Class to represent the customer data returned
    /// </summary>
    public class CustomerModel
    {
        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        #endregion

        #region Construction
        /// <summary>
        /// Constructor
        /// </summary>
		/// <param name="customer">A customer instance to base the model on</param>
        public CustomerModel(Customer customer)
        {
            if(customer !=null)
            {
                this.Id = customer.Id;
                this.FirstName = customer.FirstName;
                this.Surname = customer.Surname;
                this.Address = customer.Address;
                this.Phone = customer.Phone;
                this.Email = customer.Email;
            }
        }
        #endregion

        /// <summary>
        /// Get a Customer representation of the CustomerModel class
        /// </summary>
        /// <returns>The customer</returns>
        public Customer ToCustomer()
        {
            var customer = new Customer()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                Surname =this.Surname,
                Address = this.Address,
                Phone = this.Phone,
                Email = this.Email
            };
            return (customer);
        }
    }
}
