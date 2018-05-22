using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.Core.Entities
{
	/// <summary>
	/// Customer entity class
	/// </summary>
	public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<CustomerCommunication> Communications { get; set; }

    }
}
