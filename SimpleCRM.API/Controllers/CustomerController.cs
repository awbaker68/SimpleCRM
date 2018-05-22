using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.API.Models;
using SimpleCRM.Core.Entities;
using SimpleCRM.Core.Infrastructure;

namespace SimpleCRM.API.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]/[action]")]
	public class CustomerController : Controller
	{
		private readonly IApplicationUnitOfWork _unitOfWork;

		public CustomerController(IApplicationUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		[ActionName("GetAllCustomers")]
		public async Task<IActionResult> Get()
		{
			var customers = await _unitOfWork.Customers.GetAllAsync();

			// Create a simplified model
			var response = customers.Select(c => new CustomerModel(c));

			return Ok(response);
		}

		[HttpGet("{id}")]
		[ActionName("GetCustomer")]
		public async Task<IActionResult> Get(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var customer = await _unitOfWork.Customers.GetByIDAsync(id);
			if (customer == null)
			{
				return NotFound();
			}

			// Create a simplified model
			var response = new CustomerModel(customer);
			return Ok(response);
		}

		[HttpPost]
		[ActionName("CreateCustomer")]
		public IActionResult Create([FromBody] CustomerModel customer)
		{
			if (customer == null)
			{
				return BadRequest();
			}

			_unitOfWork.Customers.Add(customer.ToCustomer());
			_unitOfWork.SaveChanges();

			return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);
		}

		[HttpPut("{id}")]
		[ActionName("UpdateCustomer")]
		public IActionResult Update(int id, [FromBody] CustomerModel customer)
		{
			if (customer == null || customer.Id != id)
			{
				return BadRequest();
			}

			// Get the customer we want to update
			var thisCustomer = _unitOfWork.Customers.Get(id);
			if (thisCustomer == null)
			{
				return NotFound();
			}

			// Update the customer 
			thisCustomer.FirstName = customer.FirstName;
			thisCustomer.Surname = customer.Surname;
			thisCustomer.Address = customer.Address;
			thisCustomer.Phone = customer.Phone;
			thisCustomer.Email = customer.Email;

			_unitOfWork.Customers.Update(thisCustomer);
			_unitOfWork.SaveChanges();

			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		[ActionName("DeleteCustomer")]
		public IActionResult Delete(int id)
		{
			var customer = _unitOfWork.Customers.Get(id);
			if (customer == null)
			{
				return NotFound();
			}

			_unitOfWork.Customers.Remove(customer);
			_unitOfWork.SaveChanges();

			return new NoContentResult();
		}

		#region Customer Communications
		[HttpGet("{id}")]
		[ActionName("GetCustomerCommunications")]
		public async Task<IActionResult> GetCommunicationsForCustomer(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var comms = await _unitOfWork.CustomerCommunications.GetCommunicationsForCustomerAsync(id);
			if (comms == null)
			{
				return NotFound();
			}

			// Create a simplified model
			var response = comms.Select(c => new CustomerCommunicationModel(c));
			return Ok(response);
		}
		#endregion
	}
}