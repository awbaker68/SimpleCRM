using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.Core.Entities
{
	/// <summary>
	/// Customer communication entity class
	/// </summary>
	public class CustomerCommunication
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CommunicationType CommunicationType { get; set; }
        public DateTime CommunicationTime { get; set; }
        public string Detail { get; set; }

        public Customer Customer { get; set; }
    }
}
